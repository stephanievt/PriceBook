using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace PriceBook_Data;

public class WatchCategories : IEnumerable<Category>
{
    private readonly List<Category> _cats;

    public WatchCategories()
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            _cats = context.Category.Include(i => i.Items).Where(c => c.Watch).ToList();
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
}