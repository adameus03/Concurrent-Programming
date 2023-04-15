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
    abstract class BSDAbstractLogicAPI
    {
        protected readonly BSDData.BSDAbstractDataAPI? dataAPI;
        protected ObservableCollection<Ball> balls = new ObservableCollection<Ball>();
        public BSDAbstractLogicAPI(BSDData.BSDAbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }
        public static BSDAbstractLogicAPI CreateInstance(BSDData.BSDAbstractDataAPI? dataAPI = null) {
            return new BSDLogicAPI(dataAPI ?? BSDData.BSDAbstractDataAPI.CreateInstance());
        }


        public abstract void GenerateBalls(int ballsNumber, Color ballsColor);

        public abstract void UpdateBalls();

        public ObservableCollection<Ball> Balls => this.balls;
    }
}
