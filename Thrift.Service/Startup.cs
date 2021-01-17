using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Thrift.Processor;
using Thrift.Protocol;
using Thrift.Transport.Server;

namespace Thrift.Service
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }

        public StartUp(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSingleton(Configuration);

            services.AddTransient<helloService.IAsync, HelloServiceHandler>();
            services.AddTransient<ITAsyncProcessor, helloService.AsyncProcessor>();
            services.AddTransient<HelloServiceHandler>();

            services.AddTransient<THttpServerTransport, THttpServerTransport>();
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            //if you have services that the handlers need those can be resolved here
            //e.g. var logging = serviceProvider.GetService<HelloServiceLogging>();

            var helloServiceHandler = new HelloServiceHandler();
            TMultiplexedProcessor processor = new TMultiplexedProcessor();
            processor.RegisterProcessor(nameof(helloService),
                new helloService.AsyncProcessor(helloServiceHandler));

            app.UseMiddleware<THttpServerTransport>(processor, new TCompactProtocol.Factory());

        }
    }
}
