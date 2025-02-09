﻿namespace DataStructures.Library.Sorting;

public class MergeSort<T> : SortingMetrics<T> where T : IComparable
{
    public override T[] MetricSort(T[] items)
    {
        if (items.Length <= 1)
        {
            return items;
        }

        int leftSize = items.Length / 2;
        int rightSize = items.Length - leftSize;

        T[] left = new T[leftSize];
        T[] right = new T[rightSize];

        Array.Copy(items, 0, left, 0, leftSize);
        Array.Copy(items, leftSize, right, 0, rightSize);

        MetricSort(left);
        MetricSort(right);
        return Merge(items, left, right);
    }

    private T[] Merge(T[] items, T[] left, T[] right)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int targetIndex = 0;

        int remaining = left.Length + right.Length;

        while(remaining > 0)
        {
            if (leftIndex >= left.Length)
            {
                Assign(items, targetIndex, right[rightIndex++]);
            }
            else if (rightIndex >= right.Length)
            {
                Assign(items, targetIndex, left[leftIndex++]);
            }
            else if (Compare(left[leftIndex], right[rightIndex]) < 0)
            {
                Assign(items, targetIndex, left[leftIndex++]);
            }
            else
            {
                Assign(items, targetIndex, right[rightIndex++]);
            }

            targetIndex++;
            remaining--;
        }

        return items;
    }
}