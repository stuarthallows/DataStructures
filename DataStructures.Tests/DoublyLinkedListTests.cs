using DataStructures.Library;

namespace DataStructures.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void InitializeEmptyTest()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var values = new DoublyLinkedList<int>();
        Assert.Empty(values);
    }
    
    [Fact]
    public void AddHeadTest()
    {
        var values = new DoublyLinkedList<int>();
        for (var i = 1; i <= 5; i++)
        {
            values.AddHead(i);
            Assert.Equal(i, values.Count);
        }
    
        var expected = 5;
        foreach (var x in values)
        {
            Assert.Equal(expected--, x);
        }
    }
    
    [Fact]
    public void AddTailTest()
    {
        var values = new DoublyLinkedList<int>();
        for (var i = 1; i <= 5; i++)
        {
            values.AddTail(i);
            Assert.Equal(i, values.Count);
        }
    
        var expected = 1;
        foreach (var x in values)
        {
            Assert.Equal(expected++, x);
        }
    }
    
    [Fact]
    public void RemoveTest()
    {
        var delete1To10 = Create(1, 10);
        Assert.Equal(10, delete1To10.Count);
    
        for (var i = 1; i <= 10; i++)
        {
            Assert.True(delete1To10.Remove(i));
            Assert.False(delete1To10.Remove(i));
        }
    
        Assert.Empty(delete1To10);
    
        var delete10To1 = Create(1, 10);
        Assert.Equal(10, delete10To1.Count);
    
        for (var i = 10; i >= 1; i--)
        {
            Assert.True(delete10To1.Remove(i));
            Assert.False(delete10To1.Remove(i));
        }
    
        Assert.Empty(delete10To1);
    }
    
    [Fact]
    public void RemoveMiddle()
    {
        var values = Create(1, 10);
        values.Remove(5);
    
        Assert.Equal(9, values.Count);
        Assert.Contains(4, values);
        Assert.DoesNotContain(5, values);
        Assert.Contains(6, values);
    
        AssertArraysSame(values.ToArray(), [1, 2, 3, 4, 6, 7, 8, 9, 10]);
    }
    
    [Fact]
    public void ContainsTest()
    {
        var values = Create(1, 10);
        for (var i = 1; i <= 10; i++)
        {
            Assert.Contains(i, values);
        }
    
        Assert.DoesNotContain(0, values);
        Assert.DoesNotContain(11, values);
    }
    
    [Fact]
    public void ReverseIteratorTest()
    {
        var values = Create(1, 10);
        var expected = 10;
        foreach(var actual in values.GetReverseEnumerator())
        {
            Assert.Equal(expected--, actual);
        }
    }
    
    private static DoublyLinkedList<int> Create(int start, int end)
    {
        var values = new DoublyLinkedList<int>();
        for (var i = start; i <= end; i++)
        {
            values.AddTail(i);
        }
    
        return values;
    }
    
    private static void AssertArraysSame(int[] actual, int[] expected)
    {
        Assert.Equal(expected.Length, actual.Length);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}