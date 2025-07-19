namespace Saturn.Web
{
    public class KafkaClient
    {
    }
}
// In the Program.cs file of your client-consuming project, call the AddKafkaProducer extension 
// method to register an IProducer<TKey, TValue>
// This code provides a basic setup for using Kafka with Aspire, including creating a Kafka client,
// configuring it, and adding it to the Aspire application builder.
// https://learn.microsoft.com/en-us/dotnet/aspire/messaging/kafka-integration?tabs=dotnet-cli

// Aspire.Confluent.Kafka
// Add Kafka producer
builder.AddKafkaConsumer<string, string>("messaging"); // Add Kafka producer
builder.AddKafkaConsumer<string, string>("messaging"); // Add Kafka consumer
// retrieve the IConsumer<TKey, TValue>
internal sealed class Worker(IProducer<string, string> producer) : BackgroundService
{
    // Use producer...
}
internal sealed class Worker(IConsumer<string, string> consumer) : BackgroundService
{
    // Use consumer...
}