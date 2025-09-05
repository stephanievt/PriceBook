using System.Diagnostics.CodeAnalysis;

namespace PriceBook_Data
{
    [ExcludeFromCodeCoverage]
    public class PriceBookDataConfig : IPriceBookDataConfig
    {

        public PriceBookDataConfig()
        {
            //string fileName = Environment.CurrentDirectory + "/PriceBookDataConfig.json";
            //string cfgJson = File.ReadAllText(fileName);
            //PriceBookDataConfig cfg = System.Text.Json.JsonSerializer.Deserialize<PriceBookDataConfig>(cfgJson);
            //ConnectionString = cfg.ConnectionString;

        }

        public string ConnectionString { get; set; } = "Server=DESKTOP-BNDNPK0\\SQLEXPRESS;Database=PriceBook;TrustServerCertificate=True;Trusted_Connection=True";

    }
}