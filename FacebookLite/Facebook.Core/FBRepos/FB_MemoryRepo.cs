using Facebook.Core.FBCommon;

namespace Facebook.Core.FBRepos;

public class FB_MemoryRepo<T> where T : FB_Entity
{
    private readonly Dictionary<string, T> _items = new();

    public void Add(T item)
    {
        _items[item.Id] = item;
    }

    // Null байж болзошгүй гэдгийг заасан
    public T? GetById(string id)
    {
        return _items.TryGetValue(id, out var item) ? item : null;
    }

    public List<T> GetAll()
    {
        return _items.Values.ToList();
    }

    public bool Delete(string id)
    {
        return _items.Remove(id);
    }

    public int Count => _items.Count;
}