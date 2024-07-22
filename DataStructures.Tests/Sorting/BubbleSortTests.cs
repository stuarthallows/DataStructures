using DataStructures.Library.Sorting;

namespace DataStructures.Tests.Sorting;

public class BubbleSortTests
{
    private readonly BaseSortTests<BubbleSort<int>> _test = new BaseSortTests<BubbleSort<int>>();
    private readonly BubbleSort<int> _sorter = new BubbleSort<int>();

    [Fact]
    public void PreSortedTests()
    {
        _test.PreSortedTests(_sorter);
    }

    [Fact]
    public void UnsortedTests()
    {
        _test.UnsortedTests(_sorter);
    }

    [Fact]
    public void RandomTests()
    {
        _test.RandomTests(_sorter);
    }
}