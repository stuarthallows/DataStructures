using DataStructures.Library.Sorting;

namespace DataStructures.Tests.Sorting;

public class QuickSortTests
{
    private readonly BaseSortTests<QuickSort<int>> _test = new BaseSortTests<QuickSort<int>>();
    private readonly QuickSort<int> _sorter = new QuickSort<int>();

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

    [Fact]
    public void RandomTests_50k()
    {
        _test.RandomTests(_sorter, 50000);
    }
}