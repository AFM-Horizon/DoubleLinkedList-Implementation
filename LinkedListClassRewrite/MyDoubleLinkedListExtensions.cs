using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListClassRewrite
{
    /// <summary>
    /// Extensions for quickly and easily checking the current position of an <see cref="MyDoubleLinkedListElement{T}"/> within a <see cref="MyDoubleLinkedList{T}"/>.
    /// </summary>
    public static class MyDoubleLinkedListExtensions
    {
        /// <summary>
        /// Returns a <see cref="bool"/> value indicating whether a <see cref="MyDoubleLinkedListElement{T}"/>
        /// is currently contained in the middle of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsMiddleListElement<T>(this MyDoubleLinkedListElement<T> element)
        {
            return (element.Prev != null && element.Next != null);
        }

        /// <summary>
        /// Returns a <see cref="bool"/> value indicating whether a <see cref="MyDoubleLinkedListElement{T}"/>
        /// is currently the head of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsHeadElement<T>(this MyDoubleLinkedListElement<T> element)
        {
            return (element.Prev == null && element.Next != null);
        }

        /// <summary>
        /// Returns a <see cref="bool"/> value indicating whether a <see cref="MyDoubleLinkedListElement{T}"/>
        /// is currently the tail of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsTailElement<T>(this MyDoubleLinkedListElement<T> element)
        {
            return (element.Prev != null && element.Next == null);
        }

        /// <summary>
        /// Returns a <see cref="bool"/> value indicating whether a <see cref="MyDoubleLinkedListElement{T}"/>
        /// is the only element in a <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsOnlyElement<T>(this MyDoubleLinkedListElement<T> element)
        {
            return (element.Prev == null && element.Next == null);
        }
    }
}
