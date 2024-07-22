namespace DataStructures.Library.Sorting;

public class BubbleSort<T> : SortingMetrics<T> where T : IComparable
{
    public override T[] MetricSort(T[] data)
    {
        bool again;

        do
        {
            again = false;
            for (var i = 1; i < data.Length; i++)
            {
                if (GreaterThan(data, i - 1, i))
                {
                    Swap(data, i - 1, i);
                    again = true;
                }
            }
        } while (again);

        return data;
    }
}