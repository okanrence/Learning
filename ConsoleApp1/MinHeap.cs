using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Node
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class MinHeap
    {
        private readonly Node[] _array;
        int _size;

        public MinHeap(int length)
        {
            _array = new Node[length];
        }
        public void Insert(Node node)
        {
            if (_size == _array.Length)
                throw new Exception("Invalid Operation");

            _array[_size++] = node;
            BubbleUp();
        }

        public int Remove()
        {

            if (IsEmpty()) throw new Exception("Invalid Operation");

            Node root = _array[0];
            _array[0] = _array[--_size];
           // _array[_size] = 0;
            BubbleDown();

            return root.Key;
        }
        private bool IsEmpty()
        {
            return _size == 0;
        }
        private void BubbleDown()
        {
            int index = 0;


            while (index <= _size && !IsValidParent(index))
            {
                int smallerIndex = SmallerIndex(index);

                Swap(index, smallerIndex);

                index = smallerIndex;
            }
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)) return true;

            var isValid = _array[index].Key <= LeftChild(index).Key;

            if (!HasRightChild(index)) return isValid;

             isValid &= _array[index].Key <= RightChild(index).Key;
            return isValid;
        } 
        private int SmallerIndex(int index)
        {
            if (!HasLeftChild(index)) return index;

            if (!HasRightChild(index)) return LeftChildIndex(index);

            return LeftChild(index).Key < RightChild(index).Key ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }
        private Node LeftChild(int index)
        {
            return _array[LeftChildIndex(index)];
        }

        private Node RightChild(int index)
        {
            return _array[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
        private void BubbleUp()
        {
            int index = _size - 1;
           
            while (_array[index].Key < _array[GetParentIndex(index)].Key)
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void Swap(int first, int second)
        {
            Node temp = _array[first];
            _array[first] = _array[second];
            _array[second] = temp;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
