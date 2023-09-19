# dotnet-kafka-example

This is a small example where I made two simple applications to server as producer and consumer for Kafka, respectively. This example didn't mind about topic partitions as it was developed just to showcase how easy using Kafka is using .NET, specially with the `Confluent.Kafka` package.

## Running the Applications

First, we need Kafka to be running for both applications to work. We will be using the `bitnami/kafka:latest` Docker image specified in the docker-compose.yml. To spin up the container, we just need to run:

```sh
# When using an older version of docker, run docker-compose up instead
docker compose up
```

The solution file already references the two projects, so we can build both by running `dotnet build`, but we can also build and run by using both:

```sh
dotnet run --project Example.ConsoleProducer
dotnet run --project Example.Console.Consumer
```

**Note:** The consumer will throw an error if started first because the Kafka container needs the topic to be created before it can serve the messages. Running the producer first automatically creates the topic and sends the messages.

Now everything should be running and everytime we execute the producer application now, we will see the messages being received by the consumer almost instantly!

## License

[MIT](LICENSE)