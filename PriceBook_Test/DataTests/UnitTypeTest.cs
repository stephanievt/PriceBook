using PriceBook_Data;
using SgUtil;

namespace PriceBook_Test.DataTests;

[TestClass]
public class UnitTypeTest
{
    [TestMethod]
    public void UnitTypeCrud()
    {
        const string nameOne = "Unit name 1";
        const string nameUpdated = "Unit name 2";

        int id;
        bool success;

        // Create
        PriceBook_Data.UnitType create = new PriceBook_Data.UnitType()
        {
            Name = nameOne
        };
        create.Add();
        id = create.Id;

        // Read
        PriceBook_Data.UnitType readAndUpdate = new PriceBook_Data.UnitType(id);
        success = readAndUpdate.Equals(create);
        Assert.IsTrue(success);
        

        // Update
        readAndUpdate.Name = nameUpdated;
        readAndUpdate.SaveUpdate();
        PriceBook_Data.UnitType readAndDelete = new PriceBook_Data.UnitType(nameUpdated);
        success = readAndDelete.Equals(readAndUpdate);
        Assert.IsTrue(success);

        // Delete
        readAndDelete.Delete();
        PriceBook_Data.UnitType notInDb = new PriceBook_Data.UnitType(id);
        success = !notInDb.IsAttached;
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void UnitTypeInequality()
    {
        PriceBook_Data.UnitType baseline = new PriceBook_Data.UnitType
        {
            Name = "Weight",
            Id = 1
        };

        PriceBook_Data.UnitType unequalByName = new PriceBook_Data.UnitType()
        {
            Name = "Height",
            Id = 1
        };

        PriceBook_Data.UnitType unequalById = new PriceBook_Data.UnitType()
        {
            Name = "Weight",
            Id = 2
        };

        bool success = !baseline.Equals(unequalByName);
        Assert.IsTrue(success);

        success = !baseline.Equals(unequalById);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void UnitTypeUnattached()
    {
        const string testName = "This is a dumb name";
        const int testId = Int32.MaxValue;


        PriceBook_Data.UnitType one = new PriceBook_Data.UnitType(testName);
        Assert.AreEqual(one.Id, 0);
        Assert.AreEqual(one.Name, null);
        Assert.IsFalse(one.IsAttached);

        PriceBook_Data.UnitType two = new PriceBook_Data.UnitType(testId);
        Assert.AreEqual(two.Id, 0);
        Assert.AreEqual(two.Name, null);
        Assert.IsFalse(two.IsAttached);
    }


    [TestMethod]
    public void GetAllUnitsInType()
    {
        UnitType us = GetRandomUnitTypeForTest();
        Units units = new Units(us);
        Assert.IsTrue(units.Count > 0);

    }


    private UnitType GetRandomUnitTypeForTest()
    {
        UnitTypes uts = new UnitTypes(true);
        int index = WorkerResources.GetRandomNumber(uts.Count - 1, true);

        return uts[index];

    }

}
