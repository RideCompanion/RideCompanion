using Confluent.Kafka;

namespace RIdeCompanion.Producers;

public class ProducerService
{

    private readonly IProducer<Null, string> _producer;

    public ProducerService(IConfiguration configuration)
    {

        var producerConfig = new ProducerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"]
        };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var kafkamessage = new Message<Null, string> { Value = message, };

        await _producer.ProduceAsync(topic, kafkamessage);
    }
}