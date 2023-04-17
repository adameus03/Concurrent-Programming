using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace BSDLogic
{
    public class BallCollection : IEnumerable<Ball>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private List<Ball> balls = new List<Ball>();

        public BallCollection() { }

        public void Put(List<Ball> balls)
        {
            this.balls = balls;
            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object? elements = null)
        {
            //ExecuteReceived?.Invoke(this, new EventArgs());
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, elements));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Balls"));
        }

        public Ball this[int index]
        {
            get { return this.balls[index]; }
            set { 
                this.balls.Insert(index, value);
                //OnCollectionChanged(NotifyCollectionChangedAction.Replace, this[index]);
                OnCollectionChanged(NotifyCollectionChangedAction.Reset);

            }
        }

        public void ConfirmSetBall(Ball ball)
        {
            //OnCollectionChanged(NotifyCollectionChangedAction.Replace, ball);
            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public IEnumerator<Ball> GetEnumerator()
        {
            return this.balls.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
