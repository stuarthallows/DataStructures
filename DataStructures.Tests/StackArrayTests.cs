using DataStructures.Library;

namespace DataStructures.Tests;

public class StackArrayTests
{
    [Fact]
    public void Stack_Success_Cases()
    {
        foreach (int[] testData in GetTestData())
        {
            var stack = new StackArray<int>();
    
            for (var i = 0; i < testData.Length; i++)
            {
                Assert.Equal(stack.Count, i);
    
                stack.Push(testData[i]);
    
                Assert.Equal(stack.Count, i + 1);
    
                Assert.Equal(testData[i], stack.Peek());
    
                var counter = i;
                foreach (var value in stack)
                {
                    Assert.Equal(testData[counter], value);
                    counter--;
                }
            }
    
            Assert.Equal(testData.Length, stack.Count);
    
            for (var i = testData.Length - 1; i >= 0; i--)
            {
                var expected = testData[i];
                Assert.Equal(expected, stack.Peek());
                Assert.Equal(expected, stack.Pop());
                Assert.Equal(i, stack.Count);
            }
        }
    }
    
    [Fact]
    public void Clear_Success_Cases()
    {
        foreach (int[] testData in GetTestData())
        {
            var s = new StackArray<int>();
    
            foreach (var i in testData)
            {
                s.Push(i);
            }
    
            Assert.Equal(testData.Length, s.Count);
    
            s.Clear();
    
            Assert.Equal(0, s.Count);
    
            foreach (var missing in s)
            {
                Assert.Fail("There should be nothing in the list");
            }
        }
    }
    
    [Fact]
    public void Pop_From_Empty_Throws()
    {
        var s = new StackArray<int>();
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
    
    [Fact]
    public void Pop_From_Empty_Throws_After_Push()
    {
        var s = new StackArray<int>();
        s.Push(1);
        s.Pop();
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
    
    [Fact]
    public void Peek_From_Empty_Throws()
    {
        var s = new StackArray<int>();
        Assert.Throws<InvalidOperationException>(() => s.Peek());
    }
    
    [Fact]
    public void Peek_From_Empty_Throws_After_Push()
    {
        var s = new StackArray<int>();
        s.Push(1);
        s.Pop();
        Assert.Throws<InvalidOperationException>(() => s.Peek());
    }

    private static object[] GetTestData()
    {
        object[] testData =
        [
            Array.Empty<int>(),
            new [] { 0 },
            new [] { 0, 1 },
            new [] { 0, 1, 2 },
            new [] { 0, 1, 2, 3 },
            new [] { 0, 1, 2, 3, 4 },
            new [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }
        ];

        return testData;
    }
}