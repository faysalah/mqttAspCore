using System;

namespace Mqtt.Subscriber.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Subscriber Worker";

            MqttHandler mqttHandler = new MqttHandler();
            mqttHandler.SubscribeTopic("hello");

            Console.ReadKey();
        }
    }
}
