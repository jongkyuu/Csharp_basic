using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class ExampleService : Example.ExampleBase
    {
        private readonly ILogger<ExampleService> _logger;

        public ExampleService(ILogger<ExampleService> logger)
        {
            _logger = logger;
        }

        public override async Task<ExampleResponse> UnaryCall(ExampleRequest request, ServerCallContext context)
        {
            var response = new ExampleResponse();
            return await Task.FromResult(response);
        }

        public override async Task StreamingFromServer(ExampleRequest request, IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
        {
            while(!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new ExampleResponse { Message = "StreamingFromServer" });
                await Task.Delay(TimeSpan.FromSeconds(1000), context.CancellationToken);
            }
        }

        public override async Task<ExampleResponse> StreamingFromClient(IAsyncStreamReader<ExampleRequest> requestStream, ServerCallContext context)
        {
            //while (await requestStream.MoveNext())
            //{
            //    var message = requestStream.Current;
            //}

            await foreach(var message in requestStream.ReadAllAsync())
            {
                //...
            }

            return new ExampleResponse();
        }

        public override async Task StreamingBothWays(IAsyncStreamReader<ExampleRequest> requestStream,
            IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
        {
            //await foreach (var message in requestStream.ReadAllAsync())
            //{
            //    await responseStream.WriteAsync(new ExampleResponse());
            //}

            var readTask = Task.Run(async () =>
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    // Process request
                }
            });

            while (!readTask.IsCompleted)
            {
                await responseStream.WriteAsync(new ExampleResponse()); 
                await Task.Delay(TimeSpan.FromSeconds(1000), context.CancellationToken);
            }
        }
    }
}
