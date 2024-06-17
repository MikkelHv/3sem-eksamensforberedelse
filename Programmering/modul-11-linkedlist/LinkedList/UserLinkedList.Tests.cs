using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        [TestMethod]
        public void TestAddFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            Assert.AreEqual(kristian, list.GetFirst());
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            Assert.AreEqual(torill, list.RemoveFirst());
        }

        [TestMethod]
        public void TestCountUsers()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            list.RemoveUser(mads);
            Assert.AreEqual(4, list.CountUsers());
            list.RemoveUser(kristian);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestGetLast()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            Assert.AreEqual(kristian.Name, list.GetLast().Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void TestContainsUser()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            UserLinkedList list = new UserLinkedList();
            list.AddFirst(kristian);
            list.AddFirst(mads);
            list.AddFirst(torill);
            list.AddFirst(henrik);
            list.AddFirst(klaus);

            // Tjekker forventet exception
            list.Contains(kristian);

        }



        //
        // Sorteret
        //

        /*
        [TestMethod]
        public void TestAddSorted()
        {
            // Arrange
            User anna = new User("Anna", 1);
            User banana = new User("Banana", 2);
            User torill = new User("Torill", 3);

            UserLinkedList list = new UserLinkedList();

            // Act
            list.Add(anna);
            list.Add(torill);
            list.Add(banana);

            // Assert
            var currentNode = list.First;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual("Anna", currentNode.Data.Name);

            currentNode = currentNode.Next;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual("Banana", currentNode.Data.Name);

            currentNode = currentNode.Next;
            Assert.IsNotNull(currentNode);
            Assert.AreEqual("Torill", currentNode.Data.Name);

            Assert.IsNull(currentNode.Next);
        }
        */

    }
}