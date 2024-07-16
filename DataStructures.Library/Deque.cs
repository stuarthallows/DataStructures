﻿using System.Collections;

namespace DataStructures.Library;

/// <summary>
/// Double-ended queue.
/// </summary>
public class Deque<T> : IEnumerable<T>
{
    private readonly DoublyLinkedList<T> _store = [];

    public void EnqueueHead(T value)
    {
        _store.AddHead(value);
    }

    public void EnqueueTail(T value)
    {
        _store.AddTail(value);
    }

    public T DequeueHead()
    {
        if(_store.GetHead(out var value))
        {
            _store.RemoveHead();
            return value;
        }

        throw new InvalidOperationException();
    }

    public T DequeueTail()
    {
        if(_store.GetTail(out var value))
        {
            _store.RemoveTail();
            return value;
        }

        throw new InvalidOperationException();
    }

    public bool PeekHead(out T value)
    {
        return _store.GetHead(out value);
    }

    public bool PeekTail(out T value)
    {
        return _store.GetTail(out value);
    }

    public int Count => _store.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return _store.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}