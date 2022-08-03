using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    internal class ListaDwukierunkowa<T> : IEnumerable<T>
    {
        class Element
        {
            public Element Next { get; set; }
            public Element Previous { get; set; }
            public T Value { get; set; }
        }

        class Enumerator : IEnumerator<T>
        {
            Element last, current;
            public T Current => current.Value;

            object IEnumerator.Current => Current;

            public Enumerator(Element last)
            {
                this.last = current = new Element { Previous = last };
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (current != null)
                    current = current.Previous;
                return current != null;
            }

            public void Reset()
            {
                current = last;
            }
        }

        Element first, last;

        public void Add(T value)
        {
            if(first == null)
            {
                first = last = new Element {  Value = value };
            }
            else
            {
                last.Next = new Element { Previous = last, Value = value };
                last = last.Next;
            }
        }
        public void Remove(T value)
        {
            var index = GetIndex(value);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            var element = GetElement(index);
            if (element.Previous == null)
            {
                first = element.Next;
                if (first != null)
                    first.Previous = null;
            }
            else
            {
                element.Previous.Next = element.Next;
            }

            if (element.Next == null)
            {
                last = element.Previous;
                if (last != null)
                    last.Next = null;
            }
            else
            {
                element.Next.Previous = element.Previous;
            }
        }

        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                var nowy = new Element { Next = first, Value = value };
                first.Previous = nowy;
                first = nowy;
                if (last == null)
                    last = first;
            }
            else
            {
                var element = GetElement(index - 1);
                var nowy = new Element { Previous = element, Next = element.Next, Value = value };
                if (element.Next != null)
                    element.Next.Previous = nowy;

                element.Next = nowy;
                if (nowy.Next == null)
                    last = nowy;
            }
        }

        public int GetIndex(T value)
        {
            var current = first;
            for (int i = 0; current != null; ++i, current = current.Next)
            {
                if (current.Value.Equals(value))
                    return i;
            }
            return -1;
        }

        private Element GetElement(int index)
        {
            var element = first;
            for (int i = 0; i < index; ++i)
            {
                if (element.Next == null)
                    throw new IndexOutOfRangeException();
                element = element.Next;
            }
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(last);
        }
    }
}
