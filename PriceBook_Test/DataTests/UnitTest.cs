using PriceBook_Data;

namespace PriceBook_Test.DataTests;

[TestClass]
public class UnitTest
{

    public TestContext TestContext { get; set; }

    [TestMethod]
    public void UnitCrud()
    {
        int unitId;
        string unitName = "lb";
        string unitType = "Weight";
        string unitNameUpdate = "lbs";


        // I do cruds together to create and then DELETE. I am testing data layer and want to test real data.
        // Create
        UnitType weight = new UnitType(unitType);
        Unit unitAdd = new Unit()
        {
            DefaultForType = true,
            Name = unitName,
            UnitType = weight
        };

        unitAdd.Add();
        unitId = unitAdd.Id;
        
        // read
        Unit unitRead = new Unit(unitId);
        Assert.IsTrue(unitRead.Equals(unitAdd));
        TestContext.WriteLine(unitAdd.ToString());

        // update
        unitAdd.Name = unitNameUpdate;
        unitAdd.SaveUpdate();
        
        // read new 
        unitRead = new Unit(unitId);
        Assert.IsTrue(unitRead.Equals(unitAdd));

        // delete
        unitAdd.Delete();

        // Get all units and ensure that deleted is not there.
        Units units = new Units(true);
        Assert.IsFalse(units.IsIn(unitId));
    }

    [TestMethod]
    public void UnitInequality()
    {
        UnitType unitType = new UnitType("Weight");

        Unit unitBase = new Unit()
        {
            Name = "Base",
            UnitType = unitType,
            UnitTypeId = unitType.Id,
            DefaultForType = true
        };

        Unit unitCompare = new Unit()
        {
            Name = "Compare",
            UnitType = unitType,
            UnitTypeId = unitType.Id,
            DefaultForType = true
        };

        // equals false on NAME
        bool notSuccess = unitBase.Equals(unitCompare);
        Assert.IsFalse(notSuccess);


        // equals false default for type
        unitCompare.Name = unitBase.Name;
        unitCompare.DefaultForType = false;
        notSuccess = unitBase.Equals(unitCompare);
        Assert.IsFalse(notSuccess);

        // equal false for unit type Id
        unitCompare.DefaultForType= true;
        unitCompare.UnitTypeId = 2000;
        notSuccess = unitBase.Equals(unitCompare);
        Assert.IsFalse(notSuccess);

        // equal false on id
        unitCompare.UnitTypeId = unitBase.UnitTypeId;
        unitCompare.Id = 2000;
        notSuccess = unitBase.Equals(unitCompare);
        Assert.IsFalse(notSuccess);



    }
}
