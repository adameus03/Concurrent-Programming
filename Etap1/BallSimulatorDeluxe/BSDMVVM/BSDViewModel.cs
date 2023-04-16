using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace BSDMVVM
{
    class BSDViewModel : INotifyPropertyChanged
    {

        public BSDViewModel()
        {
            
        }
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
