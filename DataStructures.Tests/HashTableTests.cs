using DataStructures.Library;

namespace DataStructures.Tests;

public class HashTableTests
{
    private readonly Random _rng = new();

    [Fact]
    public void Add_Unique_Adds()
    {
        var table = new HashTable<string, int>();
        var added = new List<int>();
    
        for (var i = 0; i < 100; i++)
        {
            Assert.Equal(i, table.Count);
    
            var value = _rng.Next();
            var key = value.ToString();
    
            // this ensures we should never throw on Add
            while (table.ContainsKey(key))
            {
                value = _rng.Next();
                key = value.ToString();
            }
    
            table.Add(key, value);
            added.Add(value);
        }
    
        // now make sure all the keys and values are there
        foreach (var value in added)
        {
            Assert.True(table.ContainsKey(value.ToString()), "ContainsKey returned false?");
            Assert.True(table.ContainsValue(value), "ContainsValue returned false?");
    
            var found = table[value.ToString()];
            Assert.Equal(value, found);
        }
    }
    
    [Fact]
    public void Add_Duplicate_Throws()
    {
        var table = new HashTable<string, int>();
        var added = new System.Collections.Generic.List<int>();
    
        for (var i = 0; i < 100; i++)
        {
            Assert.Equal(i, table.Count);
    
            var value = _rng.Next();
            var key = value.ToString();
    
            // this ensure we should never throw on Add
            while (table.ContainsKey(key))
            {
                value = _rng.Next();
                key = value.ToString();
            }
    
            table.Add(key, value);
            added.Add(value);
        }
    
        // now make sure each attempt to re-add throws
        foreach (var value in added)
        {
            try
            {
                table.Add(value.ToString(), value);
                Assert.Fail("The Add operation should have thrown with the duplicate key");
            }
            catch (ArgumentException)
            {
                // correct!
            }
        }
    }
    
    
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
    
    [Fact]
    public void Enumerate_Keys_Empty()
    {
        var table = new HashTable<string, string>();
    
        foreach (var key in table.Keys)
        {
            Assert.Fail("There should be nothing in the Keys collection");
        }
    }
    
    [Fact]
    public void Enumerate_Values_Empty()
    {
        var table = new HashTable<string, string>();
    
        foreach (var key in table.Values)
        {
            Assert.Fail("There should be nothing in the Values collection");
        }
    }
    
    [Fact]
    public void Enumerate_Keys_Populated()
    {
        var table = new HashTable<int, string>();
    
        var keys = new System.Collections.Generic.List<int>();
        for (var i = 0; i < 100; i++)
        {
            var value = _rng.Next();
            while (table.ContainsKey(value))
            {
                value = _rng.Next();
            }
    
            keys.Add(value);
            table.Add(value, value.ToString());
        }
    
        foreach (var key in table.Keys)
        {
            Assert.True(keys.Remove(key), "The key was missing from the keys collection");
        }
    
        Assert.Empty(keys);
    }
    
    [Fact]
    public void Enumerate_Values_Populated()
    {
        var table = new HashTable<int, string>();
    
        var values = new List<string>();
        for (var i = 0; i < 100; i++)
        {
            var value = _rng.Next();
            while (table.ContainsKey(value))
            {
                value = _rng.Next();
            }
    
            values.Add(value.ToString());
            table.Add(value, value.ToString());
        }
    
        foreach (var value in table.Values)
        {
            Assert.True(values.Remove(value), "The key was missing from the values collection");
        }
    
        Assert.Empty(values);
    }
    
    [Fact]
    public void Remove_Empty()
    {
        var table = new HashTable<string, int>();
        Assert.False(table.Remove("missing"), "Remove on an empty collection should return false");
    
    }
    
    [Fact]
    public void Remove_Missing()
    {
        var table = new HashTable<string, int>();
        table.Add("100", 100);
    
        Assert.False(table.Remove("missing"), "Remove on an empty collection should return false");
    }
    
    [Fact]
    public void Remove_Found()
    {
        var table = new HashTable<string, int>();
        for (var i = 0; i < 100; i++)
        {
            table.Add(i.ToString(), i);
        }
    
        for (var i = 0; i < 100; i++)
        {
            Assert.True(table.ContainsKey(i.ToString()), "The key was not found in the collection");
            Assert.True(table.Remove(i.ToString()), "The value was not removed (or remove returned false)");
            Assert.False(table.ContainsKey(i.ToString()), "The key should not have been found in the collection");
        }
    }
    
    [Fact]
    public void Add_NullKey()
    {
        var table = new HashTable<string, string>();
        
        Assert.Throws<ArgumentNullException>(() => table.Add(null, "Should fail"));
    }
    
    [Fact]
    public void Remove_NullKey()
    {
        var table = new HashTable<string, string>();
        Assert.False(table.Remove(null));
    }
}