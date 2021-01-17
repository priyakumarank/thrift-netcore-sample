using System;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Service.Models;

namespace Thrift.Service
{
    public class HelloServiceHandler: helloService.IAsync
    {        
        public Task<Models.helloMessageResult> getMessageAsync(helloMessage message, CancellationToken cancellationToken = default)
        {
            var result = new Models.helloMessageResult()
            {
                Message = message.Type == Models.Enums.MessageType.Information ? "informative message" : "no message for you",
                Received = DateTime.Now.ToString()
            };
                
            return Task.FromResult(result);
            
        }
    }
}
