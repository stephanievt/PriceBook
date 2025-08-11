using System.Text;

namespace PriceBook_Data
{
    public class Stores 
    {
        private readonly List<Store> _stores = new List<Store>();

        public int Count => _stores.Count;
        public Store this[int i] => _stores[i];


        public Stores(bool getAllFromDb = false)
        {
            if (getAllFromDb)
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    _stores = context.Store.ToList();
                }

                foreach (var store in _stores)
                {
                    store.IsAttached = true;
                }
            }
        }

        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var store in _stores)
            {
                builder.AppendLine(store.ToString());
            }

            return builder.ToString();
        }

    }
}
