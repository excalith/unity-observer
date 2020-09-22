using UnityEditor;
using UnityEngine;

namespace Excalith.Observer.Editor
{
    public static class ObserverStyles
    {
        private static bool m_HasInitialized = false;
        
        private static GUIStyle m_MenuButton;
        private static GUIStyle m_ScrollView;
        private static GUIStyle m_CategoryButton;
        private static GUIStyle m_CategoryButtonClear;
        private static GUIStyle m_EntryActionButton;
        private static GUIStyle m_EntryValueTitleLabel;
        private static GUIStyle m_EntryValueDescLabel;
        private static GUIStyle m_EntryInputField;
        private static GUIStyle m_EntrySeperator;
        private static GUIStyle m_PauseLabel;

        public static Color DefaultColor = GUI.backgroundColor;
        public static Color GreenColor = new Color(0.2f, 0.8f, 0.4f, 1);
        public static Color YellowColor  = new Color(0.9339623f, 0.593774f, 0.2511125f, 1);
        public static Color RedColor = new Color(0.9333333f, 0.3569649f, 0.2509804f, 1);
        public static Color m_BackgroundColor = GUI.backgroundColor;

        private static void Initialize()
        {
            if (m_HasInitialized)
                return;

            m_HasInitialized = true;

            Color textColor = EditorGUIUtility.isProSkin
                ? Color.white
                : Color.black;

            m_BackgroundColor = EditorGUIUtility.isProSkin
                ? new Color(0.52f, 0.52f, 0.52f, 1)
                : new Color(0.75f, 0.75f, 0.75f, 1);

            // Menu Button
            m_MenuButton = new GUIStyle(GUI.skin.button);
            m_MenuButton.padding = new RectOffset(3, 3, 4, 4);
            m_MenuButton.alignment = TextAnchor.MiddleCenter;
            m_MenuButton.fontStyle = FontStyle.Bold;

            // Scroll View
            m_ScrollView = new GUIStyle(GUI.skin.scrollView);
            m_ScrollView.padding = new RectOffset(5, 5, 5, 5);

            // Category Button
            m_CategoryButton = new GUIStyle(GUI.skin.button);
            m_CategoryButton.padding = new RectOffset(5, 5, 8, 8);
            m_CategoryButton.alignment = TextAnchor.MiddleLeft;
            m_CategoryButton.fontStyle = FontStyle.Bold;
            m_CategoryButton.normal.textColor = textColor;
            m_CategoryButton.richText = true;

            // Category Button Clear
            m_CategoryButtonClear = new GUIStyle(GUI.skin.button);
            m_CategoryButtonClear.padding = new RectOffset(5, 5, 8, 8);
            m_CategoryButtonClear.alignment = TextAnchor.MiddleCenter;
            m_CategoryButtonClear.fontStyle = FontStyle.Normal;
            m_CategoryButtonClear.normal.textColor = textColor;

            // Entry Action Button
            m_EntryActionButton = new GUIStyle(GUI.skin.button);
            m_EntryActionButton.padding = new RectOffset(5, 4, 4, 5);
            m_EntryActionButton.alignment = TextAnchor.MiddleCenter;
            m_EntryActionButton.normal.textColor = textColor;

            // Entry Value Header Label
            m_EntryValueTitleLabel = new GUIStyle(GUI.skin.label);
            m_EntryValueTitleLabel.padding = new RectOffset(5, 3, 2, 2);
            m_EntryValueTitleLabel.fontStyle = FontStyle.Bold;
            m_EntryValueTitleLabel.normal.textColor = textColor;
            m_EntryValueTitleLabel.richText = true;

            // Entry Value Description Label
            m_EntryValueDescLabel = new GUIStyle(GUI.skin.label);
            m_EntryValueDescLabel.padding = new RectOffset(5, 3, 2, 2);
            m_EntryValueDescLabel.normal.textColor = textColor;
            m_EntryValueDescLabel.fontStyle = FontStyle.Bold;
            m_EntryValueDescLabel.richText = true;

            // Entry Input Field
            m_EntryInputField = new GUIStyle(GUI.skin.textArea);
            m_EntryInputField.padding = new RectOffset(5, 4, 4, 5);
            m_EntryInputField.fixedHeight = 24;
            m_EntryInputField.normal.textColor = textColor;
            
            // Entry Seperator & Header
            m_EntrySeperator = new GUIStyle(GUI.skin.label);
            m_EntrySeperator.padding = new RectOffset(5, 3, 2, 2);
            m_EntrySeperator.fontStyle = FontStyle.Bold;
            m_EntrySeperator.normal.textColor = textColor;
            m_EntrySeperator.richText = true;

            // Pause Label
            m_PauseLabel = new GUIStyle(GUI.skin.label);
            m_PauseLabel.stretchHeight = true;
            m_PauseLabel.fontSize = 15;
            m_PauseLabel.alignment = TextAnchor.MiddleCenter;
            m_PauseLabel.fontStyle = FontStyle.Bold;
            m_PauseLabel.normal.textColor = textColor;
        }

        public static Color BackgroundColor
        {
            get
            {
                Initialize();
                return m_BackgroundColor;
            }
            set
            {
                m_BackgroundColor = value;
            }
        }

        public static GUIStyle MenuButton
        {
            get
            {
                Initialize();
                return m_MenuButton;
            }
            set
            {
                m_MenuButton = value;
            }
        }

        public static GUIStyle ScrollView
        {
            get
            {
                Initialize();
                return m_ScrollView;
            }
            set
            {
                m_ScrollView = value;
            }
        }

        public static GUIStyle CategoryButton
        {
            get
            {
                Initialize();
                return m_CategoryButton;
            }
            set
            {
                m_CategoryButton = value;
            }
        }

        public static GUIStyle CategoryButtonClear
        {
            get
            {
                Initialize();
                return m_CategoryButtonClear;
            }
            set
            {
                m_CategoryButtonClear = value;
            }
        }

        public static GUIStyle EntryActionButton
        {
            get
            {
                Initialize();
                return m_EntryActionButton;
            }
            set
            {
                m_EntryActionButton = value;
            }
        }

        public static GUIStyle EntryValueTitleLabel
        {
            get
            {
                Initialize();
                return m_EntryValueTitleLabel;
            }
            set
            {
                m_EntryValueTitleLabel = value;
            }
        }

        public static GUIStyle EntryValueLabel
        {
            get
            {
                Initialize();
                return m_EntryValueDescLabel;
            }
            set
            {
                m_EntryValueDescLabel = value;
            }
        }

        public static GUIStyle EntryInputField
        {
            get
            {
                Initialize();
                return m_EntryInputField;
            }
            set
            {
                m_EntryInputField = value;
            }
        }

        public static GUIStyle EntrySeperator
        {
            get
            {
                Initialize();
                return m_EntrySeperator;
            }
            set
            {
                m_EntrySeperator = value;
            }
        }

        public static GUIStyle PauseLabel
        {
            get
            {
                Initialize();
                return m_PauseLabel;
            }
            set
            {
                m_PauseLabel = value;
            }
        }
    }
}