using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Heap
    {
        private readonly int[] _items;
        int _size;

        public Heap(int length)
        {
            _items = new int[length];
        }
        public void Insert(int value)
        {
            if (_size == _items.Length)
                throw new Exception("Invalid Operation");
            //insert into next available spot
            _items[_size++] = value;
            BubbleUp();
        }

       

        public int Remove()
        {
            if (IsEmpty()) throw new Exception("Invalid Operation");

            var root = _items[0];
            _items[0] = _items[--_size];
            _items[_size] = 0;

            int index = 0;

            while (index <= _size && !IsValidParent(index))
            {
                int largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);

                index = largerChildIndex;
            }

            return root;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index)) return index;

            if (!HasRightChild(index)) return LeftChildIndex(index);

            return LeftChild(index) > RightChild(index) ? LeftChildIndex(index) : RightChildIndex(index);
        }
        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)) return true;

            var result = _items[index] >= LeftChild(index);

            if (!HasRightChild(index)) return result;

            result &= _items[index] >= RightChild(index);
            return result;
        }

        private int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return _items[RightChildIndex(index)];
        }
        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private bool IsEmpty()
        {
            return _size == 0;
        }
        private void BubbleUp()
        {
            int currentIndex = _size - 1;

            while (currentIndex > 0 && _items[currentIndex] > _items[GetParent(currentIndex)])
            {
                Swap(currentIndex, GetParent(currentIndex));
                currentIndex = (currentIndex - 1) / 2;
            }
        }

        private int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }
    }
}
