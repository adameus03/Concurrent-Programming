﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDMVVM
{
    internal class BaseViewModel
    {
    }
}*/

using BSDMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSDMVVM
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        private static IWindowService windowService = new WindowsWindowService();

        public BaseViewModel() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected static IWindowService WindowService => BaseViewModel.windowService;


    }
}

