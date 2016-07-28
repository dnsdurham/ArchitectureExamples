using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LFR.Engines;

namespace LFR.EngineTests
{
    [TestClass]
    public class MakeLowerEngineTests
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            Factory = new EngineFactory();
            MakeLowerEngine = Factory.Create<IMakeLowerEngine>();
        }

        [TestCleanup()]
        public void TestCleanup()
        {

        }


        EngineFactory Factory { get; set; }
        IMakeLowerEngine MakeLowerEngine { get; set; }

        [TestMethod]
        public void MakeLowerEngine_TestMe()
        {
            Assert.AreEqual("testme", MakeLowerEngine.TestMe("testme"));
        }
    }
}
