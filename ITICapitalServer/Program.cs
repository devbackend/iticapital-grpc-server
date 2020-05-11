using System;
using Confluent.Kafka;
using Grpc.Core;
using Iticapital;
using ITICapitalServer.Logging;
using SmartCOM4Lib;

namespace ITICapitalServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();

            var kafkaConfig = new ProducerConfig {BootstrapServers = DotNetEnv.Env.GetString("KAFKA_PRODUCER_HOST")};
            var producer = new ProducerBuilder<Null, string>(kafkaConfig).Build();
            var smartCom = new StServerClass();
            var logger = new ConsoleLogger();

            ServerEventsListener listener = new ServerEventsListener(smartCom, producer, logger);

            listener.Start();

            smartCom.connect(
                DotNetEnv.Env.GetString("SMARTCOM_SERVER_HOST"),
                (ushort) DotNetEnv.Env.GetDouble("SMARTCOM_SERVER_PORT"),
                DotNetEnv.Env.GetString("SMARTCOM_SERVER_LOGIN"),
                DotNetEnv.Env.GetString("SMARTCOM_SERVER_PASSWORD")
            );

            var gRpcPort = new ServerPort(
                "",
                DotNetEnv.Env.GetInt("GRPC_PORT"),
                ServerCredentials.Insecure
            );

            var brokerService = new BrokerService(smartCom, logger);

            Server server = new Server
            {
                Services = {ITICapitalAPI.BindService(brokerService)},
                Ports = {gRpcPort}
            };
            server.Start();

            logger.Write($"Start gRPC on {gRpcPort.Host}:{gRpcPort.Port}");
            logger.Write($"Listen kafka on {kafkaConfig.BootstrapServers}");

            var isStopped = false;
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) =>
            {
                isStopped = true;
                logger.Write("Stop signal");
            };

            while (!isStopped)
            {
            }
            
            logger.Write("Stopping gRPC and SmartCOM...");

            smartCom.disconnect();
            server.ShutdownAsync().Wait();
            
            logger.Write("Stopped");
        }
    }
}