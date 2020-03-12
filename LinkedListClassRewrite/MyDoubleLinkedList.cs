using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LinkedListClassRewrite;
using Microsoft.VisualBasic.CompilerServices;

namespace LinkedListClassRewrite
{
    /// <summary>
    /// Provides an easy way to work with and manipulate a doubly linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyDoubleLinkedList<T> : IEnumerable<MyDoubleLinkedListElement<T>>
    {
        /// <summary>
        /// The property that tracks the <see cref="Head"/> of the <see cref="MyDoubleLinkedList{T}"/>
        /// </summary>
        protected MyDoubleLinkedListElement<T> Head { get; private set; }

        /// <summary>
        /// The <see cref="Count"/> property returns the current count of items in an instance of <see cref="MyDoubleLinkedList{T}"/>.  
        /// </summary>
        public int Count { get; private set; }

        //Constructor
        protected MyDoubleLinkedList()
        {
            this.Head = null;
        }

        /// <summary>
        /// A method that dumps the current state of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        public virtual void DumpList()
        {
            // List: 0 -> 1 -> 2 -> 3 -> 4
            // check if our list is empty
            if (this.Head == null)
            {
                Console.WriteLine("List: Empty!");
            }
            else
            {
                // using the similar logic we used in AddTail.
                MyDoubleLinkedListElement<T> current = this.Head;
                Console.Write("List: ");
                while (current != null)
                {
                    Console.Write(current.Data);

                    // if the "current" is not the tail, meaning its Next is not null, print a -> for the output format
                    if (current.Next != null)
                    {
                        Console.Write(" -> ");
                    }

                    // move the current forward
                    current = current.Next;
                }
                // when finished dumping all element, print a new line break
                Console.Write("\n");
                // loop will break when we hit the tail
                // and nothing need to be done here.
            }
            return;
        }

        /// <summary>
        /// Inserts a new <see cref="MyDoubleLinkedListElement{T}"/> with the value <paramref name="value"/> to the tail of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            var newElement = new MyDoubleLinkedListElement<T>(value);
            AddLast(newElement);
        }

        /// <summary>
        /// Inserts the provided <see cref="MyDoubleLinkedListElement{T}"/> to the tail of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <param name="nodeToInsert"></param>
        public void AddLast(MyDoubleLinkedListElement<T> nodeToInsert)
        {
            GuardAgainstInvalidInsertion(nodeToInsert);

            if (IsEmpty())
            {
                Head = nodeToInsert;
                Count = 1;
                return;
            }

            MyDoubleLinkedListElement<T> current = Head;

            while (current.Next != null)
            {
                current++;
            }

            current.Next = nodeToInsert;
            nodeToInsert.Prev = current;

            Count++;
        }

