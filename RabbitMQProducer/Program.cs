using System;
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using RabbitMQConsumer;

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

var consumer = new AsyncEventingBasicConsumer(channel);

 consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Raw message received: {message}");

    try
    {
        var targets = JsonSerializer.Deserialize<List<structTarget.Target>>(message);
        if (targets != null)
        {
            Console.WriteLine("Received list of targets:");
            foreach (var target in targets)
            {
                Console.WriteLine($"Target ID: {target.Id}");
            }
        }
        else
        {
            var singleTarget = JsonSerializer.Deserialize<structTarget.Target>(message);
            Console.WriteLine($"Received single target with ID: {singleTarget.Id}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to deserialize message: " + ex.Message);
    }
};

await channel.BasicConsumeAsync(queue: "targetQueue", autoAck: true, consumer: consumer);

Console.WriteLine("Waiting for messages. Press [enter] to exit.");
Console.ReadLine();