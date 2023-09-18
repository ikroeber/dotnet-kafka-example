using Confluent.Kafka;

ConsumerConfig config = new ConsumerConfig()
{
    BootstrapServers = "localhost:9094",
    GroupId = "ExampleGroup",
    AutoOffsetReset = AutoOffsetReset.Earliest,

};

IConsumer<string, string> consumer =
    new ConsumerBuilder<string, string>(config).Build();

consumer.Subscribe("ExampleTopic");

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
CancellationToken cancellationToken = cancellationTokenSource.Token;

Console.CancelKeyPress += (_, e) =>
{
    cancellationTokenSource.Cancel();
    e.Cancel = true;
};

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n--- Listening for incoming messages --- \n");

Console.ResetColor();
while (!cancellationToken.IsCancellationRequested)
{
    try
    {

        var result = consumer.Consume(cancellationToken);
        Console.WriteLine($"Consumed \"{result.Message.Value}\"");
    }
    catch (OperationCanceledException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n→ Cancelling consume operation");
    }
}

Console.WriteLine("→ Closing consumer\n");
Console.ResetColor();

consumer.Close();
