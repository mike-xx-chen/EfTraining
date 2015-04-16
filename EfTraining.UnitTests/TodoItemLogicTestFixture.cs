using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompany.EfTraining.BusinessComponents;
using System.Linq;

namespace MyCompany.EfTraining.UnitTests
{
    [TestClass]
    public class TodoItemLogicTestFixture
    {
        private static TodoItemLogic _testInstance = new TodoItemLogic();

        /// <summary>
        /// 
        /// </summary>
        public TodoItemLogicTestFixture()
        {
            
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _testInstance.InitializeDb();
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanUp()
        {
        }

        [TestMethod]
        public void GetFirstTest()
        {
            var firstItem = _testInstance.GetFirst();
            Assert.IsNotNull(firstItem);

            var expected = _testInstance.GetAll().OrderBy(e => e.Sorting).First();
            Assert.AreEqual(expected.Sorting, firstItem.Sorting);
        }

        [TestMethod]
        public void GetLastTest()
        {
            var lastItem = _testInstance.GetLast();
            Assert.IsNotNull(lastItem);

            var expected = _testInstance.GetAll().OrderByDescending(e => e.Sorting).First();
            Assert.AreEqual(expected.Sorting, lastItem.Sorting);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 10);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 10);

            var firstItem = _testInstance.GetFirst();
            _testInstance.Delete(firstItem);

            list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 9);

            var newEntity = _testInstance.Create("Dummy 1", false);
            _testInstance.Save(newEntity);

            list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 10);
        }

        [TestMethod]
        public void SaveTest()
        {
            var lastItem = _testInstance.GetLast();
            var expected = lastItem.Description = lastItem.Description + " Hello again!";
            _testInstance.Save(lastItem);
            var result = _testInstance.GetItem(e => e.Id == lastItem.Id);
            Assert.AreEqual(expected, result.Description);
            Assert.AreEqual(lastItem.Version, result.Version);
        }

        [TestMethod]
        public void SearchTest()
        {
            var items = _testInstance.Search("1 2");
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() >= 2);
        }
    }
}
