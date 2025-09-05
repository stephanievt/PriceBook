using PriceBook_Data;

namespace Test_PriceBook_Data.DataTests;

[TestClass]
public class UnitsTest
{
    [TestMethod]
    public void AddUnitToCollection()
    {

        UnitType unitType = new UnitType("Volume");
        
        Units units = new Units(true);
        int origCount = units.Count;

        Unit unit = new Unit()
        {
            UnitType = unitType,
            Name = "This is a thingy"
        };

        units.Add(unit);
        Assert.AreEqual(units.Count, origCount + 1);

    }


    [TestMethod]
    public void UnitsIsIn()
    {
        Units units = new Units(true);
        int unitCount = units.Count;
        int inId = units[unitCount - 1].Id;

        // is in true
        bool success = units.IsIn(inId);
        Assert.IsTrue(success, "Expected unit not present in collection.");

        // is NOT in
        success = !units.IsIn(50000);
        Assert.IsTrue(success, "Expected unit IS present in collection.");
    }
}
