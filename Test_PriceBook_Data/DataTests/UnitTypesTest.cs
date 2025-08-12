namespace PriceBook_Test.DataTests;

[TestClass]
public class UnitTypesTest
{
    public TestContext TestContext { get; set; }


    [TestMethod]
    public void UnitTypesCollection()
    {
        PriceBook_Data.UnitTypes types = new PriceBook_Data.UnitTypes(true);
        Assert.IsTrue(types.Count > 0);
        TestContext.WriteLine(types.ToString());

        bool success = true;
        // above passed in retrieve from db. ensure all isattached are true
        foreach (var ut in types)
        {
            if (!ut.IsAttached)
            {
                success = false;
                break;
            } 

        }
        Assert.IsTrue(success, "At least one unit type is not marked ATTACHED despite being retrieved from the DB.");

    }


}
