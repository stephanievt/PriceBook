using PriceBook_Data;

namespace PriceBook_Tests
{
    [TestClass]
    public class TestData
    {
        TestContext TestContext { get; set; }
        
        [TestMethod]
        public void CategoryCrud()
        {
            const string categoryName = "Some category name";
            const string categoryNameUpdated = "New category name";
            
            // Add category
            Category catAdd = new Category
            {
                Name = categoryName
            };
            catAdd.Add();

            int catId = catAdd.Id;

            // Get category and confirm values.
            Category catGetUpdate = new Category(catId);
            bool success = catGetUpdate.Equals(catAdd);
            success = success && catGetUpdate.Name == categoryName;
            Assert.IsTrue(success);

            // Update category Name
            catGetUpdate.Name = categoryNameUpdated;
            catGetUpdate.SaveUpdate();

            Category catCheckUpdate = new Category(catGetUpdate.Id);
            success = catCheckUpdate.Equals(catGetUpdate) && catCheckUpdate.Name == categoryNameUpdated;
            Assert.IsTrue(success);

            Category catDelete = new Category(catId);
            catDelete.Delete();

        }

        [TestMethod]
        public void GetAllCategories()
        {
            Categories cats = new Categories(true);
            Assert.IsTrue(cats.Count > 0);
            foreach (var cat in cats)
            {
                TestContext.WriteLine(cat.Id.ToString() + ": " + cat.Name);
            }
        }

        [TestMethod]
        public void CategoryNameUnique()
        {
            const string catName = "Dairy";
            Category cat = new Category
            {
                Name = catName
            };
            try
            {
                cat.Add();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                string errorMsg =
                    "Cannot insert duplicate key row in object 'dbo.Categories' with unique index 'IX_Categories_Name'.The duplicate key value is (Dairy).";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (e.InnerException.Message == errorMsg)  Assert.IsTrue(true); // asserting exception is correctly thrown.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
              
            }
        }

        [TestMethod]
        public void StoreCrud()
        {
            // create store
            Store store = new Store
            {
                Name = "Star Market",
                Address = "Mt Auburn St.",
                City = "Cambridge",
                State = "MA"
            };
            store.Add();
            int storeId = store.Id;

            // read
            Store getandUpdateStore = new Store(storeId);
            bool success = getandUpdateStore.Equals(store);
            Assert.IsTrue(success, "Store data retrieved after add and read does not match added data.");

            // update
            getandUpdateStore.City = "Waltham";
            getandUpdateStore.SaveUpdate();
            Store updatedStore = new Store(storeId);
            success = updatedStore.Equals(getandUpdateStore);
            Assert.IsTrue(success, "Store data retrieved after update and read does not match added data.");


            // delete
            Store storeDelete = new Store(storeId);
            storeDelete.Delete();

        }
    }
}
