using DataStructures.Library;

namespace DataStructures.Tests;

public class SortedListTests
{
    [Fact]
    public void InitializeEmptyTest()
    {
        SortedList<int> ints = new SortedList<int>();
        Assert.Equal(0, ints.Count);
    }
    
    [Fact]
    public void AddTest()
    {
        SortedList<int> ints = new SortedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            ints.Add(i);
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
        SortedList<int> delete1to10 = create(1, 10);
        Assert.Equal(10, delete1to10.Count);
    
        for (int i = 1; i <= 10; i++)
        {
            Assert.True(delete1to10.Remove(i));
            Assert.False(delete1to10.Remove(i));
        }
    
        Assert.Equal(0, delete1to10.Count);
    
        SortedList<int> delete10to1 = create(1, 10);
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
        SortedList<int> ints = create(1, 10);
        for (int i = 1; i <= 10; i++)
        {
            Assert.True(ints.Contains(i));
        }
    
        Assert.False(ints.Contains(0));
        Assert.False(ints.Contains(11));
    }
    
    [Fact]
    public void ReverseIteratorTest()
    {
        SortedList<int> ints = create(1, 10);
        int expected = 10;
        foreach(int actual in ints.GetReverseEnumerator())
        {
            Assert.Equal(expected--, actual);
        }
    }
    
    [Fact]
    public void RandomIsSorted()
    {
        SortedList<int> randoms = new SortedList<int>();
        Random rng = new Random();
        for(int i =0; i < 100; i++)
        {
            randoms.Add(rng.Next());
        }
    
        Assert.Equal(100, randoms.Count);
    
        int prev = int.MinValue;
        foreach(int c in randoms)
        {
            Assert.True(prev <= c, "Sort order is wrong");
        }
    }
    
    private SortedList<int> create(int start, int end)
    {
        SortedList<int> ints = new SortedList<int>();
        for (int i = start; i <= end; i++)
        {
            ints.Add(i);
        }
    
        return ints;
    }
}