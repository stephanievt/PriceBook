using PriceBook_Data;

// ReSharper disable RedundantAssignment

namespace Test_PriceBook_Data.DataTests
{

    [TestClass]
    public class CategoriesTest
    {
        
        [TestMethod]
        public void GetAllCategories()
        {
            Categories cats = new Categories();
            Assert.IsTrue(cats.Count > 0);
            foreach (var cat in cats)
            {
                Console.WriteLine(cat.Id.ToString() + ": " + cat.Name);
            }
        }

        [TestMethod]
        public void CategoriesToArray()
        {
            Categories cats = new Categories();

            Category[] catsArray = cats.ToArray();
            Assert.AreEqual(cats.Count, catsArray.Length);

            
        }

        [TestMethod]
        public void GetItemsWithCategory()
        {
            Categories cats = new Categories(true);
            bool success = false;
            // At least one category has a non empty item.
            foreach (Category iCat in cats)
            {
                if (iCat.Items == null) continue;
                if (iCat.Items.Count > 0) success = true;
                break;
            }
            Assert.IsTrue(success, "Categories do not appear included.");
        }


        [TestMethod]
        public void Iterating()
        {
            PriceBook_Data.Categories cats = new PriceBook_Data.Categories();

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
