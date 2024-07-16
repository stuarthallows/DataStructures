namespace DataStructures.Library;

/// <summary>
/// Last in, first out (LIFO) collection.
/// </summary>
public class Stack<T>
{
    private readonly Deque<T> _store = new();

    public void Push(T item)
    {
        _store.EnqueueHead(item);
    }

    public T Pop()
    {
        return _store.DequeueHead();
    }

    public T Peek()
    {
        if (_store.PeekHead(out var value))
        {
            return value;
        }

        throw new InvalidOperationException();
    }

    public int Count => _store.Count;
}