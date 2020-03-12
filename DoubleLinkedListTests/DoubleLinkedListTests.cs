using System;
using System.Collections.Generic;
using LinkedListClassRewrite;
using NUnit.Framework;

namespace DoubleLinkedListTests
{
    [TestFixture]
    public class DoubleLinkListTests
    {
        private DoubleLinkListTestStub<int> _list;
        private DoubleLinkListTestStub<int> _singleItemList;

        [SetUp]
        public void Setup()
        {
            _singleItemList = new DoubleLinkListTestStub<int>();
            _singleItemList.Empty();

            _list = new DoubleLinkListTestStub<int>();
            _list.Empty();
            _list.AddLast(1);
            _list.AddLast(2);
            _list.AddLast(3);
        }

        [Test]
        public void AddFirst_NormalList_InsertsNewHead()
        {
            _list.AddFirst(10);
            var result = _list.DumpListToList();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(10, result[0].Data);
            Assert.AreEqual(1, result[1].Data);

            Assert.AreSame(result[0], result[1].Prev);
            Assert.AreSame(result[0].Next, result[1]);
            Assert.AreSame(result[1].Next, result[2]);
        }

        [Test]
        public void AddFirst_NodeOverload_InsertsNodeAsHead()
        {
            MyDoubleLinkedListElement<int> element = new MyDoubleLinkedListElement<int>(10);
            _list.AddFirst(element);
            var result = _list.DumpListToList();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(10, result[0].Data);
            Assert.AreEqual(1, result[1].Data);

            Assert.AreSame(result[0], result[1].Prev);
            Assert.AreSame(result[0].Next, result[1]);
            Assert.AreSame(result[1].Next, result[2]);
        }

        [Test]
        public void AddFirst_InvalidInsertion_ThrowsException()
        {
            var list = _list.DumpListToList();
            Assert.Throws<InvalidOperationException>(() => _list.AddFirst(list[2]));
        }

        [Test]
        public void AddLast_NodeOverload_InsertsNodeAsTail()
        {
            MyDoubleLinkedListElement<int> element = new MyDoubleLinkedListElement<int>(10);
            _list.AddLast(element);
            var result = _list.DumpListToList();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(10, result[3].Data);
            Assert.AreEqual(2, result[1].Data);

            Assert.AreSame(result[2], result[3].Prev);
            Assert.AreSame(result[2].Next, result[3]);
        }

        [Test]
        public void AddLast_InvalidInsertion_ThrowsException()
        {
            var list = _list.DumpListToList();
            Assert.Throws<InvalidOperationException>(() => _list.AddLast(list[2]));
        }

        [Test]
        public void AddBefore_AgainstHead_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddBefore(result[0], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[0].Data);

            Assert.IsTrue(finalResult[0].Next == finalResult[1]);
            Assert.IsTrue(finalResult[1].Prev == finalResult[0]);
        }

        [Test]
        public void AddBefore_AgainstSingleItemList_InsertsNode()
        {
            _list.Empty();
            _list.AddLast(1);
            var result = _list.DumpListToList();
            _list.AddBefore(result[0], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(2, finalResult.Count);
            Assert.AreEqual(10, finalResult[0].Data);

            Assert.IsTrue(finalResult[0].Next == finalResult[1]);
            Assert.IsTrue(finalResult[1].Prev == finalResult[0]);
        }

        [Test]
        public void AddBefore_AgainstMiddle_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddBefore(result[1], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[1].Data);

            Assert.IsTrue(finalResult[1].Next == finalResult[2]);
            Assert.IsTrue(finalResult[2].Prev == finalResult[1]);
            Assert.IsTrue(finalResult[0].Next == finalResult[1]);
            Assert.IsTrue(finalResult[1].Prev == finalResult[0]);
        }

        [Test]
        public void AddBefore_AgainstTail_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddBefore(result[2], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[2].Data);

