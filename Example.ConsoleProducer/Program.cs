using Confluent.Kafka;

ProducerConfig config = new ProducerConfig()
{
    BootstrapServers = "localhost:9094",
    Acks = Acks.Leader
};

IProducer<string, string> producer =
    new ProducerBuilder<string, string>(config).Build();


for (int i = 0; i < 100; i++)
{
    producer.Produce("ExampleTopic",
        new Message<string, string>()
        {
            Key = $"Key: {i}",
            Value = $"Value: {i}"
        }
    );
    producer.Flush();
    Console.WriteLine($"Produced \"Value: {i}\"");
}
