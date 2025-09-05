namespace PriceBook_Data;

public interface ICategories
{
    int Count { get; }
    Category this[int i] { get; }
    IEnumerator<Category> GetEnumerator();
    List<Category> ToList();
    Category[] ToArray();
}