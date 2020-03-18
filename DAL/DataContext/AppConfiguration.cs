using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "UI/");
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(path + "appsettings.json");
            var root = builder.Build();
            DbProvider = root.GetSection("DefaultDatabaseProvider").Value;
            DbConnectionString = root.GetSection("DatabaseConnectionStrings:"+this.DbProvider+":DefaultConnection").Value;
        }

        public string DbConnectionString { get; internal set; }
        public string DbProvider { get; internal set; }
    }
}
