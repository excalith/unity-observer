using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Excalith.Observer.Types;

namespace Excalith.Observer.Editor
{
    public class ObserverWindow : EditorWindow
    {
        private bool m_IsHidden;
        private bool m_IsPaused;
        private Vector2 m_ScrollViewPos;
        private List<ObserverCategory> m_CategoryList = new List<ObserverCategory>();


        [MenuItem("Window/Tools/Observer")]
        public static void ShowWindow()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(ObserverWindow));
            window.titleContent = new GUIContent("Observer", EditorGUIUtility.IconContent("DotFrameDotted").image);
        }

        private void OnGUI()
        {
            ShowMenu();
            if (!Application.isPlaying || m_IsPaused)
            {
                m_IsHidden = false;
                ShowPauseView();
            }
            else
            {
                ShowScrollView();
            }
        }

        private void OnInspectorUpdate()
        {
            if (Application.isPlaying == false)
                return;

            m_CategoryList = new List<ObserverCategory>(Observer.Entries.Keys);

            Repaint();
        }

        private void ShowMenu()
        {
            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            EditorGUILayout.BeginHorizontal();

            string collapseButtonTitle = m_IsHidden ? "Expand" : "Collapse";
            if (GUILayout.Button(collapseButtonTitle, ObserverStyles.MenuButton))
            {
                m_IsHidden = !m_IsHidden;
                Observer.ToggleCategories(m_IsHidden);
            }

            GUI.backgroundColor = m_IsPaused ? ObserverStyles.YellowColor : ObserverStyles.DefaultColor;
            if (GUILayout.Button("Pause", ObserverStyles.MenuButton))
            {
                m_IsPaused = !m_IsPaused;
            }

            GUI.backgroundColor = ObserverStyles.RedColor;
            if (GUILayout.Button("Clear", ObserverStyles.MenuButton))
            {
                Observer.ClearAll();
                Repaint();
            }

            GUI.backgroundColor = ObserverStyles.DefaultColor;
            EditorGUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
        }

        private void ShowScrollView()
        {
            m_ScrollViewPos = EditorGUILayout.BeginScrollView(m_ScrollViewPos, ObserverStyles.ScrollView);
            GUI.backgroundColor = ObserverStyles.BackgroundColor;
            EditorGUILayout.BeginVertical(EditorStyles.textArea, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            GUILayout.Space(2);

            GUI.backgroundColor = ObserverStyles.DefaultColor;
            foreach (ObserverCategory category in m_CategoryList)
            {
                ShowCategoryButton(category);

                if (category.IsHidden)
                    continue;

                List<ObserverEntry> entryList = Observer.Entries[category];
                foreach (ObserverEntry entry in entryList)
                {
                    switch (entry.EntryMode)
                    {
                        default:
                        case ObserverEntryMode.Seperator:
                            ShowEntrySeperator(entry);
                            break;
                        case ObserverEntryMode.Log:
                            ShowEntryValue(entry);
                            break;
                        case ObserverEntryMode.Button:
                            ShowEntryButton(entry);
                            break;
                        case ObserverEntryMode.Value:
                            ShowEntryValueButton(entry);
                            break;
                    }

                    GUILayout.Space(5);
                }
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        private void ShowCategoryButton(ObserverCategory category)
        {
            GUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button((category.IsHidden ? ((char)9658).ToString() : ((char)9660).ToString()) + " " + category.CategoryName, ObserverStyles.CategoryButton))
                category.IsHidden = !category.IsHidden;


            if (GUILayout.Button(((char)10006).ToString(), ObserverStyles.CategoryButtonClear, GUILayout.Width(25)))
            {
                Observer.ClearCategory(category);
                Repaint();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5);
        }

        private void ShowEntrySeperator(ObserverEntry entry)
        {
            EditorGUILayout.LabelField(entry.EntryName, ObserverStyles.EntrySeperator);
        }

        private void ShowEntryButton(ObserverEntry entry)
        {
            if (GUILayout.Button(entry.EntryName, ObserverStyles.EntryActionButton))
            {
                if (entry.Callback != null)
                    entry.Callback.Invoke();
            }
        }

        private void ShowEntryValueButton(ObserverEntry entry)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(entry.EntryName, ObserverStyles.EntryValueLabel, GUILayout.Width(220));
            bool isLocked = false;
            switch (entry.EntryValueType)
            {
                case ObserverEntryType.String:
                    entry.CachedValue = EditorGUILayout.TextField((string)entry.CachedValue, ObserverStyles.EntryInputField);
                    break;
                case ObserverEntryType.Boolean:
                    entry.CachedValue = EditorGUILayout.ToggleLeft("", (bool)entry.CachedValue);
                    break;
                case ObserverEntryType.Integer:
                    entry.CachedValue = EditorGUILayout.IntField((int)entry.CachedValue, ObserverStyles.EntryInputField);
                    break;
                case ObserverEntryType.Float:
                    entry.CachedValue = EditorGUILayout.FloatField((float)entry.CachedValue, ObserverStyles.EntryInputField);
                    break;
                case ObserverEntryType.Double:
                    entry.CachedValue = EditorGUILayout.DoubleField((double)entry.CachedValue, ObserverStyles.EntryInputField);
                    break;
                case ObserverEntryType.Vector2:
                    entry.CachedValue = EditorGUILayout.Vector2Field("", (Vector2)entry.CachedValue);
                    break;
                case ObserverEntryType.Vector3:
                    entry.CachedValue = EditorGUILayout.Vector3Field("", (Vector3)entry.CachedValue);
                    break;
                case ObserverEntryType.Color:
                    entry.CachedValue = EditorGUILayout.ColorField("", (Color)entry.CachedValue);
                    break;
                case ObserverEntryType.Enum:
                    entry.CachedValue = EditorGUILayout.EnumPopup((System.Enum)entry.CachedValue);
                    break;
                case ObserverEntryType.None:
                    isLocked = true;
                    EditorGUILayout.LabelField("Unsupported Type", ObserverStyles.EntryValueLabel);
                    break;
            }

            EditorGUI.BeginDisabledGroup(isLocked);
            if (GUILayout.Button("Update", ObserverStyles.EntryActionButton))
            {
                if (entry.ValueCallback != null)
                {
                    entry.Value = entry.CachedValue;
                    entry.ValueCallback.Invoke(entry.CachedValue);
                }
            }
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndHorizontal();
        }

        private void ShowEntryValue(ObserverEntry entry)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(entry.EntryName, ObserverStyles.EntryValueTitleLabel);
            EditorGUILayout.LabelField(entry.Value.ToString(), ObserverStyles.EntryValueLabel);
            EditorGUILayout.EndHorizontal();
        }

        private void ShowPauseView()
        {
            GUI.backgroundColor = ObserverStyles.BackgroundColor;
            EditorGUILayout.BeginVertical(EditorStyles.textArea, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            GUILayout.Space(20);
            string text = !Application.isPlaying ? "Game Is Not Running" : "Observer Is Paused";
            EditorGUILayout.LabelField(text, ObserverStyles.PauseLabel);
            EditorGUILayout.EndVertical();
        }
    }
}