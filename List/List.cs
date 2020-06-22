using System;
using System.Collections;

namespace List
{
    public class List<T> where T : IComparable 
    {
        
        private ListNode first = null, end = null;
        private int count = 0;
        

        public int Count { get => count; }
        public T this[int index]
        {
            get
            {
                if (index < count && index >= 0)
                {
                    ListNode node = first;
                    for (int i = 0; i < index; i++)
                        node = node.Next;
                    return node.Value;
                }
                else
                    throw new ListIndexException();
            }
            set
            {
                if (index < count && index >= 0)
                {
                    ListNode node = first;
                    for (int i = 0; i < index; i++)
                        node = node.Next;
                    node.Value = value;
                }
                else
                    throw new ListIndexException();
            }
        }

        public List()
        {

        }

        public void AddBegin(T value)
        {
            if (end == null)
            {
                end = new ListNode(value, null);
                first = end;
                count++;
            }
            else
            {
                first.Back = new ListNode(value, null, first);
                first = first.Back;
                count++;
            }
        }

        public void Add(T value)
        {
            if (end == null)
            {
                end = new ListNode(value, null);
                first = end;
                count++;
            }
            else
            {
                end.Next = new ListNode(value, end);
                end = end.Next;
                count++;
            }
        }

        public void Add(T value, int index)
        {
            if (index < count && index >= 0)
            {
                ListNode node = first;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                ListNode temp = new ListNode(value, node.Back, node);
                if (node.Back != null)
                    node.Back.Next = temp;
                node.Back = temp;
                if (first == node)
                    first = temp;
                count++;
            }
            else
                throw new ListIndexException();
        }
        public bool AddBefore(T value, T elem)
        {
            if (count > 0)
            {
                ListNode node = first;
                while (node != null)
                {
                    if (node.Value.CompareTo(elem) == 0)
                    {
                        ListNode temp = new ListNode(value, node.Back, node);
                        if (node.Back != null)
                            node.Back.Next = temp;
                        node.Back = temp;
                        if (first == node)
                            first = temp;
                        count++;
                        return true;
                    }
                    node = node.Next;
                }
            }
            else
                throw new ListEmptyException();
            return false;
        }
        public bool Remove(T elem)
        {
            if (count > 0)
            {
                ListNode node = first;
                while (node != null)
                {
                    if (node.Value.CompareTo(elem) == 0)
                    {
                        if (node.Back != null)
                            node.Back.Next = node.Next;
                        if (node.Next != null)
                            node.Next.Back = node.Back;
                        if (node == first)
                            first = node.Next;
                        if (node == end)
                            end = node.Back;
                        count--;
                        return true;
                    }
                    node = node.Next;
                }
            }
            else
                throw new ListEmptyException();
            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < count && index >= 0)
            {
                ListNode node = first;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                if (node.Back != null)
                    node.Back.Next = node.Next;
                if (node.Next != null)
                    node.Next.Back = node.Back;
                if (node == first)
                    first = node.Next;
                if (node == end)
                    end = node.Back;
                count--;
            }
            else
                throw new ListIndexException();
        }
        public void Clear()
        {
            first = null;
            end = null;
            count = 0;
        }
        public override string ToString()
        {
            string s = "";
            ListNode node = first;
            while (node != null)
            {
                s += " " + node.Value.ToString() + ";";
                node = node.Next;
            }
            return s;
        }
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode Back { get; set; }
            public ListNode Next { get; set; }

            public ListNode()
            {
            }

            public ListNode(T value, ListNode back, ListNode next = null)
            {
                Value = value;
                Back = back;
                Next = next;
            }
        }
    }
    public class ListEmptyException : Exception
    {
        public ListEmptyException(string message = "Список пуст!") : base(message)
        {
        }
    }
    public class ListIndexException : Exception
    {
        public ListIndexException(string message = "Обращение к несуществующему элементу!") : base(message)
        {
        }
    }
}
