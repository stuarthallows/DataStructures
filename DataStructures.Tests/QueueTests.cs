namespace DataStructures.Tests;

public class QueueTests
{
    [Fact]
    public void Queue_EnqueueDequeue1to10()
    {
        var queue = new Library.Queue<int>();
    
        for(var i = 0; i < 10; i++)
        {
            queue.Enqueue(i);
        }
    
        Assert.Equal(10, queue.Count);
    
        for(var expected = 0; expected < 10; expected++)
        {
            Assert.Equal(expected, queue.Peek());
            Assert.Equal(expected, queue.Dequeue());
        }
    
        Assert.Equal(0, queue.Count);
    }
}