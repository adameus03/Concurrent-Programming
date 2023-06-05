using BSDData;
using BSDLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBallSimulatorDeluxe
{
    internal class SerializationLogManagerTests
    {
        SerializationLogManager serializationLogManager;
        [SetUp]
        public void Setup()
        {
            serializationLogManager = SerializationLogManager.CreateInstance();
        }

        [Test]
        public void Test1()
        {
            Assert.IsInstanceOf(typeof(SerializationLogManager), serializationLogManager);
        }
    }
}
