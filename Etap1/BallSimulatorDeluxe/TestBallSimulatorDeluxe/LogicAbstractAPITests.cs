using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSDLogic;
using BSDData;

namespace TestBallSimulatorDeluxe
{
    public class LogicAbstractAPITests
    {
        BSDAbstractDataAPI dataAPI;
        BSDAbstractLogicAPI logicAPI;
        Rectangle rectangle = new Rectangle(1, 2, 3, 4);
        int minimalRadius = 5;
        int maximalRadius = 19;
        [SetUp]
        public void Setup()
        {
            dataAPI = BSDAbstractDataAPI.CreateInstance();
            logicAPI = BSDAbstractLogicAPI.CreateInstance(dataAPI);
        }

        [Test]
        public void Test1()
        {
            Assert.IsInstanceOf(typeof(BSDAbstractLogicAPI), logicAPI);
        }
        /* Integration test */
        [Test]
        public void Test2()
        {
            this.logicAPI.SetConstraint("LocationSpan", rectangle);
            this.logicAPI.SetConstraint("MinimalBallRadius", minimalRadius);
            this.logicAPI.SetConstraint("MaximalBallRadius", maximalRadius);

            Assert.That(dataAPI.GetConstraintManager().GetLocationSpan(), Is.EqualTo(this.rectangle));
            Assert.That(dataAPI.GetConstraintManager().GetMinimalBallRadius(), Is.EqualTo(this.minimalRadius));
            Assert.That(dataAPI.GetConstraintManager().GetMaximalBallRadius(), Is.EqualTo(this.maximalRadius));

        }
    }
}