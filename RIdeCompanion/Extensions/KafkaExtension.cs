using RIdeCompanion.Producers;

namespace RIdeCompanion.Extensions;

/// <summary>
/// Kafka extension
/// </summary>
public static class KafkaExtension
{
    /// <summary>
    /// Configure Kafka
    /// </summary>
    /// <param name="webApplicationBuilder"> Web application builder </param>
    public static void Configure(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddSingleton<ProducerService>();
    }
}