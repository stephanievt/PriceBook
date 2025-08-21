using PriceBook_Data;
using SgUtil;

namespace Test_PriceBook_Data.DataTests;

[TestClass]
public class ItemsTest
{
    [TestMethod]
    public void GetAllItems()
    {
        Items items = new Items();
        Assert.IsTrue(items.Count > 0);
    }

    [TestMethod]
    public void GetAllItemsForCategory()
    {
        // Configure
        // Get a category for its id.
        TestDataRandomiser rando = new TestDataRandomiser();
        Category category = rando.GetCategoryRandom();
        
        // Add one item to category
        Item itemAdd = new Item
        {
            CategoryId = category.Id,
            Name = WorkerResources.GetRandomString(10),
        };
        itemAdd.Add();

        // Act
        Items items = new Items(category.Id);

        // Assert
        Assert.IsTrue(items.Count > 0);


    }
}
