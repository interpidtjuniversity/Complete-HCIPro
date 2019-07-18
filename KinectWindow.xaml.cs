//------------------------------------------------------------------------------
// <copyright file="KinectWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.KinectExplorer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using Microsoft.Kinect;
    using Microsoft.Samples.Kinect.WpfViewers;
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for KinectWindow.xaml.
    /// </summary>
    public partial class KinectWindow : Window
    {
        public static readonly DependencyProperty KinectSensorProperty =
            DependencyProperty.Register(
                "KinectSensor",
                typeof(KinectSensor),
                typeof(KinectWindow),
                new PropertyMetadata(null));

        private readonly KinectWindowViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the KinectWindow class, which provides access to many KinectSensor settings
        /// and output visualization.
        /// </summary>
        enum State
        {
            Start,
            Pause,
            End
        }
        State _state = State.End;
        TimeSpan _timeSpan = new TimeSpan(0, 0, 0, 0, 0);
        public KinectWindow()
        {
            //
            //this.Grade.DataContext = 1;
            //
            this.viewModel = new KinectWindowViewModel();
            mediaElement = new MediaElement();
            mediaElement.Loaded += new RoutedEventHandler(media_Loaded);
            mediaElement.MediaEnded += new RoutedEventHandler(media_MediaEnded);
            mediaElement.Unloaded += new RoutedEventHandler(media_Unloaded);
            

            // The KinectSensorManager class is a wrapper for a KinectSensor that adds
            // state logic and property change/binding/etc support, and is the data model
            // for KinectDiagnosticViewer.
            this.viewModel.KinectSensorManager = new KinectSensorManager();

            Binding sensorBinding = new Binding("KinectSensor");
            sensorBinding.Source = this;
            BindingOperations.SetBinding(this.viewModel.KinectSensorManager, KinectSensorManager.KinectSensorProperty, sensorBinding);

            // Attempt to turn on Skeleton Tracking for each Kinect Sensor
            this.viewModel.KinectSensorManager.SkeletonStreamEnabled = true;
            //开启骨骼平滑
            /*
            TransformSmoothParameters smoothParameters = new TransformSmoothParameters();
            smoothParameters.Smoothing = 0.5f;
            smoothParameters.Correction = 0.01f;
            this.viewModel.KinectSensorManager.KinectSensor.SkeletonStream.Enable(smoothParameters);
            */
            //绑定计数控件上下文
            this.DataContext = this.viewModel;
            InitializeComponent();

            //页面计时器
            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = new TimeSpan(0, 0, 0, 1);
            clock.Tick += Ontimer;
            clock.IsEnabled = true;
            clock.Start();
        }
        void Ontimer(object sender, EventArgs e)
        {
            switch (_state)
            {
                case State.Start:
                    {
                        _timeSpan += new TimeSpan(0, 0, 0, 1);
                    }
                    break;
                case State.Pause:
                    { }
                    break;
                case State.End:
                    {
                        _timeSpan = new TimeSpan();
                    }
                    break;
            }
            var time = string.Format("{0:D2}:{1:D2}:{2:D2}", _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds);
            clock.Text = time;
        }

        public KinectSensor KinectSensor
        {
            get { return (KinectSensor)GetValue(KinectSensorProperty); }
            set { SetValue(KinectSensorProperty, value); }
        }

        public void StatusChanged(KinectStatus status)
        {
            this.viewModel.KinectSensorManager.KinectSensorStatus = status;
        }

        private void Swap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Grid colorFrom = null;
            Grid depthFrom = null;

            if (this.MainViewerHost.Children.Contains(this.ColorVis))
            {
                colorFrom = this.MainViewerHost;
            //    depthFrom = this.SideViewerHost;
            }
            else
            {
            //    colorFrom = this.SideViewerHost;
                depthFrom = this.MainViewerHost;
            }

            colorFrom.Children.Remove(this.ColorVis);
            depthFrom.Children.Remove(this.Example);
            colorFrom.Children.Insert(0, this.Example);
            depthFrom.Children.Insert(0, this.ColorVis);
        }

        /*
    元素事件 
*/
        private void media_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Play();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            // MediaElement需要先停止播放才能再开始播放，
            // 否则会停在最后一帧不动
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.UnloadedBehavior = MediaState.Manual;
            (sender as MediaElement).Stop();
            (sender as MediaElement).Play();
        }

        private void media_Unloaded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
        }

        /*
            播放控制按钮的点击事件 
        */
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Play();            
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Stop();
        }

        private void KinectSettings_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void KinectAudioViewer_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_click(object sender, RoutedEventArgs e)
        {
            //KinectSquatSkeletonViewer.mygrade.CyGrade += "1";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Grade.DataContext = this.KinectSquatSkeletonViewer.Grade;
            /*
            Binding binding = new Binding();
            binding.Source = KinectSquatSkeletonViewer.stu;
            binding.Path = new PropertyPath("Name");
            BindingOperations.SetBinding(this.Grade, TextBlock.TextProperty, binding);
            this.Grade.SetBinding(TextBlock.TextProperty, new Binding("Name")
            {
                Source = KinectSquatSkeletonViewer.stu = new Student()
            });
            */
            Binding binding1 = new Binding();
            binding1.Source = KinectSquatSkeletonViewer.mygrade;
            binding1.Path = new PropertyPath("CyGrade");
            BindingOperations.SetBinding(this.Grade, TextBlock.TextProperty, binding1);
            /*
            this.Grade.SetBinding(TextBlock.TextProperty, new Binding("CyGrade")
            {
                Source = KinectSquatSkeletonViewer.mygrade = new MyGrade()
            });
            */
            Binding binding2 = new Binding();
            binding2.Source = KinectSquatSkeletonViewer.mygrade;
            binding2.Path = new PropertyPath("IntCyGrade");
            BindingOperations.SetBinding(this.GradeProgress, ProgressBar.ValueProperty, binding2);

            Binding binding3 = new Binding();
            binding3.Source = KinectSquatSkeletonViewer.mygrade;
            binding3.Path = new PropertyPath("CyGrade");
            BindingOperations.SetBinding(this.LittleGrade, TextBlock.TextProperty, binding3);
        }

        private void btn1_click(object sender, RoutedEventArgs e)
        {
            if (_state == State.Pause||_state == State.End)
            {
                _state = State.Start;
            }
            else if (_state == State.Start)
            {
                _state = State.Pause;
            }
        }
    }

    /// <summary>
    /// A ViewModel for a KinectWindow.
    /// </summary>
    public class KinectWindowViewModel : DependencyObject
    {
        public static readonly DependencyProperty KinectSensorManagerProperty =
            DependencyProperty.Register(
                "KinectSensorManager",
                typeof(KinectSensorManager),
                typeof(KinectWindowViewModel),
                new PropertyMetadata(null));

        public KinectSensorManager KinectSensorManager
        {
            get { return (KinectSensorManager)GetValue(KinectSensorManagerProperty); }
            set { SetValue(KinectSensorManagerProperty, value); }
        }

    }

    /// <summary>
    /// The Command to swap the viewer in the main panel with the viewer in the side panel.
    /// </summary>
    public class KinectWindowsViewerSwapCommand : RoutedCommand
    {  
    }
}
