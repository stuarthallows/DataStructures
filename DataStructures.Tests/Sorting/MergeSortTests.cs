using DataStructures.Library.Sorting;

namespace DataStructures.Tests.Sorting;

public class MergeSortTests
{
    private readonly BaseSortTests<MergeSort<int>> _test = new BaseSortTests<MergeSort<int>>();
    private readonly MergeSort<int> _sorter = new MergeSort<int>();

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