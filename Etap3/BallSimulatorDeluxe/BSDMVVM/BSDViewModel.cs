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
using BSDData;
using System.Text.RegularExpressions;

namespace BSDMVVM
{
    [VVM(typeof(BSDViewModel))]
    class BSDViewModel : /*INotifyPropertyChanged*/ BaseViewModel
    {
        private bool realTimeLoggingEnabled = false;

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

        private int worldWidth = 800;
        private int worldHeight = 450;

        private bool animationPaused = true;
        private bool ballsNumberTextBoxEnabled = true;



        public BSDViewModel()
        {
            this.model = new BSDModel();
            this.model.Balls.CollectionChanged += (s, e) =>
            {
                //MessageBox.Show("Balls.CollectionChanged event detected in ViewModel");
                OnPropertyChanged(nameof(this.Balls));
            };
            this.model.SetBoundingRectangle(new System.Drawing.Rectangle(0, 0, worldWidth, worldHeight));
            //this.model.SetBoundingRectangle(new System.Drawing.Rectangle(0, 0, 200, 200));

            this.model.SetMinimalBallRadius(10);
            this.model.SetMaximalBallRadius(20);
            this.model.SetBallsSpeed(100.0);
            
            this.RunControlImagePath = BSDViewModel.playPath;
            this.GeneratorImagePath = BSDViewModel.generatorPath;
            this.runControlHighlight.ExecuteReceived += RunControlHighlight_ExecuteReceived;
            this.runControlUnhighlight.ExecuteReceived += RunControlUnhighlight_ExecuteReceived;
            this.generatorHighlight.ExecuteReceived += GeneratorHighlight_ExecuteReceived;
            this.generatorUnhighlight.ExecuteReceived += GeneratorUnhighlight_ExecuteReceived;
            this.toggleSimulation.ExecuteReceived += ToggleSimulation_ExecuteReceived;
            this.launchGenerator.ExecuteReceived += LaunchGenerator_ExecuteReceived;

            this.Balls.PropertyChanged += Balls_PropertyChanged;
            //this.Balls.CollectionChanged += Balls_CollectionChanged;

            /*(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000 / this.model.SimulationFPS);
                    if (!this.animationPaused)
                    {
                        //MessageBox.Show("ok");
                        App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                        {
                            this.model.EllipsesRepositioning();
                        });
                        
                    }
                }
            })();*/
            this.Animate();
        }

        /*private void Balls_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("BCollChanged");
            //OnCollectionChanged(e.Action, e.NewItems);
        }*/

        private async void Animate()
        {
            while (true)
            {
                await Task.Delay(1000 / this.model.SimulationFPS);
                if (!this.animationPaused)
                {
                    this.model.EllipsesRepositioning();

                }
            }
        }

        private void Balls_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            //MessageBox.Show("BPropChanged");
            OnPropertyChanged(nameof(this.Balls));
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
            // start/pause simulation
            this.animationPaused = !this.animationPaused;
            this.RunControlImagePath = this.animationPaused ? BSDViewModel.playActivePath : BSDViewModel.pauseActivePath;
            OnPropertyChanged(nameof(this.RunControlImagePath));
            
            
            
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

        /*public event PropertyChangedEventHandler? PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/


        public double CanvasWidth { get; set; }
        public double CanvasHeight { get; set; }

        public BallCollection Balls => this.model.Balls;

        public Command RunControlHighlight => this.runControlHighlight;
        public Command RunControlUnhighlight => this.runControlUnhighlight;

        public Command ToggleSimulation => this.toggleSimulation;
        public Command GeneratorHighlight => this.generatorHighlight;    
        public Command GeneratorUnhighlight => this.generatorUnhighlight;

        public Command LaunchGenerator => this.launchGenerator;

        public string RunControlImagePath { get; set; } 
        public string GeneratorImagePath { get; set; }

        public int BallsNumber {
            get => this.model.NumberOfBalls;
            set
            {
                this.model.NumberOfBalls = value;
            }
        }

        public bool BallsNumberTextBoxEnabled => this.ballsNumberTextBoxEnabled;

        public bool RealTimeLoggingEnabled
        {
            get
            {
                return this.realTimeLoggingEnabled;
            }
            set
            {
                //throw new NotImplementedException();
                if (value)
                {
                    this.model.LogFilePath = BSDViewModel.WindowService.ShowSaveFileDialog();
                    if (this.model.LogFilePath != null)
                    {
                        this.realTimeLoggingEnabled = true;
                        BSDViewModel.WindowService.ShowMessage($"Logfile path set to {this.model.LogFilePath}");
                    }
                }
                else
                {

                    BSDViewModel.WindowService.ShowMessage($"Finished logging to {this.model.LogFilePath}");
                    this.model.LogFilePath = null;
                    this.realTimeLoggingEnabled = false;
                    
                }
                
            }
        }

        public int WorldWidth {
            get
            {
                return this.worldWidth;
            }
            set
            {
                this.worldWidth = value;
                this.model.SetBoundingRectangle(new System.Drawing.Rectangle(0, 0, this.worldWidth, this.worldHeight));
            }
        }
        public int WorldHeight { 
            get
            {
                return this.worldHeight;
            }
            set
            {
                this.worldHeight = value;
                this.model.SetBoundingRectangle(new System.Drawing.Rectangle(0, 0, this.worldWidth, this.worldHeight));
            }
        }



    }
}
