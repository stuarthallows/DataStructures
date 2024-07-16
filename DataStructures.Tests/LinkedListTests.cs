namespace DataStructures.Tests;

public class LinkedListTests
{
    [Fact]
    public void InitalizeEmptyTest()
    {
        var ints = new Library.LinkedList<int>();
        Assert.Equal(0, ints.Count);
    }
    
    [Fact]
    public void AddHeadTest()
    {
        var ints = new Library.LinkedList<int>();
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
        var ints = new Library.LinkedList<int>();
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
        var delete1to10 = create(1, 10);
        Assert.Equal(10, delete1to10.Count);
    
        for (int i = 1; i <= 10; i++)
        {
            Assert.True(delete1to10.Remove(i));
            Assert.False(delete1to10.Remove(i));
        }
    
        Assert.Equal(0, delete1to10.Count);
    
        var delete10to1 = create(1, 10);
        Assert.Equal(10, delete10to1.Count);
    
        for (int i = 10; i >= 1; i--)
        {
            Assert.True(delete10to1.Remove(i));
            Assert.False(delete10to1.Remove(i));
        }
    
        Assert.Equal(0, delete10to1.Count);
    }
    
    [Fact]
    public void ContainsTest()
    {
        var ints = create(1, 10);
        for (int i = 1; i <= 10; i++)
        {
            Assert.True(ints.Contains(i));
        }
    
        Assert.False(ints.Contains(0));
        Assert.False(ints.Contains(11));
    }
    
    private Library.LinkedList<int> create(int start, int end)
    {
        var ints = new Library.LinkedList<int>();
        for (int i = start; i <= end; i++)
        {
            ints.AddTail(i);
        }
    
        return ints;
    }
}