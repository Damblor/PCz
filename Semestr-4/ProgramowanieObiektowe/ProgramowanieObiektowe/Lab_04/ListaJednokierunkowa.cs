using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    internal class ListaJednokierunkowa<T> : IEnumerable<T>
    {
        class Element
        {
            public Element Next { get; set; }
            public T Value { get; set; }
        }

        class Enumerator : IEnumerator<T>
        {
            Element first, current;
            public T Current =>  current.Value;

            object IEnumerator.Current => Current;

            public Enumerator(Element last)
            {
                first = current = new Element { Next = last };
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if(current != null)
                    current = current.Next;
                return current != null;
            }

            public void Reset()
            {
                current = first;
            }
        }

        private Element first, last;
        public int Count { get; private set; }

        public void Add(T value)
        {
            if(first == null)
            {
                last = first = new Element() { Value = value, Next = null };
            }
            else
            {
                last = last.Next = new Element() { Value = value, Next = null };
            }
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            if (Count == 0)
                throw new Exception();
            if(index == 0)
            {
                if(first == last)
                {
                    first = last = null;
                }
                else
                {
                    first = first.Next;
                }
            }
            else
            {
                var element = GetElement(index - 1);
                element.Next = element.Next.Next;
                if(index == Count - 1)
                    last = element;
            }
            Count--;
        }

        public void Remove(T value)
        {
            var index = GetIndex(value);
            RemoveAt(index);
        }

        public void Insert(int index, T value)
        {
            if(index == 0)
            {
                first = new Element() { Value = value, Next = first };
                if (last == null)
                    last = first;
            }
            else
            {
                var element = GetElement(index - 1);
                var next = element.Next;
                var newElement = new Element { Next = next, Value = value };
                element.Next = newElement;
                if (newElement.Next == null)
                    last = newElement;
            }
            Count++;
        }

        public int GetIndex(T value)
        {
            var current = first;
            for(int i = 0; i < Count; ++i, current = current.Next)
            {
                if(current.Value.Equals(value))
                    return i;
            }
            return -1;
        }

        private Element GetElement(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            var element = first;
            for (int i = 0; i < index; ++i)
                element = element.Next;
            return element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(first);
        }
    }
}
