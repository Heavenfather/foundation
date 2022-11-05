﻿using UnityEditor;
using UnityEngine;


namespace Pancake.Editor
{
    [ViewTarget(typeof(ToggleLeftAttribute))]
    sealed class ToggleLeftView : FieldView
    {
        /// <summary>
        /// Called for drawing element view GUI.
        /// </summary>
        /// <param name="position">Position of the Serialized field.</param>
        /// <param name="serializedField">Serialized field with ViewAttribute.</param>
        /// <param name="label">Label of Serialized field.</param>
        public override void OnGUI(Rect position, SerializedField serializedField, GUIContent label)
        {
            serializedField.GetSerializedProperty().boolValue = EditorGUI.ToggleLeft(position, label, serializedField.GetSerializedProperty().boolValue);
        }
    }
}