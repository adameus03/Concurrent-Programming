using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Collections.Specialized;
using BSDLogic;

namespace BSDMVVM
{
    class BSDViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private readonly BSDModel model;
        public BSDViewModel(BSDModel? model = null)
        {
            this.model = model ?? new BSDModel();
            this.model.Balls.CollectionChanged += (s, e) =>
            {
                OnCollectionChanged(e.Action, e.NewItems); // multip or single?
                OnPropertyChanged(nameof(this.Balls));
            };
        }
       

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;


        private void OnPropertyChanged(string? propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, object? elements)
        {
            this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, elements));
        }

        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

        public BallCollection Balls => this.model.Balls;
    }
}
