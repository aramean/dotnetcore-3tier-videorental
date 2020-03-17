using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var builder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..", "UI", "appsettings.json"); // Get json file from presentation layer, probably not the correct way to do it!
            builder.AddJsonFile(path);
            var root = builder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            SqlConnectionString = appSetting.Value;
        }

        public string SqlConnectionString { get; internal set; }
    }
}
