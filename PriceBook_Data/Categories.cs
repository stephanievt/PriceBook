using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data
{
    public class Categories : IEnumerable<Category>
    {

        private readonly List<Category> _cats;


        public Categories(bool includeItems = false)
        {
            using (ApplicationContext context = new ApplicationContext())
            {

                if (includeItems)
                {
                    _cats = context.Category.Include(c => c.Items).ToList();
                }
                else
                {
                    _cats = context.Category.ToList();
                }
                
            }

            foreach (var cat in _cats)
            {
                cat.IsAttached = true;
            }
        }


        public int Count => _cats.Count;

        public Category this[int i] => _cats[i];

        public IEnumerator<Category> GetEnumerator()
        {
            return _cats.GetEnumerator();
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Category> ToList()
        {
            return _cats.ToList();
        }

        public Category[] ToArray()
        {
            return _cats.ToArray();
        }


    }
}
