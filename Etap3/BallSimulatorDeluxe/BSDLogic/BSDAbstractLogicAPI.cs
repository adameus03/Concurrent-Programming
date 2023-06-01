using BSDData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BSDLogic
{
    public abstract class BSDAbstractLogicAPI
    {
        protected readonly BSDData.BSDAbstractDataAPI dataAPI;
        
        protected BallCollection balls = new BallCollection();
        public BSDAbstractLogicAPI(BSDData.BSDAbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }
        public static BSDAbstractLogicAPI CreateInstance(BSDData.BSDAbstractDataAPI? dataAPI = null) {
            return new BSDLogicAPI(dataAPI ?? BSDData.BSDAbstractDataAPI.CreateInstance());
        }

        public BSDData.BSDAbstractDataAPI DataAPI => this.dataAPI;
        public abstract void GenerateBalls(int ballsNumber, string ballsColor);

        public abstract void UpdateBalls(int chrononMiliseconds, int planckPixels);
        public abstract void SetConstraint(string constraintName, object constraintValue);

        public void EnableLogging(string destinationPath)
        {
            this.dataAPI.SetLoggingPath(destinationPath);
            this.dataAPI.StartLogging();
            //set flag
        }
        public void DisableLogging()
        {
            this.dataAPI.PauseLogging();
        }

        public BallCollection Balls => this.balls;

    }
}