        /// <summary>
        /// Inserts a new <see cref="MyDoubleLinkedListElement{T}"/> with the value <paramref name="value"/> to the Head of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            var newElement = new MyDoubleLinkedListElement<T>(value);
            AddFirst(newElement);
        }

        /// <summary>
        /// Inserts the provided <see cref="MyDoubleLinkedListElement{T}"/> to the head of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        /// <param name="nodeToInsert"></param>
        public void AddFirst(MyDoubleLinkedListElement<T> nodeToInsert)
        {
            GuardAgainstInvalidInsertion(nodeToInsert);

            if (IsEmpty())
            {
                Head = nodeToInsert;
                Count = 1;
                return;
            }

            MyDoubleLinkedListElement<T> current = Head;

            Head = nodeToInsert;
            Head.Next = current;
            current.Prev = Head;

            Count++;
        }

        /// <summary>
        /// Inserts a new <see cref="MyDoubleLinkedListElement{T}"/> with the provided <paramref name="value"/> before the given <paramref name="node"/> in the list.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddBefore(MyDoubleLinkedListElement<T> node, T value)
        {
            GuardAgainstEmptyList();
            var newElement = new MyDoubleLinkedListElement<T>(value);

            AddBefore(node, newElement);
        }

        /// <summary>
        /// Inserts the <see cref="MyDoubleLinkedListElement{T}"/> <paramref name="nodeToInsert"/> before the given <paramref name="node"/> in the list.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeToInsert"></param>
        public void AddBefore(MyDoubleLinkedListElement<T> node, MyDoubleLinkedListElement<T> nodeToInsert)
        {
            var newElement = new MyDoubleLinkedListElement<T>();
            newElement = nodeToInsert;
            GuardAgainstInvalidInsertion(newElement);

            if (node.IsHeadElement() || node.IsOnlyElement())
            {
                var currentHead = node;
                Head = newElement;
                Head.Next = currentHead;
                currentHead.Prev = Head;
                Count++;
                return;
            }

            var previousNode = node.Prev;
            node.Prev = newElement;
            previousNode.Next = newElement;
            newElement.Next = node;
            newElement.Prev = previousNode;
            Count++;
        }

        /// <summary>
        /// Inserts a new <see cref="MyDoubleLinkedListElement{T}"/> with the provided <paramref name="value"/> after the given <paramref name="node"/> in the list.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddAfter(MyDoubleLinkedListElement<T> node, T value)
        {
            GuardAgainstEmptyList();
            var newElement = new MyDoubleLinkedListElement<T>(value);

            AddAfter(node, newElement);
        }

        /// <summary>
        /// Inserts the <see cref="MyDoubleLinkedListElement{T}"/> <paramref name="nodeToInsert"/> after the given <paramref name="node"/> in the list.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeToInsert"></param>
        public void AddAfter(MyDoubleLinkedListElement<T> node, MyDoubleLinkedListElement<T> nodeToInsert)
        {
            var newElement = new MyDoubleLinkedListElement<T>();
            newElement = nodeToInsert;
            GuardAgainstInvalidInsertion(newElement);

            if (node.IsTailElement() || node.IsOnlyElement())
            {
                node.Next = newElement;
                newElement.Prev = node;
                Count++;
                return;
            }

            var nextNode = node.Next;
            nextNode.Prev = newElement;
            node.Next = newElement;
            newElement.Prev = node;
            newElement.Next = nextNode;
            Count++;
        }

        /// <summary>
        /// Removes the tail of the <see cref="MyDoubleLinkedList{T}"/>
        /// </summary>
        public void RemoveLast()
        {
            GuardAgainstEmptyList();

            MyDoubleLinkedListElement<T> current = Head;

            if (current.IsOnlyElement())
            {
                Head = null;
                Count = default;
                return;
            }

            while (current.Next != null)
            {
                current++;
            }

            current.Prev.Next = null;
            current.Prev = null;
            Count--;
        }

        /// <summary>
        /// Removes the head of the <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        public void RemoveFirst()
        {
            GuardAgainstEmptyList();

            MyDoubleLinkedListElement<T> current = Head;

            var next = current.Next;
            next.Prev = null;
            current.Next = null;
            Head = next;
            Count--;
        }

        /// <summary>
        /// Finds and removes the first <see cref="MyDoubleLinkedListElement{T}"/> with the particular <paramref name="value"/> found from the list.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            var element = Find(value);
            Remove(element);
        }

        /// <summary>
        /// Removes the given <see cref="MyDoubleLinkedListElement{T}"/> <paramref name="node"/> from the list. 
        /// </summary>
        /// <param name="node"></param>
        public void Remove(MyDoubleLinkedListElement<T> node)
        {
            if (node != null)
            {
                RemoveElement(node);
            }
        }

        /// <summary>
        /// Removes the <see cref="MyDoubleLinkedListElement{T}"/> at the given <paramref name="index"/> from the list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            GuardAgainstEmptyList();
            GuardAgainstNegativeIndex(index);

            int currentIndex = 0;
            MyDoubleLinkedListElement<T> currentElement = this.Head;

            while (currentIndex < index)
            {
                if (currentElement.IsTailElement())
                {
                    break;
                }

                currentElement++;
                currentIndex++;
            }

            if (currentIndex == index)
            {
                RemoveElement(currentElement);
            }
        }

        /// <summary>
        /// Wipes the current <see cref="MyDoubleLinkedList{T}"/> removing all <see cref="MyDoubleLinkedListElement{T}"/> and returning the <see cref="Count"/> to zero.
        /// </summary>
        public void Empty()
        {
            this.Head = null;
            Count = 0;
        }

        /// <summary>
        /// Inserts the given <paramref name="value"/> after a particular <paramref name="index"/> in the list. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public void InsertAt(T value, int index)
        {
            GuardAgainstNegativeIndex(index);
            GuardAgainstEmptyList();

            var currentElement = this.Head;
            var currentIndex = 0;

            while (currentIndex < index)
            {
                if (currentElement.IsTailElement())
                {
                    return;
                }

                currentElement++;
                currentIndex++;
            }

            var elementToInsert = new MyDoubleLinkedListElement<T>(value);

            if (currentElement.IsMiddleListElement() || currentElement.IsHeadElement())
            {
                InsertElementInMiddlePosition(currentElement, elementToInsert);
                Count++;
                return;
            }

            if (currentElement.IsTailElement() || currentElement.IsOnlyElement())
            {
                InsertElementAtTailPosition(currentElement, elementToInsert);
                Count++;
            }
        }

        /// <summary>
        /// Searches the <see cref="MyDoubleLinkedList{T}"/> for the given <paramref name="value"/> returning its index.
        /// If no match is found method returns -1.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Search(T value)
        {
            var currentElement = this.Head;
            var currentIndex = 0;

            while (currentElement != null)
            {
                if (currentElement.Data.Equals(value))
                {
                    return currentIndex;
                }

                currentElement++;
                currentIndex++;
            }

            return -1;
        }

        /// <summary>
        /// Searches the <see cref="MyDoubleLinkedList{T}"/> for a given <paramref name="value"/> returning a <see cref="bool"/>
        /// result indicating the existence of the <see cref="MyDoubleLinkedListElement{T}"/> in the list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Search(value) != -1;
        }

        /// <summary>
        /// Searches the <see cref="MyDoubleLinkedList{T}"/> for a particular <paramref name="value"/> and returns the <see cref="MyDoubleLinkedListElement{T}"/>
        /// with the matching value if found.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyDoubleLinkedListElement<T> Find(T value)
        {
            GuardAgainstEmptyList();

            var currentElement = this.Head;

            while (currentElement != null)
            {
                if (currentElement.Data.Equals(value))
                {
                    return currentElement;
                }

                currentElement++;
            }

            return null;
        }

        /// <summary>
        /// Reverses the current order <see cref="MyDoubleLinkedList{T}"/>.
        /// </summary>
        public void Reverse()
        {
            GuardAgainstEmptyList();

            var currentNode = Head;

            while (currentNode != null)
            {
                var next = currentNode.Next;
                var prev = currentNode.Prev;

                currentNode.Next = prev;
                currentNode.Prev = next;

                Head = currentNode;
                currentNode--;
            }
        }

        public IEnumerator<MyDoubleLinkedListElement<T>> GetEnumerator()
        {
            var currentElement = Head;

            while (currentElement != null)
            {
                yield return currentElement;
                currentElement++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region PrivateHelperMethods

        /// <summary>
        /// Encapsulates logic to check if the <see cref="Head"/> is null. 
        /// </summary>
        /// <returns></returns>
        private bool IsEmpty()
        {
            return this.Head == null;
        }

        /// <summary>
        /// Encapsulates logic to insert the <paramref name="elementToInsert"/> in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        /// <param name="elementToInsert"></param>
        private static void InsertElementInMiddlePosition(MyDoubleLinkedListElement<T> currentElement, MyDoubleLinkedListElement<T> elementToInsert)
        {
            var nextElement = currentElement.Next;

            currentElement.Next = elementToInsert;
            elementToInsert.Prev = currentElement;

            nextElement.Prev = elementToInsert;
            elementToInsert.Next = nextElement;
        }

        /// <summary>
        /// Encapsulates logic to insert the <paramref name="elementToInsert"/> in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        /// <param name="elementToInsert"></param>
        private static void InsertElementAtTailPosition(MyDoubleLinkedListElement<T> currentElement, MyDoubleLinkedListElement<T> elementToInsert)
        {
            currentElement.Next = elementToInsert;
            elementToInsert.Prev = currentElement;
        }

        /// <summary>
        /// <para>Guards against negative <paramref name="index"/> values being passed into methods.</para>
        /// Throws <see cref="ArgumentException"/>
        /// </summary>
        /// <param name="index"></param>
        private static void GuardAgainstNegativeIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index is a negative value.");
            }
        }

        /// <summary>
        /// <para>Guards against an empty list where the <see cref="Head"/> is null.</para>
        /// Throws <see cref="EmptyListException"/> 
        /// </summary>
        private void GuardAgainstEmptyList()
        {
            if (Head == null)
            {
                throw new EmptyListException("The list is empty!");
            }
        }

        /// <summary>
        /// <para>Guards against the insertion of a <see cref="MyDoubleLinkedListElement{T}"/> that is already part of another <see cref="MyDoubleLinkedList{T}"/>.</para>
        /// Throws <see cref="InvalidOperationException"/>. 
        /// </summary>
        /// <param name="inputElement"></param>
        private static void GuardAgainstInvalidInsertion(MyDoubleLinkedListElement<T> inputElement)
        {
            if (inputElement.Next != null || inputElement.Prev != null)
            {
                throw new InvalidOperationException(
                    "The node you attempted to insert is already part of another list.");
            }
        }

        /// <summary>
        /// Encapsulates logic to remove the <paramref name="currentElement"/> from a specific position in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        private void RemoveElement(MyDoubleLinkedListElement<T> currentElement)
        {
            if (currentElement.IsMiddleListElement())
            {
                RemoveMiddleElement(currentElement);
            }

            else if (currentElement.IsHeadElement())
            {
                RemoveHeadElement(currentElement);
            }

            else if (currentElement.IsTailElement())
            {
                RemoveTailElement(currentElement);
            }

            else if (currentElement.IsOnlyElement())
            {
                RemoveOnlyElement();
            }

            Count--;
        }

        /// <summary>
        /// Encapsulates logic to remove the <paramref name="currentElement"/> from a specific position in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        private static void RemoveMiddleElement(MyDoubleLinkedListElement<T> currentElement)
        {
            var prevElement = currentElement.Prev;
            var nextElement = currentElement.Next;

            prevElement.Next = nextElement;
            nextElement.Prev = prevElement;
        }

        /// <summary>
        /// Encapsulates logic to remove the <paramref name="currentElement"/> from a specific position in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        private void RemoveHeadElement(MyDoubleLinkedListElement<T> currentElement)
        {
            var nextElement = currentElement.Next;

            nextElement.Prev = null;
            Head = nextElement;
        }

        /// <summary>
        /// Encapsulates logic to remove the <paramref name="currentElement"/> from a specific position in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        private static void RemoveTailElement(MyDoubleLinkedListElement<T> currentElement)
        {
            var prevElement = currentElement.Prev;

            prevElement.Next = null;
        }

        /// <summary>
        /// Encapsulates logic to remove the <paramref name="currentElement"/> from a specific position in the list.
        /// </summary>
        /// <param name="currentElement"></param>
        private void RemoveOnlyElement()
        {
            this.Head = null;
        }

        #endregion
    }
}
