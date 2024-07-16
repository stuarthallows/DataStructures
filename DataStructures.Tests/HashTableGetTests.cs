using DataStructures.Library;

namespace DataStructures.Tests;

public class HashTableGetTests
{
    [Fact]
    public void Get_From_Empty()
    {
        var table = new HashTable<string, int>();
        Assert.Throws<ArgumentException>(() => table["missing"]);
    }
    
    [Fact]
    public void Get_Missing()
    {
        var table = new HashTable<string, int>();
        table.Add("100", 100);
    
        Assert.Throws<ArgumentException>(() => table["missing"]);
    }
    
    [Fact]
    public void Get_Succeeds()
    {
        var table = new HashTable<string, int>();
        table.Add("100", 100);
    
        var value = table["100"];
        Assert.Equal(100, value);
    
        for (var i = 0; i < 100; i++)
        {
            table.Add(i.ToString(), i);
    
            value = table["100"];
            Assert.Equal(100, value);
        }
    }
    
    [Fact]
    public void TryGet_From_Empty()
    {
        var table = new HashTable<string, int>();
        int value;
    
        Assert.False(table.TryGetValue("missing", out value));
    }
    
    [Fact]
    public void TryGet_Missing()
    {
        var table = new HashTable<string, int>();
        table.Add("100", 100);
    
        int value;
        Assert.False(table.TryGetValue("missing", out value));
    }
    
    [Fact]
    public void TryGet_Succeeds()
    {
        var table = new HashTable<string, int>();
        table.Add("100", 100);
    
        int value;
        Assert.True(table.TryGetValue("100", out value));
        Assert.Equal(100, value);
    
        for (var i = 0; i < 100; i++)
        {
            table.Add(i.ToString(), i);
    
            Assert.True(table.TryGetValue("100", out value));
            Assert.Equal(100, value);
        }
    }
}