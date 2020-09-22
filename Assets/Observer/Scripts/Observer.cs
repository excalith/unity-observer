using System;
using System.Collections.Generic;
using System.Linq;
using Excalith.Observer.Types;

namespace Excalith.Observer
{
    public enum ObserverEntryType { None, Boolean, String, Integer, Float, Double, Vector2, Vector3, Color, Enum }

    public static class Observer
    {
        public static Dictionary<ObserverCategory, List<ObserverEntry>> Entries = new Dictionary<ObserverCategory, List<ObserverEntry>>();

        /// <summary>
        /// Adds an empty seperator
        /// </summary>
        /// <param name="_category">Category of the seperator</param>
        public static void Seperator(string _category)
        {
#if UNITY_EDITOR
            ObserverEntry newEntry = new ObserverEntry();
            AddEntry(_category, newEntry);
#endif
        }

        /// <summary>
        /// Adds a header
        /// </summary>
        /// <param name="_category">Category of the header</param>
        /// <param name="_displayName">Title</param>
        public static void Header(string _category, string _displayName)
        {
#if UNITY_EDITOR
            ObserverEntry newEntry = new ObserverEntry(_displayName);
            AddEntry(_category, newEntry);
#endif
        }

        /// <summary>
        /// Displays a value within category
        /// </summary>
        /// <param name="_category">Category name</param>
        /// <param name="_displayName">Display name</param>
        /// <param name="_value">Display value</param>
        public static void Log(string _category, string _displayName, object _value)
        {
#if UNITY_EDITOR
            ObserverEntry newEntry = new ObserverEntry(_displayName, _value);
            AddEntry(_category, newEntry);
#endif
        }

        /// <summary>
        /// Adds a button to update it with a given value
        /// </summary>
        /// <param name="_category">Category name</param>
        /// <param name="_displayName">Display name</param>
        /// <param name="_value">Initial value</param>
        /// <param name="_valueCallback">Callback</param>
        public static void Value(string _category, string _displayName, object _value, Action<object> _valueCallback)
        {
#if UNITY_EDITOR
            ObserverEntry newEntry = new ObserverEntry(_displayName, _value, _valueCallback);
            AddEntry(_category, newEntry);
#endif
        }

        /// <summary>
        /// Adds a button to call action
        /// </summary>
        /// <param name="_category">Category name</param>
        /// <param name="_displayName">Display name</param>
        /// <param name="_callback">Callback</param>
        public static void Button(string _category, string _displayName, Action _callback)
        {
#if UNITY_EDITOR
            // ObserverEntry newEntry = new ObserverEntry(_displayName, _callback, true);
            ObserverEntry newEntry = new ObserverEntry(_displayName, _callback);
            AddEntry(_category, newEntry);
#endif
        }

        /// <summary>
        /// Clears a category
        /// </summary>
        /// <param name="_category">Category object</param>
        public static void ClearCategory(ObserverCategory _category)
        {
#if UNITY_EDITOR
            _category.IsHidden = true;
            Entries.Remove(_category);
#endif
        }

        /// <summary>
        /// Clears all categories
        /// </summary>
        public static void ClearAll()
        {
#if UNITY_EDITOR
            foreach (ObserverCategory category in Entries.Keys)
            {
                category.IsHidden = true;
            }

            Entries.Clear();
#endif
        }

        /// <summary>
        /// Toggles all categories display status
        /// </summary>
        /// <param name="isHidden">Should hide or not</param>
        public static void ToggleCategories(bool isHidden)
        {
#if UNITY_EDITOR
            foreach (ObserverCategory category in Entries.Keys)
            {
                category.IsHidden = isHidden;
            }
#endif
        }

        private static void AddEntry(string _category, ObserverEntry _entry)
        {
#if UNITY_EDITOR
            KeyValuePair<ObserverCategory, List<ObserverEntry>> kvp = (from k in Entries.AsEnumerable()
                                                                       where k.Key.CategoryName == _category
                                                                       select k).FirstOrDefault();
            // If we have category
            if (kvp.Key != null)
            {
                // Get Entry list from Corresponding category
                List<ObserverEntry> entryList = kvp.Value;

                // Try to find existing Entry
                ObserverEntry entry = entryList.FirstOrDefault(name => name.EntryName == _entry.EntryName);

                // Add new or update existing entry
                if (entry == null)
                    entryList.Add(_entry);
                else
                    entry.Value = _entry.Value;
            }
            else
            {
                Entries.Add(new ObserverCategory(_category), new List<ObserverEntry> { _entry });
            }
#endif
        }
    }
}