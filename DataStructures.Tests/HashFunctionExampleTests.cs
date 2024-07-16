namespace DataStructures.Tests;

public class HashFunctionExampleTests
{
    public uint SDBMHash(string input)
    {
        uint hash = 0;

        foreach (byte ascii in input)
        {
            hash = hash * 65599 + ascii;
        }

        return hash;
    }

    [Fact]
    public void SDBMTests()
    {
        Assert.Equal((uint)849955110, SDBMHash("foo"));
        Assert.Equal((uint)924308646, SDBMHash("oof"));
        Assert.Equal((uint)923718264, SDBMHash("ofo"));
    }
    
    public int StableHash(string input)
    {
        int result = 0;
    
        foreach (byte ascii in input)
        {
            result += ascii;
        }
    
        return result;
    }
    
    [Fact]
    public void StableHashTests()
    {
        Assert.Equal(324, StableHash("foo"));
        Assert.Equal(324, StableHash("oof"));
        Assert.Equal(324, StableHash("ofo"));
    }
    
    
    public ulong Dbj2Hash(string input)
    {
        ulong hash = 5381;
    
        foreach(byte c in input)
        {
            hash = hash * 33 + c;
        }
    
        return hash;
    }
    
    [Fact]
    public void Dbj2HashTests()
    {
        Assert.Equal((ulong)193491849, Dbj2Hash("foo"));
    }
}