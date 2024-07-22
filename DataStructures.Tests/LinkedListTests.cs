namespace DataStructures.Tests;

public class LinkedListTests
{
    [Fact]
    public void InitializeEmptyTest()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var values = new Library.LinkedList<int>();
        Assert.Empty(values);
    }
    
    [Fact]
    public void AddHeadTest()
    {
        var values = new Library.LinkedList<int>();
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
        var values = new Library.LinkedList<int>();
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
    
    private static Library.LinkedList<int> Create(int start, int end)
    {
        var values = new Library.LinkedList<int>();
        for (var i = start; i <= end; i++)
        {
            values.AddTail(i);
        }
    
        return values;
    }
}