using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Thrift.Service
{
    class Program
    {
        public static HostBuilderContext HostingContext;
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                        .SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            var config = configBuilder.Build();

            var builder = Host.CreateDefaultBuilder(args)
                         .ConfigureAppConfiguration((context, config) =>
                         {
                             HostingContext = context;
                             config.AddConfiguration(config.Build());
                         })
                         .ConfigureWebHostDefaults(webBuilder =>
                         {
                             var value = config.GetValue<string>("ThriftServiceUrl");
                             webBuilder.UseStartup<StartUp>();
                             webBuilder.UseUrls(value);

                         });
            return builder;
                         
           
        }
    }
}
