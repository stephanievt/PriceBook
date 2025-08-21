using PriceBook_Data;

namespace Test_PriceBook_Data.DataTests;

[TestClass]
public class StoresTest
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void StoresEmpty()
    {

        Stores stores = new Stores();
        Assert.IsTrue(stores.Count == 0);

    }

    [TestMethod]
    public void StoresFromDb()
    {
        Stores stores = new Stores(true);
        Assert.IsTrue(stores.Count > 0);
        TestContext.WriteLine(stores.ToString());
    }
}
