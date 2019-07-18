namespace Microsoft.Samples.Kinect.KinectExplorer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.Kinect;

    /// <summary>
    /// An ObservableCollection of KinectSensorItems, used to track collection changes.
    /// </summary>
    public class KinectSensorItemCollectionflatsupport : ObservableCollection<KinectSensorItemflatsupport>
    {
        private readonly Dictionary<KinectSensor, KinectSensorItemflatsupport> sensorLookup = new Dictionary<KinectSensor, KinectSensorItemflatsupport>();
        public Dictionary<KinectSensor, KinectSensorItemflatsupport> SensorLookup
        {
            get
            {
                return this.sensorLookup;
            }
        }

        protected override void InsertItem(int index, KinectSensorItemflatsupport item)
        {
            if (item == null)
            {
                throw new ArgumentException("Inserted item can't be null.", "item");
            }

            this.SensorLookup.Add(item.Sensor, item);
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this.SensorLookup.Remove(this[index].Sensor);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            this.SensorLookup.Clear();
            base.ClearItems();
        }
    }
}
