using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinkedListClassRewrite
{
    public class MyDoubleLinkedListElement<T>
    {
        public T Data { get; private set; }

        /// <summary>
        /// Stores a Pointer to the previous <see cref="MyDoubleLinkedListElement{T}"/> in the list.
        /// </summary>
        public MyDoubleLinkedListElement<T> Prev { get; set; }

        /// <summary>
        /// Stores a pointer to the next <see cref="MyDoubleLinkedListElement{T}"/> in the list. 
        /// </summary>
        public MyDoubleLinkedListElement<T> Next { get; set; }

        public MyDoubleLinkedListElement()
        {
            this.Data = default(T);
            this.Next = null;
            this.Prev = null;
        }

        public MyDoubleLinkedListElement(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }

        /// <summary>
        /// An override of the ++ operator allowing incrementing of the current <see cref="MyDoubleLinkedListElement{T}"/> element to its next pointer value.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static MyDoubleLinkedListElement<T> operator ++(MyDoubleLinkedListElement<T> element) => element.Next;

        /// <summary>
        /// An override of the -- operator allowing decrementing of the current <see cref="MyDoubleLinkedListElement{T}"/> element to its previous pointer value.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static MyDoubleLinkedListElement<T> operator --(MyDoubleLinkedListElement<T> element) => element.Prev;
    }
}
