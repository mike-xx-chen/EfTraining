﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCompany.EfTraining.BusinessComponents;
using System.Linq;

namespace MyCompany.EfTraining.UnitTests
{
    [TestClass]
    public class TodoItemAdoNetLogicTestFixture
    {
        private TodoItemAdoNetLogic _testInstance = new TodoItemAdoNetLogic();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
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
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() > 0);

            var expectedCount = list.Count();

            var firstItem = _testInstance.GetFirst();
            _testInstance.Delete(firstItem);

            list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.AreEqual(expectedCount - 1, list.Count());

            var newEntity = _testInstance.Create("Dummy 1", false);
            _testInstance.Save(newEntity);

            list = _testInstance.GetAll();
            Assert.IsNotNull(list);
            Assert.AreEqual(expectedCount, list.Count());
        }

        [TestMethod]
        public void SaveTest()
        {
            var lastItem = _testInstance.GetLast();
            var expected = lastItem.Description = lastItem.Description + " Hello!";
            _testInstance.Save(lastItem);
            var result = _testInstance.GetItemByKey(lastItem.Id);
            Assert.AreEqual(expected, result.Description);
            Assert.AreEqual(lastItem.Version, result.Version);
        }

        [TestMethod]
        public void SearchTest()
        {
            var items = _testInstance.Search("1 2");
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() > 0);
        }
    }
}
