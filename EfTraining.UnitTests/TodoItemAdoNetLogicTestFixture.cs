using System;
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
        }

        [TestMethod]
        public void GetAllTest()
        {
            var all = _testInstance.GetAll();
            Assert.IsNotNull(all);
            Assert.AreEqual(10, all.Count());
        }
    }
}
