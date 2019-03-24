using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.Publisher.Worker
{
    // event, delegate , callback , Treading , Task, schdule
    public class MqttHandler
    {
        private readonly IMqttClient _mqttClient;
        public MqttHandler()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
        }

        public async Task Connect(string clientId, string host)
        {
            try
            {
                var options = new MqttClientOptionsBuilder()
                     .WithClientId(clientId)
                     .WithTcpServer(host)
                     .WithCleanSession()
                     .Build();
                await _mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PublishMessage(string payload, string topic)
        {
            try
            {
                var options = new MqttClientOptionsBuilder()
                         .WithClientId("test")
                         .WithTcpServer("localhost")
                         .WithCleanSession()
                         .Build();
                await _mqttClient.ConnectAsync(options);

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                await _mqttClient.PublishAsync(message);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public void ConsumePayload(string topic)
        {
            try
            {
                _mqttClient.Connected += async (s, e) =>
                {
                    Console.WriteLine("### CONNECTED WITH SERVER ###");

                    await _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(topic).Build());

                    Console.WriteLine("### SUBSCRIBED ###");
                };

                _mqttClient.ApplicationMessageReceived += (s, e) =>
                {
                    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                    Console.WriteLine();
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
