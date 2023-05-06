using UnityEngine;
using UnityEditor;

namespace com.bandags.spacegame.utilities {
    [CustomPropertyDrawer(typeof(UsePropertyNameAttribute))]
    public class UsePropertyNameAttributeDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.name.EndsWith("k__BackingField")) {
                FixLabel(label);
            }
            EditorGUI.PropertyField(position, property, label, true);
        }

        private static void FixLabel(GUIContent label) {
            var text = label.text;
            var firstLetter = char.ToUpper(text[1]);
            label.text = firstLetter + text.Substring(2, text.Length - 19);
        }
    }
}