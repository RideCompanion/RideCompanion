using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using RIdeCompanion.Producers;

namespace RIdeCompanion.Controllers;

public class KafkaConsumerController : Controller
{
    private readonly ConsumerConfig _consumerConfig;
    private readonly string? _kafkaTopic;
    private readonly ProducerService _producer;

    public KafkaConsumerController(IConfiguration configuration, ProducerService producer)
    {
        _producer = producer;

        _consumerConfig = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = "my-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _kafkaTopic = configuration["Kafka:Topic"];
    }

    public async Task<IActionResult> Produce()
    {
        await _producer.ProduceAsync("test-topic", "test message");

        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> Consume()
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        consumer.Subscribe(_kafkaTopic);
        var consumeResult = consumer.Consume();

        Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' from topic '{consumeResult.Topic}'");

        ViewData["Message"] = consumeResult.Message.Value;
        ViewData["Topic"] = consumeResult.Topic;

        return View();
    }
}