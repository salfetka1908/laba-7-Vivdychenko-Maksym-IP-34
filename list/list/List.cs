using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace list123
{
    public class List
    {
        private Node? head;
        private int size = 0;
        public int Size
        {
            get { return size; }
        }
        public List()
        {
            head = null;
        }
        public List(params short[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                AddValue(nums[i]);
            }
        }
        public void AddValue(short value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node? current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(value);
            }
            size++;
        }
        public void RemoveValueByIndex(int position)
        {
            if(position < 0 || position >= size)
            {
                throw new IndexOutOfRangeException();
            }
            else if (position == 0)
            {
                head = head.Next;
            }
            else if (position + 1 == size)
            {
                Node node = CurrentNode(position - 1);
                node.Next = null;
            }
            else
            {
                Node current = CurrentNode(position -1);
                current.Next = current.Next.Next;
            }
            size--;
        }
        public short this[int index]
        {

            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException($"index must be in diapson from 0 to {size}");
                }
                else
                {
                    if (index == 0)
                    {
                        return head.data;
                    }
                    else
                    {
                        Node current = head;
                        for (int i = 1; i <= index; i++)
                        {
                            current = current.Next;
                        }
                        return current.data;
                    }
                }
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException($"index must be in diapson from 0 to {size}");
                }
                else
                {
                    if (index == 0)
                    {
                        head.data = value;
                    }
                    else
                    {
                        Node current = head;
                        for (int i = 1; i <= index; i++)
                        {
                            current = current.Next;
                        }
                        current.data = value;
                    }
                }
            }
        }
        private Node CurrentNode(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException($"index must be in diapson from 0 to {size}");
            }
            else
            {
                if (index == 0)
                {
                    return head;
                }
                else
                {
                    Node current = head;
                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                   return current;
                }
            }
        }
        public void SwitchEvenToZero()
        {
            for (int i = 0; i < size; i += 2)
            {
                this[i] = 0;
            }
        }
        public void RemoveOddIndexes()
        {
            for(int i = 1; i < size; i++)
            {
                this.RemoveValueByIndex(i);
            }
        }
        public short MultipleValue(short value)
        {
            short result = -1;
            for (int i = 0; i < size; i++)
            {
                if (this[i] % value == 0)
                {
                    result = this[i];
                    break;
                }
            }
            return result;
        }
        public List NewListWithBigerValues(short value)
        {
            List result = new List();
            for (int i = 0; i < size; i++)
            {
                if (this[i] > value)
                {
                    result.AddValue(this[i]);
                }
            }
            return result;
        }
        private class Node
        {
            public Node? Next { get; set; }
            public short data;
            public Node(short data, Node? node = null)
            {
                this.data = data;
                this.Next = node;
            }
        }
    }
}
