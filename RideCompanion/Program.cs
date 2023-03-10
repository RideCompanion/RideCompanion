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
    MinimumSameSitePolicy = SameSiteMode.Strict,
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