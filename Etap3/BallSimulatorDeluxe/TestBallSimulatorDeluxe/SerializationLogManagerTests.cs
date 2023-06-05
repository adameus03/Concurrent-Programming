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
        SerializationLogManager serializationLogManager1;
        SerializationLogManager serializationLogManager2;
        string testFilePath = "test.log";
        [SetUp]
        public void Setup()
        {
            serializationLogManager1 = SerializationLogManager.CreateInstance();
            serializationLogManager2 = SerializationLogManager.CreateInstance(testFilePath);
        }

        [Test]
        public void Test1()
        {
            Assert.IsInstanceOf(typeof(SerializationLogManager), serializationLogManager1);
            Assert.IsNull(serializationLogManager1.FilePath);
            Assert.IsFalse(serializationLogManager1.IsActive);
            Assert.IsFalse(serializationLogManager1.IsLogging);
        }

        [Test]
        public void Test2()
        {
            Assert.That(serializationLogManager2.FilePath, Is.EqualTo(testFilePath));
            Assert.IsFalse(serializationLogManager1.IsActive);
            Assert.IsFalse(serializationLogManager1.IsLogging);

        }
    }
}