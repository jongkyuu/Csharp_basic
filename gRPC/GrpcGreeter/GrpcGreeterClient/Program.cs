﻿using Grpc.Net.Client;
using System;
using GrpcGreeterClient;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine($"Greeting : {reply.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
