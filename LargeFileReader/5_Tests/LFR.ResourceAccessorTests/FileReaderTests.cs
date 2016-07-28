using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LFR.Accessors;

namespace LFR.ResourceAccessorTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            Factory = new ResourceAccessorFactory();
            FileReader = Factory.Create<IFileReader>();
        }

        [TestCleanup()]
        public void TestCleanup()
        {

        }


        ResourceAccessorFactory Factory { get; set; }
        IFileReader FileReader { get; set; }


        [TestMethod]
        public void FileReader_TestMe()
        {
            Assert.AreEqual("blah", FileReader.TestMe("blah"));
        }
    }
}
