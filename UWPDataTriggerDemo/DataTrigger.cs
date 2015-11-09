﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPDataTriggerDemo
{
    public class DataTrigger : StateTriggerBase
    {
        #region DataValue
        public static object GetDataValue(DependencyObject obj)
        {
            return (object)obj.GetValue(DataValueProperty);
        }

        public static void SetDataValue(DependencyObject obj, object value)
        {
            obj.SetValue(DataValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for DataValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataValueProperty =
            DependencyProperty.RegisterAttached("DataValue", typeof(object), typeof(DataTrigger), new PropertyMetadata(null, DataValueChanged));


        private static void DataValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            object triggerValue = target.GetValue(DataTrigger.TriggerValueProperty);
            TriggerStateCheck(target, e.NewValue, triggerValue);
        }
        #endregion
        #region TriggerValue


        public static object GetTriggerValue(DependencyObject obj)
        {
            return (object)obj.GetValue(TriggerValueProperty);
        }

        public static void SetTriggerValue(DependencyObject obj, object value)
        {
            obj.SetValue(TriggerValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for TriggerValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriggerValueProperty =
            DependencyProperty.RegisterAttached("TriggerValue", typeof(object), typeof(DataTrigger), new PropertyMetadata(null, TriggerValueChanged));


        private static void TriggerValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            object dataValue = target.GetValue(DataTrigger.DataValueProperty);
            TriggerStateCheck(target, dataValue, e.NewValue);
        }


        #endregion
        private static void TriggerStateCheck(DependencyObject target, object dataValue, object triggerValue)
        {
            DataTrigger trigger = target as DataTrigger;
            if (trigger == null) return;
            Boolean b;
            if (null == triggerValue)
                b = null == dataValue;
            else
                b = triggerValue.Equals(dataValue);

            trigger.SetActive(b);
        }
    }
}
