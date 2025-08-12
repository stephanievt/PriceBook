using PriceBook_Data;
using SgUtil;
// ReSharper disable ReplaceWithSingleAssignment.True

namespace PriceBook_Test.DataTests;

[TestClass]
public class ItemTest
{
    [TestMethod]
    public void AddItem()
    {
        string name = WorkerResources.GetRandomString(10);
        TestDataRandomiser rando = new TestDataRandomiser();


        Item item = new Item
        {
            CategoryId = rando.GetRandomCategoryForTest().Id,
            Name = name
        };
        item.Add();
        
        bool success = true;
        if (item.Id <= 0) success = false;
        if (item.Name != name) success = false;
        
        // retrieve data from db and and assert matches
        Item next = new Item(item.Id);
        if (next.Id != item.Id) success = false;
        if (next.Name != name) success = false;
        if (next.CategoryId != item.CategoryId) success = false;
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void ItemNameUnique()
    {
        // Configure
        // Create new item to ensure name pressence
        TestDataRandomiser rando = new TestDataRandomiser();
        string itemName = WorkerResources.GetRandomString(10);
        Category category = rando.GetRandomCategoryForTest();
        Item first = new Item();
        first.Name = itemName;
        first.CategoryId = category.Id;
        first.SaveUpdate();

        // Do
        // Attempt add same name
        Item test = new Item();
        test.Name = itemName;
        try
        {
            test.SaveUpdate();
        }

        // Assert
        catch (InvalidOperationException ex)
        {

            if (ex.Message == "Duplicate item name.")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false, "Invalid Operation Exception for duplicate name is expected.");
            }
        }
    }


    [TestMethod]
    public void ItemCategory()
    {
        // ACT
        // Create new item to work with category load on save
        string itemName = WorkerResources.GetRandomString(10);
        TestDataRandomiser rando = new TestDataRandomiser();
        Category category = rando.GetRandomCategoryForTest();

        Item item = new Item()
        {
            Name = itemName,
            CategoryId = category.Id
        };
        item.SaveUpdate(true);
        
        // Assert
        // Item category equals original category
        Assert.IsTrue(item.Category.Equals(category));
        

    }

    [TestMethod]
    public void DeleteItem()
    {
        // CONFIGURE
        // create item to delete
        TestDataRandomiser rando = new TestDataRandomiser();
        Category category = rando.GetRandomCategoryForTest();
        Store store = new Store("Star Market");
        Unit unit = new Unit("Gram");

        Item item = new Item()
        {
            CategoryId = category.Id,
            Name = WorkerResources.GetRandomString(9)
        };
        item.Add();
        // Add item cost record (demonstrate functional cascade delete
        ItemCostRecord costRec = new ItemCostRecord()
        {
            ItemId = item.Id,
            StoreId = store.Id,
            UnitId = unit.Id,
            Price = new decimal(10.75)
        };
        costRec.Add();
        
        // ACT
        Item itemToDelete = new Item(item.Id);
        itemToDelete.Delete();

        // ASSERT
        Item itemNotFound = new Item(item.Id);
        Assert.IsFalse(itemNotFound.Found);


    }


}
