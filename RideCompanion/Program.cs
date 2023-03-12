using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RideCompanion.Extensions;
using Shared.Migrations;
using Shared.Infrastructure.CacheService;
using Shared.Infrastructure.Services;
using Shared.Infrastructure.Services.Interfaces;
using Trip.App.TripBuilder;
using User.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<UserEntity, RoleEntity>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    });

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

MappingExtensions.AutoMapperExtensions(builder);

builder.Services.AddMediatR(MediatRConfigurationExtension.Configuration());
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<ITripBuilder, TripBuilder>();
builder.Services.AddScoped<ITripDirector, TripDirector>();
builder.Services.AddSingleton<IChartService, ChartService>();

builder.Services.AddTransient<CacheService>();
builder.Services.AddMemoryCache();
builder.Services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

var app = builder.Build();

var cookiePolicyOptions = new CookiePolicyOptions
{
    CheckConsentNeeded = _ => true,
    MinimumSameSitePolicy = SameSiteMode.None
};

app.UseCookiePolicy(cookiePolicyOptions);

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseFastReport();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();