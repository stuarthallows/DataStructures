using DataStructures.Library.Sorting;

namespace DataStructures.Tests.Sorting;

public class InsertionSortTests
{
    private readonly BaseSortTests<InsertionSort<int>> _test = new BaseSortTests<InsertionSort<int>>();
    private readonly InsertionSort<int> _sorter = new InsertionSort<int>();

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