namespace DataStructures.Library.Sorting;

public class InsertionSort<T> : SortingMetrics<T> where T: IComparable
{
    public override T[] MetricSort(T[] data)
    {
        for(var i = 1; i < data.Length; i++)
        {
            if(LessThan(data, i, i-1))
            {
                for(var p = i; p > 0; p--)
                {
                    if(LessThan(data, p, p-1))
                    {
                        Swap(data, p, p - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return data;
    }
}