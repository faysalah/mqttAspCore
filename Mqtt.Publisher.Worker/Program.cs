using MQTTnet;
using MQTTnet.Client;
using System;
using System.Threading.Tasks;

namespace Mqtt.Publisher.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Publisher Worker";
            MqttHandler mqttHandler = new MqttHandler();

            while (true)
            {
                Random random = new Random();
                var message = string.Format("Created At : {0} | {1}", DateTime.Now, random.NextDouble());
                var test = mqttHandler.PublishMessage(message, "hello");
                Task.Delay(TimeSpan.FromMinutes(1)).Wait();
            }
        }
    }
}
