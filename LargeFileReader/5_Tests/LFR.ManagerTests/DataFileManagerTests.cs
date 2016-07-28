using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LFR.Managers;
using Moq;
using LFR.Accessors;

namespace LFR.ManagerTests
{
    [TestClass]
    public class DataFileManagerTests
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            Factory = new ManagerFactory();
            DataFileManager = Factory.Create<IDataFileManager>();
        }

        [TestCleanup()]
        public void TestCleanup()
        {

        }

        ManagerFactory Factory { get; set; }
        IDataFileManager DataFileManager { get; set; }

        [TestMethod]
        public void DataFileManager_TestMe()
        {
            Assert.AreEqual("testme", DataFileManager.TestMe("testme"));
        }

        [TestMethod]
        public void DataFileManager_Read()
        {
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(fr => fr.Read("something", 0)).Returns(() =>
            {
                return "output";
            });

            
        }
    }
}
