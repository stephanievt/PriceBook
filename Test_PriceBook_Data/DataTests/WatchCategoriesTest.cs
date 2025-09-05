using PriceBook_Data;

// ReSharper disable RedundantAssignment

namespace Test_PriceBook_Data.DataTests
{

    [TestClass]
    public class WatchWatchCategoriesTest
    {
        
        [TestMethod]
        public void GetAllWatchCategories()
        {
            WatchCategories cats = new WatchCategories();
            Assert.IsTrue(cats.Count > 0);
            foreach (var cat in cats)
            {
                Console.WriteLine(cat.Id.ToString() + ": " + cat.Name);
            }
        }

        [TestMethod]
        public void WatchCategoriesToArray()
        {
            WatchCategories cats = new WatchCategories();

            Category[] catsArray = cats.ToArray();
            Assert.AreEqual(cats.Count, catsArray.Length);
            foreach(var cat in catsArray)
            {
                Console.WriteLine(cat.Id.ToString() + ": " + cat.Name);
            }

        }

        [TestMethod]
        public void Iterating()
        {
            WatchCategories cats = new WatchCategories();

            Assert.IsTrue(cats.Count > 0);
            bool success = true;

            foreach (Category cat in cats)
            {

                if (String.IsNullOrEmpty(cat.Name)) success = false;

            }

            Assert.IsTrue(success);

            int count = cats.Count;
            Category indCat = cats[count - 2];
            success = true;
            if (String.IsNullOrEmpty(indCat.Name)) success = false;
            Assert.IsTrue(success);

            List<Category> catList = cats.ToList();
            success = catList.Count == cats.Count;
            Assert.IsTrue(success);
        }

    }
}
