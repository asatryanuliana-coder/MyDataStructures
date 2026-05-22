namespace MyBubbleSortProj
{
    public class MergeSort<T> where T : IComparable<T>    
    {
        public void Sort(T[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }
            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            Sort(left);
            Sort(right);
            Merge(items, left, right);
        
        }

        private void Merge(T[] array, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;

            int remaining = left.Length + right.Length;

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                    Assign(array, targetIndex, right[rightIndex++]);
                else if (rightIndex >= right.Length)
                    Assign(array, targetIndex, left[leftIndex++]);
                else if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    Assign(array, targetIndex, left[leftIndex++]);
                else
                    Assign(array, targetIndex, right[rightIndex++]);

                targetIndex++;
                remaining--;
            }
        }
        public void Assign(T[] array, int index, T value)
        {
            array[index] = value;
        }

    }
}
