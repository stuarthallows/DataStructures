namespace DataStructures.Tests;

public class StackTests
{
    [Fact]
    public void Stack_Success_Cases()
    {
        foreach (int[] testData in GetTestData())
        {
            var stack = new Library.Stack<int>();
    
            for (int i = 0; i < testData.Length; i++)
            {
                Assert.Equal(stack.Count, i);
    
                stack.Push(testData[i]);
    
                Assert.Equal(stack.Count, i + 1);
    
                Assert.Equal(testData[i], stack.Peek());
            }
    
            Assert.Equal(testData.Length, stack.Count);
    
            for (int i = testData.Length - 1; i >= 0; i--)
            {
                int expected = testData[i];
                Assert.Equal(expected, stack.Peek());
                Assert.Equal(expected, stack.Pop());
                Assert.Equal(i, stack.Count);
            }
        }
    }
    
    [Fact]
    public void Pop_From_Empty_Throws()
    {
        var s = new Library.Stack<int>();
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
    
    [Fact]
    public void Pop_From_Empty_Throws_After_Push()
    {
        var s = new Library.Stack<int>();
        s.Push(1);
        s.Pop();
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }
    
    [Fact]
    public void Peek_From_Empty_Throws()
    {
        var s = new Library.Stack<int>();
        Assert.Throws<InvalidOperationException>(() => s.Peek());
    }
    
    [Fact]
    public void Peek_From_Empty_Throws_After_Push()
    {
        var s = new Library.Stack<int>();
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
            new [] { 0, 1, 2, 3, 4 }
        ];

        return testData;
    }
}