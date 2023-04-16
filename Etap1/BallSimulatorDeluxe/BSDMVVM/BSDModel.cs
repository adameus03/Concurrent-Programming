using BSDLogic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace BSDMVVM
{
    public class BSDModel
    {
        private readonly BSDLogic.BSDAbstractLogicAPI logicAPI;
        private int simulationNumberOfBalls;
        
        private int simulationFPS = 60;
        private int simulationJumpingFactor = 1;
        private Color colorForEachBall = Color.AliceBlue;
        private BSDLogic.BallCollection balls;

        public BSDModel(BSDLogic.BSDAbstractLogicAPI? logicAPI = null)
        {
            this.logicAPI = logicAPI ?? BSDLogic.BSDAbstractLogicAPI.CreateInstance();
            //this.logicAPI.Balls = this.logicAPI.Balls;
            this.balls = this.logicAPI.Balls;
        }

        public void EllipsesInitialization()
        {
            this.logicAPI.GenerateBalls(this.simulationNumberOfBalls, this.colorForEachBall);
            /*this.ellipses = this.logicAPI.Balls.ToList().Select((ball)=>new Ellipse { 
                Width = ball.Radius,
                Height = ball.Radius,
                
            }).ToList();*/
            this.balls = this.logicAPI.Balls;
        }

        public void EllipsesRepositioning()
        {
            this.logicAPI.UpdateBalls(1000 / this.simulationFPS, this.simulationJumpingFactor);
        }

        public int NumberOfBalls { get => this.simulationNumberOfBalls; set => this.simulationNumberOfBalls = value; }
        public Color ColorForEachBall { get => this.colorForEachBall; set => this.colorForEachBall = value; }

        public int SimulationFPS { 
            get => this.simulationFPS;
            set
            {
                if (value > 1000)
                {
                    this.simulationFPS = 1000;
                }
                else this.simulationFPS = value;
            }
        }
        public int SimulationJumpingFactor { get => this.simulationJumpingFactor; set => this.simulationJumpingFactor = value; }
        public BSDLogic.BallCollection Balls => this.balls;
    }
}
