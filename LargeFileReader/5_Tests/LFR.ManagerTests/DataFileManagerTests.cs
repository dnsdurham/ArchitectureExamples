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
        public void DataFileManager_Read_Moq()
        {
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(fr => fr.Read("something", 0)).Returns(() =>
            {
                return "output";
            });
            DataFileManager.ResourceAccessorFactory.AddOverride<IFileReader>(mockFileReader.Object);
            var output = DataFileManager.Read("something", 0, false);

            Assert.AreEqual("output", output);
        }

        [TestMethod]
        public void DataFileManager_Read_MockObject()
        {
            DataFileManager.ResourceAccessorFactory.AddOverride<IFileReader>(new MockFileReader());
            var output = DataFileManager.Read("something", 0, false);

            Assert.AreEqual("from_mock", output);
        }

        class MockFileReader : IFileReader
        {
            public int NumberOfParts(string path)
            {
                return 1;
            }

            public string Read(string filePath, int start)
            {
                return "from_mock";
            }

            public string TestMe(string input)
            {
                return input;
            }
        }

    }
}
