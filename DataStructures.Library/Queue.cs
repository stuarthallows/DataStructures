namespace DataStructures.Library;

/// <summary>
/// First in, first out (FIFO) collection.
/// </summary>
public class Queue<T>
{
    private readonly Deque<T> _store = new();

    public void Enqueue(T value)
    {
        _store.EnqueueTail(value);
    }

    public T Dequeue()
    {
        return _store.DequeueHead();
    }

    public T Peek()
    {
        if(_store.PeekHead(out var value))
        {
            return value;
        }

        throw new InvalidOperationException();
    }

    public int Count => _store.Count;
}