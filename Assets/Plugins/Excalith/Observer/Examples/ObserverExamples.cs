using UnityEngine;

namespace Excalith.Observer.Examples
{
    public class ObserverExamples : MonoBehaviour
    {
        private string m_StringTest = "Test Value";
        private bool m_BoolTest = true;
        private int m_IntTest = 1;
        private float m_FloatTest = 1.5f;
        private double m_DoubleTest = 1.5;
        private Vector2 m_Vec2Test = new Vector2(5, 5);
        private Vector3 m_Vec3Test = new Vector3(5, 5, 5);
        private Color m_ColorTest = new Color(128, 128, 128);
        private Vector4 m_UnsupportedTest = new Vector4(1, 1, 1, 1);
        private ObserverEntryType m_EnumTest;

        private void Start()
        {
            Observer.Button("Button Examples", "Function Call Button", TestFunction);

            Observer.Button("Button Examples", "Anonymous Call Button", () =>
            {
                Debug.Log("Anonymous Function Called");
            });

            Observer.Value("Update Examples", "Boolean Type", m_BoolTest, (object val) =>
            {
                m_BoolTest = (bool)val;
            });

            Observer.Value("Update Examples", "String Type", m_StringTest, (object val) =>
            {
                m_StringTest = (string)val;
            });

            Observer.Value("Update Examples", "Integer Type", m_IntTest, (object val) =>
            {
                m_IntTest = (int)val;
            });

            Observer.Value("Update Examples", "Float Type", m_FloatTest, (object val) =>
            {
                m_FloatTest = (float)val;
            });

            Observer.Value("Update Examples", "Double Type", m_DoubleTest, (object val) =>
            {
                m_DoubleTest = (double)val;
            });

            // Observer.Seperator("Update Examples");

            Observer.Value("Update Examples", "Vector2 Type", m_Vec2Test, (object val) =>
            {
                m_Vec2Test = (Vector2)val;
            });

            Observer.Value("Update Examples", "Vector3 Type", m_Vec3Test, (object val) =>
            {
                m_Vec3Test = (Vector3)val;
            });

            Observer.Value("Update Examples", "Color Type", m_ColorTest, (object val) =>
            {
                m_ColorTest = (Color)val;
            });

            Observer.Value("Update Examples", "Enum Type", m_EnumTest, (object val) =>
            {
                m_EnumTest = (ObserverEntryType)val;
            });

            // Observer.Header("Update Examples", "Header Example");

            Observer.Value("Update Examples", "Vector4 Type", m_UnsupportedTest, (object val) =>
            {
                m_UnsupportedTest = (Vector4)val;
            });
        }

        private void Update()
        {
            Observer.Log("Log Examples", "String Value", m_StringTest);
            Observer.Log("Log Examples", "Boolean Value", m_BoolTest);
            Observer.Log("Log Examples", "Int Value", m_IntTest);
            Observer.Log("Log Examples", "Float Value", m_FloatTest);
            Observer.Log("Log Examples", "Double Value", m_DoubleTest);
            Observer.Log("Log Examples", "Vector2 Value", m_Vec2Test);
            Observer.Log("Log Examples", "Vector3 Value", m_Vec3Test);
            Observer.Log("Log Examples", "Color Value", m_ColorTest);
            Observer.Log("Log Examples", "Enum Value", m_EnumTest);
            Observer.Log("Log Examples", "Vector4 Value", m_UnsupportedTest);
        }

        private void TestFunction()
        {
            Debug.Log("Function Called");
        }
    }
}