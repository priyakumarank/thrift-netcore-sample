using System;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Service;
using Thrift.Transport.Client;

namespace Thrift.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RunAsync().Result;
            Console.WriteLine("Result: Message-" + result.Message + " Date-" + result.Received);
        }

        private static async Task<Service.Models.helloMessageResult> RunAsync()
        {
            var transport = new THttpTransport(new Uri("http://localhost:5001"));
            var protocol = new TCompactProtocol(transport);
            TMultiplexedProtocol mp = new TMultiplexedProtocol(protocol, nameof(helloService));
            var client = new helloService.Client(mp);
            using(client)
            {
                await client.OpenTransportAsync();
                var message = new Service.Models.helloMessage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Service.Models.Enums.MessageType.Information

                };
                var result = await client.getMessageAsync(message);
                return result;
            }
           
             
        }
    }
}
