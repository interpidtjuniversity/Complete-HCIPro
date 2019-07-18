//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.KinectExplorer
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using Microsoft.Kinect;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        //深蹲
        private readonly KinectSensorItemCollection sensorItems;
        private readonly ObservableCollection<KinectStatusItem> statusItems;
        //仰卧起坐
        private readonly KinectSensorItemCollectionsitup sensorItemssitup;
        private readonly ObservableCollection<KinectStatusItem> statusItemssitup;
        //
        private readonly KinectSensorItemCollectionflatsupport sensorItemsflatsupport;
        private readonly ObservableCollection<KinectStatusItem> statusItemsflatsupport;
        /// <summary>
        /// Initializes a new instance of the MainWindow class, which displays a list of sensors and their status.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.sensorItems = new KinectSensorItemCollection();
            this.statusItems = new ObservableCollection<KinectStatusItem>();

            this.sensorItemssitup = new KinectSensorItemCollectionsitup();
            this.statusItemssitup = new ObservableCollection<KinectStatusItem>();

            this.sensorItemsflatsupport = new KinectSensorItemCollectionflatsupport();
            this.statusItemsflatsupport = new ObservableCollection<KinectStatusItem>();
            this.kinectSensors.ItemsSource = this.sensorItems;
            this.kinectStatus.ItemsSource = this.statusItems;
        }
        private void WindowLoaded(object sender, EventArgs e)
        {
            /*
            // listen to any status change for Kinects.
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChanged;

            // show status for each sensor that is found now.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                this.ShowStatus(kinect, kinect.Status);
            }
            */
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            foreach (KinectSensorItem sensorItem in this.sensorItems)
            {
                sensorItem.CloseWindow();
            }
            this.sensorItems.Clear();

            foreach (KinectSensorItemsitup sensorItem in this.sensorItemssitup)
            {
                sensorItem.CloseWindow();
            }
            this.sensorItemssitup.Clear();

            foreach (KinectSensorItemflatsupport sensorItem in this.sensorItemsflatsupport)
            {
                sensorItem.CloseWindow();
            }
            this.sensorItemssitup.Clear();
        }

        private void ShowStatus(KinectSensor kinectSensor, KinectStatus kinectStatus)
        {
            this.statusItems.Add(new KinectStatusItem 
            { 
                Id = (null == kinectSensor) ? null : kinectSensor.DeviceConnectionId,
                Status = kinectStatus,
                DateTime = DateTime.Now
            });

            KinectSensorItem sensorItem;
            this.sensorItems.SensorLookup.TryGetValue(kinectSensor, out sensorItem);

            if (KinectStatus.Disconnected == kinectStatus)
            {
                if (sensorItem != null)
                {
                    this.sensorItems.Remove(sensorItem);
                    sensorItem.CloseWindow();
                }
            }
            else
            {
                if (sensorItem == null)
                {
                    sensorItem = new KinectSensorItem(kinectSensor, kinectSensor.DeviceConnectionId);
                    sensorItem.Status = kinectStatus;

                    this.sensorItems.Add(sensorItem);
                }
                else
                {
                    sensorItem.Status = kinectStatus;
                }

                if (KinectStatus.Connected == kinectStatus)
                {
                    // show a window
                    sensorItem.ShowWindow();
                }
                else
                {
                    sensorItem.CloseWindow();
                }
            }
        }

        //
        private void ShowStatussitup(KinectSensor kinectSensor, KinectStatus kinectStatus)
        {
            this.statusItemssitup.Add(new KinectStatusItem
            {
                Id = (null == kinectSensor) ? null : kinectSensor.DeviceConnectionId,
                Status = kinectStatus,
                DateTime = DateTime.Now
            });

            KinectSensorItemsitup sensorItem;
            this.sensorItemssitup.SensorLookup.TryGetValue(kinectSensor, out sensorItem);

            if (KinectStatus.Disconnected == kinectStatus)
            {
                if (sensorItem != null)
                {
                    this.sensorItemssitup.Remove(sensorItem);
                    sensorItem.CloseWindow();
                }
            }
            else
            {
                if (sensorItem == null)
                {
                    sensorItem = new KinectSensorItemsitup(kinectSensor, kinectSensor.DeviceConnectionId);
                    sensorItem.Status = kinectStatus;

                    this.sensorItemssitup.Add(sensorItem);
                }
                else
                {
                    sensorItem.Status = kinectStatus;
                }

                if (KinectStatus.Connected == kinectStatus)
                {
                    // show a window
                    sensorItem.ShowWindow();
                }
                else
                {
                    sensorItem.CloseWindow();
                }
            }
        }

        private void ShowStatusflatsupport(KinectSensor kinectSensor, KinectStatus kinectStatus)
        {
            this.statusItemsflatsupport.Add(new KinectStatusItem
            {
                Id = (null == kinectSensor) ? null : kinectSensor.DeviceConnectionId,
                Status = kinectStatus,
                DateTime = DateTime.Now
            });

            KinectSensorItemflatsupport sensorItem;
            this.sensorItemsflatsupport.SensorLookup.TryGetValue(kinectSensor, out sensorItem);

            if (KinectStatus.Disconnected == kinectStatus)
            {
                if (sensorItem != null)
                {
                    this.sensorItemsflatsupport.Remove(sensorItem);
                    sensorItem.CloseWindow();
                }
            }
            else
            {
                if (sensorItem == null)
                {
                    sensorItem = new KinectSensorItemflatsupport(kinectSensor, kinectSensor.DeviceConnectionId);
                    sensorItem.Status = kinectStatus;

                    this.sensorItemsflatsupport.Add(sensorItem);
                }
                else
                {
                    sensorItem.Status = kinectStatus;
                }

                if (KinectStatus.Connected == kinectStatus)
                {
                    // show a window
                    sensorItem.ShowWindow();
                }
                else
                {
                    sensorItem.CloseWindow();
                }
            }
        }

        private void KinectsStatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.ShowStatus(e.Sensor, e.Status);
        }

        //
        private void KinectsStatusChangedsitup(object sender, StatusChangedEventArgs e)
        {
            this.ShowStatussitup(e.Sensor, e.Status);
        }

        private void KinectsStatusChangedflatsupport(object sender, StatusChangedEventArgs e)
        {
            this.ShowStatusflatsupport(e.Sensor, e.Status);
        }

        private void ShowMoreInfo(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = e.OriginalSource as Hyperlink;
            if (hyperlink != null)
            {
                // Careful - ensure that this NavigateUri comes from a trusted source, as in this sample, before launching a process using it.
                Process.Start(new ProcessStartInfo(hyperlink.NavigateUri.ToString()));
            }

            e.Handled = true;
        }

        private void Sensor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;

            if (null == element)
            {
                return;
            }

            var sensorItem = element.DataContext as KinectSensorItem;

            if (null == sensorItem)
            {
                return;
            }
            sensorItem.ActivateWindow();
        }

        private void button1_click(object sender, RoutedEventArgs e)
        {
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChanged;

            // show status for each sensor that is found now.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                this.ShowStatus(kinect, kinect.Status);
            }
        }

        private void button2_click(object sender, RoutedEventArgs e)
        {
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChangedsitup;

            // show status for each sensor that is found now.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                this.ShowStatussitup(kinect, kinect.Status);
            }
        }

        private void button3_click(object sender, RoutedEventArgs e)
        {
            KinectSensor.KinectSensors.StatusChanged += this.KinectsStatusChangedflatsupport;

            // show status for each sensor that is found now.
            foreach (KinectSensor kinect in KinectSensor.KinectSensors)
            {
                this.ShowStatusflatsupport(kinect, kinect.Status);
            }
        }
    }
}
