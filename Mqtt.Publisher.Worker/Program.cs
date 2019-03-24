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
            

            while (true)
            {
                Console.WriteLine("Write a mesage");
                MqttHandler mqttHandler = new MqttHandler();
               
                var msg = Console.ReadLine();

                var test1 = mqttHandler.PublishMessage(msg, "hello");

                mqttHandler.ConsumePayload("hello");
            }
        }
    }
}
