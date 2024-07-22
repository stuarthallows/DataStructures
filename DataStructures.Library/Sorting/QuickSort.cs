namespace DataStructures.Library.Sorting;

public class QuickSort<T> : SortingMetrics<T> where T : IComparable
{
    private readonly Random _pivotRng = new Random();
    
    public override T[] MetricSort(T[] items)
    {
        return Quicksort(items, 0, items.Length - 1);
    }

    private T[] Quicksort(T[] items, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = _pivotRng.Next(left, right);
            int newPivot = Partition(items, left, right, pivotIndex);

            Quicksort(items, left, newPivot - 1);
            Quicksort(items, newPivot + 1, right);
        }

        return items;
    }

    private int Partition(T[] items, int left, int right, int pivotIndex)
    {
        T pivotValue = items[pivotIndex];

        Swap(items, pivotIndex, right);

        int storeIndex = left;

        for (int i = left; i < right; i++)
        {
            if (Compare(items[i], pivotValue) < 0)
            {
                Swap(items, i, storeIndex);
                storeIndex += 1;
            }
        }

        Swap(items, storeIndex, right);
        return storeIndex;
    }
}