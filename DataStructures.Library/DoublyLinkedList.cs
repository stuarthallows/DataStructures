namespace DataStructures.Library;

public class DoubleLinkedListNode<TNode>
{
    public DoubleLinkedListNode(
        TNode value,
        DoubleLinkedListNode<TNode> previous = null,
        DoubleLinkedListNode<TNode> next = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
    
    public DoubleLinkedListNode<TNode> Previous { get; set; }
    public DoubleLinkedListNode<TNode> Next { get; set; }
    public TNode Value { get; set; }
}

public class DoublyLinkedList
{
}