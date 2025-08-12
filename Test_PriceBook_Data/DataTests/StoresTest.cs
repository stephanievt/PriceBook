using PriceBook_Data;

namespace PriceBook_Test.DataTests;

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
    public void StoresFromDB()
    {
        Stores stores = new Stores(true);
        Assert.IsTrue(stores.Count > 0);
        TestContext.WriteLine(stores.ToString());
    }
}
