namespace Microsoft.Samples.Kinect.KinectExplorer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Kinect;
    using Microsoft.Samples.Kinect.WpfViewers;

    /// <summary>
    /// Interaction logic for KinectWindow.xaml.
    /// </summary>
    public partial class KinectWindowflatsupport : Window
    {
        public static readonly DependencyProperty KinectSensorPropertyflatsupport =
            DependencyProperty.Register(
                "KinectSensor",
                typeof(KinectSensor),
                typeof(KinectWindowflatsupport),
                new PropertyMetadata(null));

        private readonly KinectWindowViewModelflatsupport viewModelflatsupport;

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
        public KinectWindowflatsupport()
        {
            //
            //this.Grade.DataContext = 1;
            //
            this.viewModelflatsupport = new KinectWindowViewModelflatsupport();
            mediaElementflatsupport = new MediaElement();
            mediaElementflatsupport.Loaded += new RoutedEventHandler(media_Loadedflatsupport);
            mediaElementflatsupport.MediaEnded += new RoutedEventHandler(media_MediaEndedflatsupport);
            mediaElementflatsupport.Unloaded += new RoutedEventHandler(media_Unloadedflatsupport);


            // The KinectSensorManager class is a wrapper for a KinectSensor that adds
            // state logic and property change/binding/etc support, and is the data model
            // for KinectDiagnosticViewer.
            this.viewModelflatsupport.KinectSensorManager = new KinectSensorManager();

            Binding sensorBinding = new Binding("KinectSensor");
            sensorBinding.Source = this;
            BindingOperations.SetBinding(this.viewModelflatsupport.KinectSensorManager, KinectSensorManager.KinectSensorProperty, sensorBinding);

            // Attempt to turn on Skeleton Tracking for each Kinect Sensor
            this.viewModelflatsupport.KinectSensorManager.SkeletonStreamEnabled = true;
            //开启骨骼平滑
            /*
            TransformSmoothParameters smoothParameters = new TransformSmoothParameters();
            smoothParameters.Smoothing = 0.5f;
            smoothParameters.Correction = 0.01f;
            this.viewModel.KinectSensorManager.KinectSensor.SkeletonStream.Enable(smoothParameters);
            */
            //绑定计数控件上下文
            this.DataContext = this.viewModelflatsupport;
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
                    {
                    }
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

        public KinectSensor KinectSensorflatsupport
        {
            get { return (KinectSensor)GetValue(KinectSensorPropertyflatsupport); }
            set { SetValue(KinectSensorPropertyflatsupport, value); }
        }

        public void StatusChangedflatsupport(KinectStatus status)
        {
            this.viewModelflatsupport.KinectSensorManager.KinectSensorStatus = status;
        }

        private void Swap_Executedflatsupport(object sender, ExecutedRoutedEventArgs e)
        {
            Grid colorFrom = null;
            Grid depthFrom = null;

            if (this.MainViewerHostflatsupport.Children.Contains(this.ColorVisflatsupport))
            {
                colorFrom = this.MainViewerHostflatsupport;
            //    depthFrom = this.SideViewerHostflatsupport;
            }
            else
            {
            //   colorFrom = this.SideViewerHostflatsupport;
                depthFrom = this.MainViewerHostflatsupport;
            }

            colorFrom.Children.Remove(this.ColorVisflatsupport);
            depthFrom.Children.Remove(this.Exampleflatsupport);
            colorFrom.Children.Insert(0, this.Exampleflatsupport);
            depthFrom.Children.Insert(0, this.ColorVisflatsupport);
        }

        /*
    元素事件 
*/
        private void media_Loadedflatsupport(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Play();
        }

        private void media_MediaEndedflatsupport(object sender, RoutedEventArgs e)
        {
            // MediaElement需要先停止播放才能再开始播放，
            // 否则会停在最后一帧不动
            mediaElementflatsupport.LoadedBehavior = MediaState.Manual;
            mediaElementflatsupport.UnloadedBehavior = MediaState.Manual;
            (sender as MediaElement).Stop();
            (sender as MediaElement).Play();
        }

        private void media_Unloadedflatsupport(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
        }

        /*
            播放控制按钮的点击事件 
        */
        private void btnPlay_Clickflatsupport(object sender, RoutedEventArgs e)
        {
            mediaElementflatsupport.LoadedBehavior = MediaState.Manual;
            mediaElementflatsupport.Play();
        }

        private void btnPause_Clickflatsupport(object sender, RoutedEventArgs e)
        {
            mediaElementflatsupport.LoadedBehavior = MediaState.Manual;
            mediaElementflatsupport.Pause();
        }

        private void btnStop_Clickflatsupport(object sender, RoutedEventArgs e)
        {
            mediaElementflatsupport.LoadedBehavior = MediaState.Manual;
            mediaElementflatsupport.Stop();
        }

        private void KinectSettings_Loadedflatsupport(object sender, RoutedEventArgs e)
        {

        }

        private void KinectAudioViewer_Loadedflatsupport(object sender, RoutedEventArgs e)
        {

        }

        private void btn1_click(object sender, RoutedEventArgs e)
        {
            if (_state == State.Pause || _state == State.End)
            {
                _state = State.Start;
            }
            else if (_state == State.Start)
            {
                _state = State.Pause;
            }
        }
        /*
        private void button1_clicksitup(object sender, RoutedEventArgs e)
        {
            KinectSquatSkeletonViewer.stu.Name += "Name";
            //KinectSquatSkeletonViewer.mygrade.CyGrade += "1";
        }
        */
        private void Window_Loadedflatsupport(object sender, RoutedEventArgs e)
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
            Binding binding1 = new Binding();                                     //
            binding1.Source = KinectSquatSkeletonViewerflatsupport.mygradeflatsupport;
            binding1.Path = new PropertyPath("CyGrade");
            BindingOperations.SetBinding(this.Grade, TextBlock.TextProperty, binding1);
            this.Grade.SetBinding(TextBlock.TextProperty, new Binding("CyGrade")
            {
                Source = KinectSquatSkeletonViewerflatsupport.mygradeflatsupport = new MyGrade()
            });

            Binding binding2 = new Binding();
            binding2.Source = KinectSquatSkeletonViewerflatsupport.mygradeflatsupport;
            binding2.Path = new PropertyPath("IntCyGrade");
            BindingOperations.SetBinding(this.GradeProgress, ProgressBar.ValueProperty, binding2);

            Binding binding3 = new Binding();
            binding3.Source = KinectSquatSkeletonViewerflatsupport.mygradeflatsupport;
            binding3.Path = new PropertyPath("CyGrade");
            BindingOperations.SetBinding(this.LittleGrade, TextBlock.TextProperty, binding3);
        }
    }

    /// <summary>
    /// A ViewModel for a KinectWindow.
    /// </summary>
    public class KinectWindowViewModelflatsupport : DependencyObject
    {
        public static readonly DependencyProperty KinectSensorManagerProperty =
            DependencyProperty.Register(
                "KinectSensorManager",
                typeof(KinectSensorManager),
                typeof(KinectWindowViewModelsitup),
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
    public class KinectWindowsViewerSwapCommandflatsupport : RoutedCommand
    {
    }
}

