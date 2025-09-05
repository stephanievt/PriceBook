using System.Text.Json;
using PriceBook_Api;
using PriceBook_Data;

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

        [Test]
        public void Test2()
        {
            PriceBookDataConfig cfg = new PriceBookDataConfig();
            cfg.ConnectionString = "ConnectionString, Server=NA1CTXUSERDEV04\\SQLEXPRESS;Database=PriceBook;TrustServerCertificate=True;Trusted_Connection=True";
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true; // For pretty printing
            string output = JsonSerializer.Serialize(cfg, options);
            Console.WriteLine(output);

        }
    }
}