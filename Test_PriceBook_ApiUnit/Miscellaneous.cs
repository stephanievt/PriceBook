using System.Text.Json;
using PriceBook_Api;

namespace Test_PriceBook_ApiUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            PriceBookApiConfig cfg = new PriceBookApiConfig();
            cfg.ServiceUrlBase = "https://api.example.com";
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true; // For pretty printing
            string outPut = JsonSerializer.Serialize(cfg, options);
            Console.WriteLine(outPut);
        }
    }
}