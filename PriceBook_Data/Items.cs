using System.Collections;

namespace PriceBook_Data
{
    public class Items : IEnumerable<Item>
    {

        private readonly List<Item> _items;

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int Count => _items.Count;

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public Item this[int i] => _items[i];

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Items()
        {
            using (ApplicationContext context = new ApplicationContext())
            {

                _items = context.Item.ToList();

            }
            
        }

        public Items(int catId)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                _items = context.Item.Where(i => i.CategoryId == catId).ToList();
            }
        }
    }
}
