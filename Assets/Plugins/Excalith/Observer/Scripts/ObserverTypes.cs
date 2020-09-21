using System;
using UnityEngine;

namespace Excalith.Observer.Types
{
    public enum ObserverEntryMode { Seperator, Log, Button, Value }
    public class ObserverCategory
    {
        public string CategoryName;
        public bool IsHidden;

        public ObserverCategory(string _categoryName)
        {
            CategoryName = _categoryName;
            IsHidden = false;
        }
    }

    public class ObserverEntry
    {
        public string EntryName;
        public object Value;
        public Action Callback;
        public Action<object> ValueCallback;
        public ObserverEntryMode EntryMode;
        public ObserverEntryType EntryValueType;
        public object CachedValue;

        /// <summary>
        /// Create Seperator Entry
        /// </summary>
        public ObserverEntry()
        {
            EntryMode = ObserverEntryMode.Seperator;
            EntryName = string.Empty;
        }

        /// <summary>
        /// Create Header Entry
        /// </summary>
        /// <param name="_title">Header Title</param>
        public ObserverEntry(string _title)
        {
            EntryMode = ObserverEntryMode.Seperator;
            EntryName = _title;
        }

        /// <summary>
        /// Create Log Entry
        /// </summary>
        /// <param name="_title">Log Title</param>
        /// <param name="_value">Log Value</param>
        public ObserverEntry(string _title, object _value)
        {
            EntryMode = ObserverEntryMode.Log;
            EntryName = _title;
            CachedValue = _value;
            Value = _value;
        }

        /// <summary>
        /// Create Value Entry
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_value"></param>
        /// <param name="_valueCallback"></param>
        public ObserverEntry(string _title, object _value, Action<object> _valueCallback)
        {
            EntryMode = ObserverEntryMode.Value;
            EntryName = _title;
            CachedValue = _value;
            Value = _value;
            ValueCallback = _valueCallback;

            if (Value.GetType() == typeof(string))
                EntryValueType = ObserverEntryType.String;
            else if (Value.GetType() == typeof(bool))
                EntryValueType = ObserverEntryType.Boolean;
            else if (Value.GetType() == typeof(int))
                EntryValueType = ObserverEntryType.Integer;
            else if (Value.GetType() == typeof(float))
                EntryValueType = ObserverEntryType.Float;
            else if (Value.GetType() == typeof(double))
                EntryValueType = ObserverEntryType.Double;
            else if (Value.GetType() == typeof(Vector2))
                EntryValueType = ObserverEntryType.Vector2;
            else if (Value.GetType() == typeof(Vector3))
                EntryValueType = ObserverEntryType.Vector3;
            else if (Value.GetType() == typeof(Color))
                EntryValueType = ObserverEntryType.Color;
            else if (Value.GetType().IsEnum)
                EntryValueType = ObserverEntryType.Enum;
            else
                EntryValueType = ObserverEntryType.None;
        }

        /// <summary>
        /// Create Button Entry
        /// </summary>
        /// <param name="_displayName"></param>
        /// <param name="_buttonCallback"></param>
        public ObserverEntry(string _displayName, Action _buttonCallback)
        {
            EntryMode = ObserverEntryMode.Button;
            EntryName = _displayName;
            Callback = _buttonCallback;
        }
    }
}
