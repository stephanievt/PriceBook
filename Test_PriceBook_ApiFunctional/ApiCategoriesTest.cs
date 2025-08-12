//using static RestAssuredNet.RestAssuredNet;
//namespace Test_PriceBook_ApiFunctional
//{
//    public class Tests
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void Test1()
//        {
//            Assert.Pass();
//        }
//        [Test]
//        public void CheckResponseStatusCodeAndJsonResponseBodyElementValue()
//        {
//            Given()
//                .When()
//                .Get("http://api.zippopotam.us/us/90210")
//                .Then()
//                .AssertThat()
//                .StatusCode(200)
//                .And()
//                .Body("$.places[0].state", NHamcrest.Is.EqualTo("California"));
//        }
//    }
//}