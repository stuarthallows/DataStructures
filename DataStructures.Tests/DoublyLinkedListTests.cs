using DataStructures.Library;

namespace DataStructures.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void InitalizeEmptyTest()
    {
        DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
        Assert.Empty(ints);
    }
    
    [Fact]
    public void AddHeadTest()
    {
        DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            ints.AddHead(i);
            Assert.Equal(i, ints.Count);
        }
    
        int expected = 5;
        foreach (int x in ints)
        {
            Assert.Equal(expected--, x);
        }
    }
    
    [Fact]
    public void AddTailTest()
    {
        DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            ints.AddTail(i);
            Assert.Equal(i, ints.Count);
        }
    
        int expected = 1;
        foreach (int x in ints)
        {
            Assert.Equal(expected++, x);
        }
    }
    
    [Fact]
    public void RemoveTest()
    {
        DoublyLinkedList<int> delete1to10 = Create(1, 10);
        Assert.Equal(10, delete1to10.Count);
    
        for (int i = 1; i <= 10; i++)
        {
            Assert.True(delete1to10.Remove(i));
            Assert.False(delete1to10.Remove(i));
        }
    
        Assert.Equal(0, delete1to10.Count);
    
        DoublyLinkedList<int> delete10to1 = Create(1, 10);
        Assert.Equal(10, delete10to1.Count);
    
        for (int i = 10; i >= 1; i--)
        {
            Assert.True(delete10to1.Remove(i));
            Assert.False(delete10to1.Remove(i));
        }
    
        Assert.Equal(0, delete10to1.Count);
    }
    
    [Fact]
    public void RemoveMiddle()
    {
        DoublyLinkedList<int> del = Create(1, 10);
        del.Remove(5);
    
        Assert.Equal(9, del.Count);
        Assert.Contains(4, del);
        Assert.DoesNotContain(5, del);
        Assert.Contains(6, del);
    
        AssertArraysSame(del.ToArray(), [1, 2, 3, 4, 6, 7, 8, 9, 10]);
    }
    
    [Fact]
    public void ContainsTest()
    {
        DoublyLinkedList<int> ints = Create(1, 10);
        for (int i = 1; i <= 10; i++)
        {
            Assert.Contains(i, ints);
        }
    
        Assert.DoesNotContain(0, ints);
        Assert.DoesNotContain(11, ints);
    }
    
    [Fact]
    public void ReverseIteratorTest()
    {
        DoublyLinkedList<int> ints = Create(1, 10);
        int expected = 10;
        foreach(int actual in ints.GetReverseEnumerator())
        {
            Assert.Equal(expected--, actual);
        }
    }
    
    private static DoublyLinkedList<int> Create(int start, int end)
    {
        DoublyLinkedList<int> ints = new DoublyLinkedList<int>();
        for (int i = start; i <= end; i++)
        {
            ints.AddTail(i);
        }
    
        return ints;
    }
    
    private void AssertArraysSame(int[] actual, int[] expected)
    {
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}