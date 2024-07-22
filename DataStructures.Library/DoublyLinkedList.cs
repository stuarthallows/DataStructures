using System.Collections;

namespace DataStructures.Library;

/// <summary>
/// A node in the LinkedList
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoublyLinkedListNode<T>
{
    /// <summary>
    /// Constructs a new node with the specified value.
    /// </summary>
    public DoublyLinkedListNode(T value)
    {
        Value = value;
    }

    /// <summary>
    /// The node value
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// The next node in the linked list (null if last node)
    /// </summary>
    public DoublyLinkedListNode<T>? Next { get; set; }

    /// <summary>
    /// The previous node in the linked list (null if first node)
    /// </summary>
    public DoublyLinkedListNode<T>? Previous { get; set; }
}

/// <summary>
/// A linked list collection capable of basic operations such as Add, Remove, Find and Enumerate
/// </summary>
public class DoublyLinkedList<T> : ICollection<T>
{
    /// <summary>
    /// The first node in the list or null if empty
    /// </summary>
    private DoublyLinkedListNode<T>? Head
    {
        get;
        set;
    }

    /// <summary>
    /// The last node in the list or null if empty
    /// </summary>
    private DoublyLinkedListNode<T>? Tail
    {
        get;
        set;
    }

    /// <summary>
    /// Adds the specified value to the start of the linked list
    /// </summary>
    /// <param name="value">The value to add to the start of the list</param>
    public void AddHead(T value)
    {
        AddHead(new DoublyLinkedListNode<T>(value));
    }

    /// <summary>
    /// Adds the specified node to the start of the link list
    /// </summary>
    /// <param name="node">The node to add to the start of the list</param>
    private void AddHead(DoublyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Tail = node;
        }
        else
        {
            Head.Previous = node;
            
            // Before: Head -------> 5 <-> 7 -> null
            // After:  Head -> 3 <-> 5 <-> 7 -> null
            node.Next = Head;
        }

        Head = node;
        Count++;
    }

    /// <summary>
    /// Add the value to the end of the list
    /// </summary>
    /// <param name="value">The value to add</param>
    public void AddTail(T value)
    {
        AddTail(new DoublyLinkedListNode<T>(value));
    }

    /// <summary>
    /// Add the node to the end of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    private void AddTail(DoublyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Head = node;
        }
        else
        {
            Tail.Next = node;
            
            // Before: Head -> 3 <-> 5 -> null
            // After:  Head -> 3 <-> 5 <-> 7 -> null
            // 7.Previous = 5
            node.Previous = Tail;
        }

        Tail = node;
        Count++;
    }

    /// <summary>
    /// Removes the first node from the list.
    /// </summary>
    public void RemoveHead()
    {
        if (Count == 0)
        {
            return;
        }
        
        // Before: Head -> 3 <-> 5
        // After:  Head -------> 5

        // Head -> 3 -> null
        // Head ------> null
        Head = Head.Next;

        Count--;

        if (Count == 0)
        {
            Tail = null;
        }
        else
        {
            // 5.Previous was 3, now null
            Head.Previous = null;
        }
    }

    /// <summary>
    /// Removes the last node from the list
    /// </summary>
    public void RemoveTail()
    {
        if (Count == 0)
        {
            return;
        }
        
        // Before: Head --> 3 --> 5 --> 7
        //         Tail = 7
        // After:  Head --> 3 --> 5 --> null
        //         Tail = 5
        Tail = Tail.Previous;

        Count--;

        if (Count == 0)
        {
            Head = null;
        }
        else
        {
            // 5.Next was 7, now null
            Tail.Next = null;
        }
    }

    /// <summary>
    /// The number of items currently in the list
    /// </summary>
    public int Count
    {
        get;
        private set;
    }

    /// <summary>
    /// Adds the specified value to the front of the list
    /// </summary>
    /// <param name="item">The value to add</param>
    public void Add(T item)
    {
        AddHead(item);
    }

    public DoublyLinkedListNode<T>? Find(T item)
    {
        for(var current = Head; current != null; current = current.Next)
        {
            if (current.Value?.Equals(item) ?? false)
            {
                return current;
            }
        }
        
        return null;
    }

    /// <summary>
    /// Returns true if the list contains the specified item,
    /// false otherwise.
    /// </summary>
    /// <param name="item">The item to search for</param>
    /// <returns>True if the item is found, false otherwise.</returns>
    public bool Contains(T item)
    {
        return Find(item) != null;
    }

    /// <summary>
    /// Copies the node values into the specified array.
    /// </summary>
    /// <param name="array">The array to copy the linked list values to</param>
    /// <param name="arrayIndex">The index in the array to start copying at</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        DoublyLinkedListNode<T> current = Head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// True if the collection is readonly, false otherwise.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Removes the first occurence of the item from the list (searching
    /// from Head to Tail).
    /// </summary>
    /// <param name="item">The item to remove</param>
    /// <returns>True if the item was found and removed, false otherwise</returns>
    public bool Remove(T item)
    {
        DoublyLinkedListNode<T>? found = Find(item);
        if (found == null)
        {
            return false;
        }

        DoublyLinkedListNode<T> previous = found.Previous;
        DoublyLinkedListNode<T> next = found.Next;

        if (previous == null)
        {
            // we're removing the head node
            Head = next;
            if(Head != null)
            {
                Head.Previous = null;
            }
        }
        else
        {
            previous.Next = next;
        }

        if(next == null)
        {
            // we're removing the tail
            Tail = previous;
            if(Tail != null)
            {
                Tail.Next = null;
            }
        }
        else
        {
            next.Previous = previous;
        }

        Count--;

        return true;
    }

    /// <summary>
    /// Enumerates over the linked list values from Head to Tail
    /// </summary>
    /// <returns>A Head to Tail enumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for(var current = Head; current != null; current = current.Next)
        {
            yield return current.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
        for(var current = Tail; current != null; current = current.Previous)
        {
            yield return current.Value;
        }
    }

    /// <summary>
    /// Removes all the nodes from the list
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool GetHead(out T value)
    {
        if (Count > 0)
        {
            value = Head.Value;
            return true;
        }

        value = default;
        return false;
    }

    public bool GetTail(out T value)
    {
        if (Count > 0)
        {
            value = Tail.Value;
            return true;
        }

        value = default;
        return false;
    }
}
