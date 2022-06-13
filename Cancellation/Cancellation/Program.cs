

//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace Cancellation // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static async Task Main()
        {
            var tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            var task = Task.Run(() =>
            {
                token.ThrowIfCancellationRequested();

                bool moreToDo = true;
                int i = 0;

                while (moreToDo)
                {
                    Console.WriteLine($"Test {i++}");

                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                }
            }, tokenSource.Token);

            Task.Delay(3000).ContinueWith(t =>
            {
                tokenSource.Cancel();
            });

            // Just continue on this thread, or await with try-catch:
            try
            {
                await task;
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                tokenSource.Dispose();
            }

            Console.ReadKey();
        }
    }
}