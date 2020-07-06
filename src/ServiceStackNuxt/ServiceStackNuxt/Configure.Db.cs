using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace ServiceStackNuxt
{
    public class MyTable
    {
        [AutoIncrement]
        public int Id { get; set; }        
        public string Name { get; set; }
    }
        
    public class ConfigureDb : IConfigureServices, IConfigureAppHost
    {
        IConfiguration Configuration { get; }
        public ConfigureDb(IConfiguration configuration) => Configuration = configuration;

        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                Configuration.GetConnectionString("DefaultConnection")
                    ?? "northwind.sqlite",
                SqliteDialect.Provider));

            services.AddSingleton<ICrudEvents>(c =>
                new OrmLiteCrudEvents(c.Resolve<IDbConnectionFactory>()) {
                    // NamedConnections = { SystemDatabases.Reporting }
                });

            OrmLiteConfig.BeforeExecFilter = dbCmd => Console.WriteLine(dbCmd.GetDebugString());
        }

        public void Configure(IAppHost appHost)
        {
            appHost.GetPlugin<SharpPagesFeature>()?.ScriptMethods.Add(new DbScriptsAsync());

            appHost.Resolve<ICrudEvents>().InitSchema();

            using (var db = appHost.Resolve<IDbConnectionFactory>().Open())
            {
                if (db.CreateTableIfNotExists<MyTable>())
                {
                    db.Insert(new MyTable { Name = "Seed Data for new MyTable" });
                }
            }
        }
    }
}
