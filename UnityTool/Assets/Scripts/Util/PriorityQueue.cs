using System;
using System.Collections.Generic;

namespace Mignon.Util
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T>     heap    = new List<T>();
        public int          Count   => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            HeapifyUp();
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Priority queue is empty");

            T frontItem = heap[0];
            int lastItemIndex = Count - 1;
            heap[0] = heap[lastItemIndex];
            heap.RemoveAt(lastItemIndex);

            if (Count > 1)
                HeapifyDown();

            return frontItem;
        }

        private void HeapifyUp()
        {
            int childIndex = Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (heap[childIndex].CompareTo(heap[parentIndex]) >= 0)
                    break;

                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        private void HeapifyDown()
        {
            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;
                int smallestChildIndex = currentIndex;

                if (leftChildIndex < Count && heap[leftChildIndex].CompareTo(heap[smallestChildIndex]) < 0)
                    smallestChildIndex = leftChildIndex;

                if (rightChildIndex < Count && heap[rightChildIndex].CompareTo(heap[smallestChildIndex]) < 0)
                    smallestChildIndex = rightChildIndex;

                if (smallestChildIndex == currentIndex)
                    break;

                Swap(currentIndex, smallestChildIndex);
                currentIndex = smallestChildIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}