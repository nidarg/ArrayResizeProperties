using System;

namespace ArrayCRUD
{
    public class IntArray
    {
        private int[] arr;

        public IntArray() => arr = new int[InitialLength];

#pragma warning disable RCS1170 // Use read-only auto-implemented property.
        public int InitialLength { get; private set; } = 4;

        public int Count { get; private set; }

        public int CountFromZero { get; private set; }

        public int this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
#pragma warning restore RCS1170 // Use read-only auto-implemented property.

        public void Add(int element)
        {
            const int doubleSize = 2;
            if (CountFromZero == arr.Length)
            {
                Array.Resize(ref arr, CountFromZero * doubleSize);
            }

            Count = arr.Length;
            arr[CountFromZero] = element;
            CountFromZero++;
        }

        public bool Contains(int element)
        {
            foreach (int elem in arr)
            {
                if (elem == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref arr, arr.Length + 1);
            ShiftRight(index);
            arr[index] = element;
            Count = arr.Length;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            int position = this.IndexOf(element);
            RemoveAt(position);
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref arr, arr.Length - 1);
            Count = arr.Length;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = index; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
        }
    }
}
