using RabbitMQ.Client;
using RabbitMQConsumer;
using System.Text;
using System.Text.Json;

// Load the JSON file
string jsonPath = @"C:\Users\orog1\source\repos\RabbitMQDemo\backend\bin\Debug\net7.0\targets.json";
string jsonContent = File.ReadAllText(jsonPath);

// Deserialize the list of targets
var targets = JsonSerializer.Deserialize<List<structTarget.Target>>(jsonContent);

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "targetQueue",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

foreach (var target in targets)
{
    // Serialize each target individually
    var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(target));

    // Publish each target to the queue one by one
    await channel.BasicPublishAsync(
        exchange: string.Empty,
        routingKey: "targetQueue",
        mandatory: true,
           basicProperties: new BasicProperties { Persistent = true },
        body: messageBody
    );

    Console.WriteLine($" [x] Sent Target ID: {target.Id}");
}

Console.WriteLine(" [x] All targets sent.");
