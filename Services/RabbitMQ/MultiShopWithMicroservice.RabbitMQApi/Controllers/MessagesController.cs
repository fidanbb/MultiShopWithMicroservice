using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShopWithMicroservice.RabbitMQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        [HttpPost]

        public IActionResult CreateMessage()
        {
            var connectionfactory = new ConnectionFactory()
            {
                HostName= "localhost",

            };

            var connection = connectionfactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("Queue1", false, false, false, arguments: null);
            var messageContent = "Hello this is rabbitmq tail message";
            var byteMessageContent=Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "Queue1", basicProperties: null, body: byteMessageContent);

            return Ok("Your message has been received");
        }

        [HttpGet]

        public async Task<IActionResult> GetMessage()
        {
            var connectionfactory = new ConnectionFactory()
            {
                HostName = "localhost",

            };

            using var connection = connectionfactory.CreateConnection();
            using var channel = connection.CreateModel();

            var tcs = new TaskCompletionSource<string>();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var byteMessage = args.Body.ToArray();
                var message= Encoding.UTF8.GetString(byteMessage);
                tcs.SetResult(message);

            };

            channel.BasicConsume(queue: "Queue1", autoAck: true, consumer: consumer);
            var message = await tcs.Task.TimeoutAfter(TimeSpan.FromSeconds(10));

            return Ok(message);
        }
    }

    public static class TaskExtensions
    {
        public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource();
            var delayTask = Task.Delay(timeout, cts.Token);
            var completedTask = await Task.WhenAny(task, delayTask);

            if (completedTask == delayTask)
            {
                throw new TimeoutException("The operation has timed out.");
            }

            cts.Cancel();
            return await task;  
        }
    }
}
