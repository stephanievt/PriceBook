using PriceBook_Data;
using SgUtil;

namespace PriceBook_Test.DataTests;

[TestClass]
public class ItemCostRecordTest
{
    /// <summary>
    /// CRUD test is good together as the test has an ADD ACT that works as CONFIGURE to the subsequent edit
    /// and delete of the CONFIGURE - ACT - ASSERT form.
    /// </summary>
    [TestMethod]
    public void ItemCostRecordCrud()
    {
        TestDataRandomiser rando = new TestDataRandomiser();

        decimal startPrice = (decimal)123.98;
        decimal editPrice = (decimal)578.09;

        // Configure an item as data cannot expected to exist
        Category cat = rando.GetCategoryRandom();
        Item item = new Item()
        {
            CategoryId = cat.Id,
            Name = WorkerResources.GetRandomString(15)
        };
        item.Add();

        // ADD
        Store store = rando.GetStoreRandom();
        
        Unit unit = rando.GetUnitRandom();
        ItemCostRecord costRecord = new ItemCostRecord()
        {
            ItemId = item.Id,
            StoreId = store.Id,
            UnitId = unit.Id,
            Price = startPrice,
            Notes = "Added by Unit Test"
        };
        costRecord.Add();

        // EDIT
        ItemCostRecord editCostRecord = new ItemCostRecord(costRecord.Id);
        editCostRecord.Price = editPrice;
        editCostRecord.SaveUpdate();
        Assert.AreEqual(editPrice, editCostRecord.Price);

        // DELETE
        int editId = editCostRecord.Id;
        editCostRecord.Delete();

        ItemCostRecord validate = new ItemCostRecord(editId);
        Assert.IsFalse(validate.Found);
        Assert.AreEqual(validate.Id, 0);


    }



}
