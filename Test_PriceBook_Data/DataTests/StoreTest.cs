using PriceBook_Data;

namespace PriceBook_Test.DataTests;

[TestClass]
public class StoreTest
{
    [TestMethod]
    public void StoreCrud()
    {
        // Create store
        Store create = new Store()
        {
            Name = "Costco",
            Address = "I have no idea",
            City = "Waltham",
            State = "MA"
        };
        create.Add();
        int id = create.Id;

        // Get by id and compare
        Store getById = new Store(id);
        Assert.IsTrue(getById.Equals(create));

        // Get by name and compare
        Store getByNameandUpdate = new Store(create.Name);
        Assert.IsTrue(getByNameandUpdate.Equals(create));

        // Update store
        getByNameandUpdate.Name = "Ajax Market";
        getByNameandUpdate.City = "Watertown";
        getByNameandUpdate.SaveUpdate();

        // get and compare
        Store updatedCompareDelete = new Store(id);
        Assert.IsTrue(updatedCompareDelete.Equals(getByNameandUpdate));

        // delete store
        updatedCompareDelete.Delete();
        Store final = new Store(id);
        Assert.AreEqual(final.IsAttached, false);

    }

    [TestMethod]
    public void StoreInequality()
    {
        Store first = new Store()
        {
            Id = 10,
            Name = "Name One",
            Address = "One Main Street",
            City = "Manchester",
            State = "NH"
        };

        // id not equal
        Store second = new Store()
        {
            Id = 11,
            Name = "Name One",
            Address = "One Main Street",
            City = "Manchester",
            State = "NH"
        };

        bool success = !second.Equals(first);
        Assert.IsTrue(success); // success means UN equal

        // name
        second = new Store()
        {
            Id = 10,
            Name = "Some other name",
            Address = "One Main Street",
            City = "Manchester",
            State = "NH"
        };
        success = !second.Equals(first);
        Assert.IsTrue(success);

        // address
        second = new Store()
        {
            Id = 10,
            Name = "Name One",
            Address = "blah blah blah",
            City = "Manchester",
            State = "NH"
        };
        success = !second.Equals(first);
        Assert.IsTrue(success);

        // city
        second = new Store()
        {
            Id = 10,
            Name = "Name One",
            Address = "One Main Street",
            City = "Waltham",
            State = "NH"
        };
        success = !second.Equals(first);
        Assert.IsTrue(success);

        // state
        second = new Store()
        {
            Id = 10,
            Name = "Name One",
            Address = "One Main Street",
            City = "Manchester",
            State = "MA"
        };

        success = !second.Equals(first);
        Assert.IsTrue(success);
    }

}
