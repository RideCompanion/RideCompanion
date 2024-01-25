namespace RIdeCompanion.Extensions;

/// <summary>
/// MediatR configuration extension
/// </summary>
public static class MediatRExtension
{
    /// <summary>
    /// Configuration application services
    /// </summary>
    /// <returns></returns>
    public static Action<MediatRServiceConfiguration> Configuration()
    {
        return cfg =>
        {
            //cfg.RegisterServicesFromAssemblyContaining<AppName>();
        };
    }
}