using System;

namespace ArrayCRUD
{
    public class IntArray
    {
        private readonly int initialLength = 4;
        private int[] arr;
        private int countFromZero;

        public IntArray() => arr = new int[initialLength];

        public int Count { get; private set; }

        public int InitialLength1 => initialLength;

        public int this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public void ResizeArray()
        {
            const int doubleSize = 2;
            if (countFromZero != arr.Length)
            {
                return;
            }

            Array.Resize(ref arr, countFromZero * doubleSize);
        }

        public void Add(int element)
        {
            ResizeArray();
            Count = arr.Length;
            arr[countFromZero] = element;
            countFromZero++;
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
            ResizeArray();
            ShiftRight(index);
            arr[index] = element;
            countFromZero++;
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
            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i + 1] = arr[i];
            }
        }
    }
}
