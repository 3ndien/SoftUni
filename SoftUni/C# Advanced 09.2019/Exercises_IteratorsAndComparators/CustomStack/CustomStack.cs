using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialLength = 2;

        private T[] data;
        private int elements;

        public CustomStack()
        {
            data = new T[InitialLength];
        }

        public T Pop()
        {
            if (this.elements == 0)
            {
                throw new ArgumentException("No elements");
            }
            this.elements--;
            var lastElement = this.data[this.elements];
            this.data[this.elements] = default(T);
            return lastElement;
        }

        public void Push(T element)
        {
            if (this.elements >= this.data.Length)
            {
                Array.Resize(ref this.data, this.data.Length * 2);
            }

            this.data[this.elements] = element;
            this.elements++;
        }

        public void Push(IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                this.Push(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackIterator<T>(this.data, this.elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class StackIterator<T> : IEnumerator<T>
    {
        private int currentIndex;
        private T[] data;
        private int length;

        public StackIterator(T[] data, int elements)
        {
            this.length = elements;
            this.Reset();
            this.data = data;
        }

        public T Current => data[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            return --this.currentIndex >= 0;
        }

        public void Reset()
        {
            this.currentIndex = this.length;
        }
    }
}
