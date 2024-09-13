using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalStation.Service.Core.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-2.1
            CreateWebHostBuilder(args).Build().Run();
            //CreateWebHostBuilder(args).Build().RunAsService();
        }
        //
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return WebHost.CreateDefaultBuilder(args)
                   .UseContentRoot(pathToContentRoot)
                   .UseStartup<Startup>()
                   .UseUrls("http://localhost:61234/");
        }
    }
}
