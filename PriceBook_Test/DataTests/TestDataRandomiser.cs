using PriceBook_Data;
using SgUtil;

namespace PriceBook_Test.DataTests
{
    /// <summary>
    /// This class is used in TESTS to get an desired entity for the test only when
    /// The value of the entity is not relevant.
    /// I like his so that I do not need to ensure that specific data is present to test.
    /// </summary>
    public class TestDataRandomiser
    {
        internal Category GetRandomCategoryForTest()
        {
            Categories categories = new Categories();
            int categorySelectIndex = WorkerResources.GetRandomNumber(categories.Count - 1, true);

            return categories[categorySelectIndex];
        }

        internal Item GetItemRandom()
        {
            Items items = new Items();
            int index = WorkerResources.GetRandomNumber(items.Count, true);
            return items[index];
        }

        internal Store GetStoreRandom()
        {
            Stores stores = new Stores(true);
            int index = WorkerResources.GetRandomNumber(stores.Count, true);
            return stores[index];
        }

        internal Unit GetUnitRandom()
        {
            Units units = new Units(true);
            int index = WorkerResources.GetRandomNumber(units.Count, true);
            return units[index];
        }

        internal Category GetCategoryRandom()
        {
            Categories cats = new Categories();
            int index = WorkerResources.GetRandomNumber(cats.Count, true);
            return cats[index];
        }
    }
}
