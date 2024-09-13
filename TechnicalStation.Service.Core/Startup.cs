using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Repository.Hierarchy;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Service.Hub;

namespace TechnicalStation.Service.Core
{
    using System.Diagnostics;
    using System.IO;

    using TechnicalStation.Core.BLL.Contract;
    using TechnicalStation.Core.BLL;
    using TechnicalStation.Service.Core.Hub;
    using TechnicalStation.DAL.MySql;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            //https://stackoverflow.com/questions/42789450/iis-express-asp-net-core-invalid-uri-the-hostname-could-not-be-parsed
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(Path.Combine(pathToContentRoot, "log4net.config")));

            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            ILog log = log4net.LogManager.GetLogger(typeof(Logger));

            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(5);
                hubOptions.ClientTimeoutInterval = TimeSpan.FromMinutes(5);
            });

            string connectionString = ConnectionStringReader.GetConnectionString(databaseName: "Orders", xmlFilePath: Path.Combine(pathToContentRoot, "Configuration/connectionStrings.config"));

            ISqlDataManager sqlDataManager = new SqlDataManager(connectionString);
            IRepositoryFactory repositoryFactory = new RepositoryFactory(sqlDataManager);
            IApplicationServiceFactory serviceFactory = new ApplicationServiceFactory(repositoryFactory);

            services.AddSingleton<ILog>(log);
            services.AddSingleton<IApplicationServiceFactory>(serviceFactory);
            services.AddSingleton<HubEnvironment>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MainHub>("/notes");
            });
        }
    }
}