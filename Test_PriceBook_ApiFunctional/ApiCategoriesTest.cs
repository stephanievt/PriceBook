using static RestAssured.Dsl;
namespace Test_PriceBook_ApiFunctional
{ //https://github.com/basdijkstra/rest-assured-net/wiki/Usage-Guide
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void CheckResponseStatusCodeAndJsonResponseBodyElementValue()
        {
            Given()
                .When()
                .Get("http://api.zippopotam.us/us/90210")
                .Then()
                .AssertThat()
                .StatusCode(200)
                .And()
                .Body("$.places[0].state", NHamcrest.Is.EqualTo("California"));
        }
    }
}