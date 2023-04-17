using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Collections.Specialized;
using BSDLogic;
using System.Windows;
using System.Runtime.CompilerServices;

namespace BSDMVVM
{
    class BSDViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private readonly BSDModel model;
        private Command runControlHighlight = new Command();
        private Command runControlUnhighlight = new Command();
        private Command toggleSimulation = new Command();
        private Command generatorHighlight = new Command();
        private Command generatorUnhighlight = new Command();
        private Command launchGenerator = new Command();

        private const string playPath = "Images/play.png";
        private const string playActivePath = "Images/play_active.png";
        private const string pausePath = "Images/pause.png";
        private const string pauseActivePath = "Images/pause_active.png";
        private const string generatorPath = "Images/generate.png";
        private const string generatorActivePath = "Images/generate_active.png";

        private bool animationPaused = true;
        private bool ballsNumberTextBoxEnabled = true;

        private Task animation;


        public BSDViewModel()
        {
            this.model = new BSDModel();
            this.model.Balls.CollectionChanged += (s, e) =>
            {
                OnCollectionChanged(e.Action, e.NewItems); // multip or single?
                OnPropertyChanged(nameof(this.Balls));
            };
            this.RunControlImagePath = BSDViewModel.playPath;
            this.GeneratorImagePath = BSDViewModel.generatorPath;
            this.runControlHighlight.ExecuteReceived += RunControlHighlight_ExecuteReceived;
            this.runControlUnhighlight.ExecuteReceived += RunControlUnhighlight_ExecuteReceived;
            this.generatorHighlight.ExecuteReceived += GeneratorHighlight_ExecuteReceived;
            this.generatorUnhighlight.ExecuteReceived += GeneratorUnhighlight_ExecuteReceived;
            this.toggleSimulation.ExecuteReceived += ToggleSimulation_ExecuteReceived;
            this.launchGenerator.ExecuteReceived += LaunchGenerator_ExecuteReceived;

            this.animation = new Task(() =>
            {
                while (true)
                {
                    Task.Delay(1000 / this.model.SimulationFPS);
                    if (!this.animationPaused)
                    {
                        this.model.EllipsesRepositioning();
                    }
                }
            });
            this.animation.Start();
        }

        private void LaunchGenerator_ExecuteReceived(object? sender, EventArgs e)
        {
            
            //MessageBox.Show("Gener balls");
            this.ballsNumberTextBoxEnabled = false;
            OnPropertyChanged(nameof(this.ballsNumberTextBoxEnabled));
            //OnPropertyChanged(nameof(this.BallsNumber));
            //generate balls
            this.model.EllipsesInitialization();
            //this.BallsNumberTextBoxEnabled = true;
            this.ballsNumberTextBoxEnabled = true;
            OnPropertyChanged(nameof(this.ballsNumberTextBoxEnabled));
        }

        private void ToggleSimulation_ExecuteReceived(object? sender, EventArgs e)
        {
            //MessageBox.Show("Toggle simul");
            this.animationPaused = !this.animationPaused;
            this.RunControlImagePath = this.animationPaused ? BSDViewModel.playActivePath : BSDViewModel.pauseActivePath;
            OnPropertyChanged(nameof(this.RunControlImagePath));
            // start/stop simulation
            if (!this.animationPaused)
            {

            }
            
        }

        private void GeneratorUnhighlight_ExecuteReceived(object? sender, EventArgs e)
        {
            //MessageBox.Show("generator unhighlight");
            this.GeneratorImagePath = BSDViewModel.generatorPath;
            OnPropertyChanged(nameof(this.GeneratorImagePath));
        }

        private void GeneratorHighlight_ExecuteReceived(object? sender, EventArgs e)
        {
            //MessageBox.Show("generator highlight");
            this.GeneratorImagePath = BSDViewModel.generatorActivePath;
            OnPropertyChanged(nameof(this.GeneratorImagePath));
        }

        private void RunControlUnhighlight_ExecuteReceived(object? sender, EventArgs e)
        {
            this.RunControlImagePath = this.animationPaused ? BSDViewModel.playPath : BSDViewModel.pausePath;
            OnPropertyChanged(nameof(this.RunControlImagePath));
        }

        private void RunControlHighlight_ExecuteReceived(object? sender, EventArgs e)
        {
            //MessageBox.Show("Rchigh");
            this.RunControlImagePath = this.animationPaused ? BSDViewModel.playActivePath : BSDViewModel.pauseActivePath;
            OnPropertyChanged(nameof(this.RunControlImagePath));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;


        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
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

        public Command RunControlHighlight => this.runControlHighlight;
        public Command RunControlUnhighlight => this.runControlUnhighlight;

        public Command ToggleSimulation => this.toggleSimulation;
        public Command GeneratorHighlight => this.generatorHighlight;    
        public Command GeneratorUnhighlight => this.generatorUnhighlight;

        public Command LaunchGenerator => this.launchGenerator;

        public string RunControlImagePath { get; set; } 
        public string GeneratorImagePath { get; set; }

        public int BallsNumber { get; set; } = 20;

        public bool BallsNumberTextBoxEnabled => this.ballsNumberTextBoxEnabled;

    }
}
