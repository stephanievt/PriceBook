namespace PriceBook_Data
{
    public class PriceBookDataConfig : IPriceBookDataConfig
    {

        public PriceBookDataConfig()
        {
            //TODO: Fix this once the machine has some beef and I figure out how to do this properly.
            //// This is all gonna change. Just need to get unit tests running for now.
            //string fileName = Environment.CurrentDirectory + "/PriceBookDataConfig.json";
            //string cfgJson = File.ReadAllText(fileName);
            //PriceBookDataConfig cfg = System.Text.Json.JsonSerializer.Deserialize<PriceBookDataConfig>(cfgJson);
            //ConnectionString = cfg.ConnectionString;

        }

        public string ConnectionString { get; set; } = "Server=DESKTOP-BNDNPK0\\SQLEXPRESS;Database=PriceBook;TrustServerCertificate=True;Trusted_Connection=True";

    }
}