            Assert.IsTrue(finalResult[2].Next == finalResult[3]);
            Assert.IsTrue(finalResult[3].Prev == finalResult[2]);
            Assert.IsTrue(finalResult[1].Next == finalResult[2]);
            Assert.IsTrue(finalResult[2].Prev == finalResult[1]);
        }

        [Test]
        public void AddAfter_AgainstHead_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddAfter(result[0], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[1].Data);

            Assert.IsTrue(finalResult[0].Next == finalResult[1]);
            Assert.IsTrue(finalResult[1].Prev == finalResult[0]);
        }

        [Test]
        public void AddAfter_AgainstSingleItemList_InsertsNode()
        {
            _list.Empty();
            _list.AddLast(1);
            var result = _list.DumpListToList();
            _list.AddAfter(result[0], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(2, finalResult.Count);
            Assert.AreEqual(10, finalResult[1].Data);

            Assert.IsTrue(finalResult[0].Next == finalResult[1]);
            Assert.IsTrue(finalResult[1].Prev == finalResult[0]);
        }

        [Test]
        public void AddAfter_AgainstMiddle_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddAfter(result[1], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[2].Data);

            Assert.IsTrue(finalResult[2].Next == finalResult[3]);
            Assert.IsTrue(finalResult[3].Prev == finalResult[2]);
            Assert.IsTrue(finalResult[1].Next == finalResult[2]);
            Assert.IsTrue(finalResult[2].Prev == finalResult[1]);
        }

        [Test]
        public void AddAfter_AgainstTail_InsertsNode()
        {
            var result = _list.DumpListToList();
            _list.AddAfter(result[2], 10);

            var finalResult = _list.DumpListToList();

            Assert.AreEqual(4, finalResult.Count);
            Assert.AreEqual(10, finalResult[3].Data);

            Assert.IsTrue(finalResult[2].Next == finalResult[3]);
            Assert.IsTrue(finalResult[3].Prev == finalResult[2]);
            Assert.IsTrue(finalResult[1].Next == finalResult[2]);
            Assert.IsTrue(finalResult[2].Prev == finalResult[1]);
        }

        [Test]
        public void AddAfter_NodeBelongsToOtherList_ThrowsException()
        {
            var list = _list.DumpListToList();
            Assert.Throws<InvalidOperationException>(() => _list.AddAfter(list[0], list[2]));
        }

        [Test]
        public void AddBefore_NodeBelongsToOtherList_ThrowsException()
        {
            var list = _list.DumpListToList();
            Assert.Throws<InvalidOperationException>(() => _list.AddBefore(list[0], list[2]));
        }

        [Test]
        public void RemoveAt_EmptyList_NoResponse()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.RemoveAt(2));
        }

        [Test]
        public void RemoveAt_SingleElementList_ReturnsEmptyList()
        {
            Console.WriteLine("\n## TC2: Testing RemoveAt against single element list ###");

            _singleItemList.AddLast(1);
            _singleItemList.DumpList();
            _singleItemList.RemoveAt(0);
            _singleItemList.DumpList();

            var result = _singleItemList.DumpListToList();

            Assert.IsEmpty(result);
            Console.WriteLine("### End OF TC2 ###\n");
        }

        [Test]
        public void RemoveAt_AgainstHead_RemovesHead()
        {
            Console.WriteLine("\n## TC3: Testing RemoveAt against head ###");

            _list.DumpList();  // dump the list
            _list.RemoveAt(0); // remove the head
            _list.DumpList();  // dump the list again

            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].Data);
            Assert.AreEqual(3, result[1].Data);

            Console.WriteLine("### End OF TC3 ###\n");
        }

        [Test]
        public void RemoveAt_AgainstTail_RemovesTail()
        {
            Console.WriteLine("\n## TC4: Testing RemoveAt against tail ###");

            _list.DumpList();  // dump the list
            _list.RemoveAt(2); // remove the tail
            _list.DumpList();  // dump the list again

            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(2, result[1].Data);

            Console.WriteLine("### End OF TC4 ###\n");
        }

        [Test]
        public void RemoveAt_AgainstMiddleElement_RemovesElement()
        {
            Console.WriteLine("\n## TC5: Testing RemoveAt against a middle element ###");

            _list.DumpList();  // dump the list
            _list.RemoveAt(1); // remove the middle
            _list.DumpList();  // dump the list again

            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(3, result[1].Data);

            Console.WriteLine("### End OF TC5 ###\n");
        }

        [Test]
        public void RemoveAt_InvalidIndexBeyondTail_NoResponse()
        {
            Console.WriteLine("\n## TC6: Testing RemoveAt using index beyond the index of tail ###");

            _list.DumpList();  // dump the list
            _list.RemoveAt(4); // remove the tail
            _list.DumpList();  // dump the list again

            var result = _list.DumpListToList();

            Assert.AreEqual(3, result.Count);

            Console.WriteLine("### End OF TC6 ###\n");
        }

        [Test]
        public void InsertAt_MiddleIndex_InsertsItemAtIndexWithValidPointers()
        {
            Console.WriteLine("\n## TC7: Testing InsertAt using middle index ###");

            _list.DumpList();  // dump the list
            _list.InsertAt(8, 1);
            _list.DumpList();  // dump the list again

            var result = _list.DumpListToList();
            var insertedElement = result[2];

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(2, result[1].Data);
            Assert.AreEqual(8, result[2].Data);
            Assert.AreEqual(3, result[3].Data);

            Assert.True(insertedElement.Next.Data == result[3].Data);
            Assert.True(insertedElement.Prev.Data == result[1].Data);
            Assert.True(result[1].Next.Data == insertedElement.Data);
            Assert.True(result[3].Prev.Data == insertedElement.Data);

            Console.WriteLine("### End OF TC7 ###\n");
        }

        [Test]
        public void InsertAt_Tail_InsertsItemAtTailWithValidPointers()
        {
            _list.DumpList();
            _list.InsertAt(10, 2);

            var result = _list.DumpListToList();
            var insertedElement = result[3];

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(2, result[1].Data);
            Assert.AreEqual(3, result[2].Data);
            Assert.AreEqual(10, result[3].Data);

            Assert.True(insertedElement.Next == null);
            Assert.True(insertedElement.Prev == result[2]);
            Assert.True(result[2].Next == insertedElement);
        }

        [Test]
        public void InsertAt_IndexHigherThanListLength_NoResponse()
        {
            _list.InsertAt(10, 10);
        }

        [Test]
        public void InsertAt_EmptyList_ThrowsException()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.InsertAt(10, 0));
        }

        [Test]
        public void InsertAt_SingleItemList_SuccessfulInsert()
        {
            _singleItemList.AddLast(1);
            _singleItemList.InsertAt(10, 0);

            var result = _singleItemList.DumpListToList();
            var insertedItem = result[1];

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(10, result[1].Data);

            Assert.True(insertedItem.Prev == result[0]);
            Assert.True(result[0].Next == insertedItem);
        }

        [Test]
        public void InsertAt_NegativeIndex_Throws()
        {
            Assert.Throws<ArgumentException>(() => _list.InsertAt(10, -1));
        }

        [Test]
        public void Search_SearchForMiddleIndex_ReturnsIndex()
        {
            Console.WriteLine("\n## TC8: Testing Search using middle index ###");

            _list.DumpList();  // dump the list
            Console.WriteLine(_list.Search(3).ToString());
            _list.DumpList();  // dump the list again

            var result = _list.Search(3);

            Assert.AreEqual(2, result);

            Console.WriteLine("### End OF TC8 ###\n");
        }

        [Test]
        public void Search_SearchSingleItemList_ReturnsIndex()
        {
            _list.Empty();
            _list.AddLast(1);
            var result = _list.Search(1);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Search_SearchForNonExistentValue_ReturnsNegativeOne()
        {
            var result = _list.Search(6);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void RemoveLast_EmptyList_ThrowsException()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.RemoveLast());
        }

        [Test]
        public void RemoveLast_NormalList_RemovesTail()
        {
            _list.RemoveLast();
            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(2, result[1].Data);
        }

        [Test]
        public void RemoveLast_SingleItemList_LeavesEmptyList()
        {
            _singleItemList.AddLast(1);
            _singleItemList.RemoveLast();
            var result = _singleItemList.DumpListToList();

            Assert.IsEmpty(result);
        }

        [Test]
        public void RemoveFirst_EmptyList_ThrowsException()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.RemoveFirst());
        }

        [Test]
        public void RemoveFirst_NormalList_RemovesHead()
        {
            _list.RemoveFirst();
            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].Data);
            Assert.AreEqual(3, result[1].Data);
        }

        [Test]
        public void RemoveFirst_SingleItemList_LeavesEmptyList()
        {
            _singleItemList.AddLast(1);
            _singleItemList.RemoveLast();
            var result = _singleItemList.DumpListToList();

            Assert.IsEmpty(result);
        }

        [Test]
        public void Find_EmptyList_ThrowsException()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.Find(3));
        }

        [Test]
        public void Find_NormalList_FindsAndReturnsCorrectValue()
        {
            var result = _list.Find(2);
            var list = _list.DumpListToList();
            Assert.AreSame(list[1], result);
        }

        [Test]
        public void Find_ValueNotFound_ReturnsNull()
        {
            var result = _list.Find(5);
            Assert.IsNull(result);
        }

        [Test]
        public void Remove_NormalListMiddleElement_RemovedSuccessfully()
        {
            _list.Remove(2);
            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(3, result[1].Data);
        }

        [Test]
        public void Remove_NodeOverrideAgainstMiddleElement_RemovedSuccessfully()
        {
            var resultList = _list.DumpListToList();
            _list.Remove(resultList[1]);
            var result = _list.DumpListToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, _list.Count);
            Assert.AreEqual(1, result[0].Data);
            Assert.AreEqual(3, result[1].Data);
        }

        [Test]
        public void Count_RemoveAt_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.RemoveAt(1);
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(2, resultAfter);
        }

        [Test]
        public void Count_Remove_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.Remove(1);
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(2, resultAfter);
        }

        [Test]
        public void Count_RemoveFirst_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.RemoveFirst();
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(2, resultAfter);
        }

        [Test]
        public void Count_RemoveLast_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.RemoveLast();
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(2, resultAfter);
        }

        [Test]
        public void Count_Add_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.AddLast(4);
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(4, resultAfter);
        }

        [Test]
        public void Count_AddToEmptyList_CorrectCount()
        {
            _list.Empty();
            var resultBefore = _list.Count;
            _list.AddLast(1);
            var resultAfter = _list.Count;

            Assert.AreEqual(0, resultBefore);
            Assert.AreEqual(1, resultAfter);
        }

        [Test]
        public void Count_InsertAt_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.InsertAt(10, 2);
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(4, resultAfter);
        }

        [Test]
        public void Count_Empty_CorrectCount()
        {
            var resultBefore = _list.Count;
            _list.Empty();
            var resultAfter = _list.Count;

            Assert.AreEqual(3, resultBefore);
            Assert.AreEqual(0, resultAfter);
        }

        [Test]
        public void Count_RemoveLastFromSingleItemList_CorrectCount()
        {
            _list.Empty();
            _list.AddLast(1);
            var resultBefore = _list.Count;
            _list.RemoveLast();
            var resultAfter = _list.Count;

            Assert.AreEqual(1, resultBefore);
            Assert.AreEqual(0, resultAfter);
        }

        [Test]
        public void Contains_ValidValue_ReturnsTrue()
        {
            Assert.IsTrue(_list.Contains(2));
        }

        [Test]
        public void Contains_InvalidValue_ReturnsFalse()
        {
            Assert.IsFalse(_list.Contains(8));
        }

        [Test]
        public void IEnumerable_IteratesCorrectly()
        {
            string output = "";

            foreach (var element in _list)
            {
                output += element.Data;
            }

            Assert.AreEqual("123", output);
        }

        [Test]
        public void Reverse_NormalList_CorrectOrder()
        {
            var resultBefore = _list.DumpListToList();
            _list.Reverse();
            var listAfter = _list.DumpListToList();

            Assert.AreEqual(listAfter[0], resultBefore[2]);
            Assert.AreEqual(listAfter[1], resultBefore[1]);
            Assert.AreEqual(listAfter[2], resultBefore[0]);

            Assert.True(listAfter[0].Next == listAfter[1]);
            Assert.True(listAfter[1].Prev == listAfter[0]);
            Assert.True(listAfter[1].Next == listAfter[2]);
            Assert.True(listAfter[2].Prev == listAfter[1]);
        }

        [Test]
        public void Reverse_SingleItemList_CorrectOrder()
        {
            _list.Empty();
            _list.AddLast(1);
            _list.Reverse();
            var listAfter = _list.DumpListToList();

            Assert.True(listAfter[0].Next == null);
            Assert.True(listAfter[0].Prev == null);
        }

        [Test]
        public void Reverse_EmptyList_ThrowsException()
        {
            _list.Empty();
            Assert.Throws<EmptyListException>(() => _list.Reverse());
        }
    }

    public class DoubleLinkListTestStub<T> : MyDoubleLinkedList<T>
    {
        public List<MyDoubleLinkedListElement<T>> DumpListToList()
        {
            var elementList = new List<MyDoubleLinkedListElement<T>>();
            MyDoubleLinkedListElement<T> current = this.Head;

            while (current != null)
            {
                elementList.Add(current);
                current = current.Next;
            }

            return elementList;
        }
    }
}