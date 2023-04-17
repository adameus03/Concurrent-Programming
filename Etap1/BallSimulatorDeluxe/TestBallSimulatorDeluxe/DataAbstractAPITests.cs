using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSDData;
using NUnit.Framework;

namespace TestBallSimulatorDeluxe
{
    public class DataAbstractAPITests
    {
        BSDAbstractDataAPI dataAPI;
        [SetUp]
        public void Setup()
        {
            dataAPI = BSDAbstractDataAPI.CreateInstance();
        }

        [Test]
        public void Test1()
        {
            Assert.IsInstanceOf(typeof(BSDAbstractDataAPI), dataAPI);
        }
        [Test]
        public void Test2()
        {
            Assert.IsInstanceOf(typeof(IConstraintManager), dataAPI.GetConstraintManager());
        }
    }
}