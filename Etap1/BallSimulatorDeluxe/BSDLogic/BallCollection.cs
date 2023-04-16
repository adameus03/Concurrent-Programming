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
        private List<Ball> balls;

        public BallCollection(List<Ball>? balls = null)
        {
            if(balls == null)
            {
                this.balls = new List<Ball>();
            }
            else
            {
                this.balls = balls;
                OnCollectionChanged(NotifyCollectionChangedAction.Reset, this);
            } 
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnCollectionChanged(NotifyCollectionChangedAction action, object? elements)
        {
            //ExecuteReceived?.Invoke(this, new EventArgs());
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("balls"));
        }

        public Ball this[int index]
        {
            get { return this.balls[index]; }
            set { 
                this.balls.Insert(index, value);
                OnCollectionChanged(NotifyCollectionChangedAction.Replace, this[index]);
            }
        }

        public void ConfirmSetBall(Ball ball)
        {
            OnCollectionChanged(NotifyCollectionChangedAction.Replace, ball);
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
