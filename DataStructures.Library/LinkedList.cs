namespace DataStructures.Library;

public class SingleLinkedListNode<TNode>
{
    public SingleLinkedListNode(TNode value, SingleLinkedListNode<TNode> next = null)
    {
        Value = value;
        Next = next;
    }
    
    public SingleLinkedListNode<TNode> Next { get; set; }
    public TNode Value { get; set; }
}

public class LinkedList
{
    
}