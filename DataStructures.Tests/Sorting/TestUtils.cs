namespace DataStructures.Tests.Sorting;

public class TestUtils
{
    [Fact]
    public void SortCheckWorks()
    {
        DemandSorted([]);
        DemandSorted([1]);
        DemandSorted([1, 2]);
        DemandSorted([1, 2, 3]);
        DemandSorted([1, 2, 3, 4, 5]);
        Assert.False(CheckSorted([1, 2, 3, 5, 4]));
        Assert.False(CheckSorted([2, 1, 3, 4, 5]));
        Assert.False(CheckSorted([1, 2, 4, 3, 5]));
        Assert.True(CheckSorted([1, 2, 3, 4, 5]));
    }

    private static bool CheckSorted(int[] data, bool assert = false)
    {
        if (data.Length <= 1) return true;
        for (var i = 1; i < data.Length; i++)
        {
            if (data[i - 1] > data[i])
            {
                if (assert)
                {
                    Assert.True(data[i - 1] < data[i],
                        $"Sorting Error: {data[i - 1]} <= {data[i]} (indexes {i - 1}, {i}");
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }

    internal static void DemandSorted(int[] data)
    {
        CheckSorted(data, true);
    }
}