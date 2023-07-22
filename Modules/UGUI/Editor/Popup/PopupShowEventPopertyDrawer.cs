﻿using System.Reflection;
using Pancake.Apex;
using Pancake.ExLibEditor;
using Pancake.ScriptableEditor;
using Pancake.UI;
using UnityEditor;
using UnityEngine;

namespace PancakeEditor
{
    [CustomPropertyDrawer(typeof(PopupShowEvent), true)]
    public class PopupShowEventPopertyDrawer : ScriptableBasePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var targetObject = property.objectReferenceValue;
            if (targetObject == null)
            {
                DrawIfNull(position, property, label);
                return;
            }

            bool isNeedIndent = fieldInfo.FieldType.IsCollectionType() && fieldInfo.GetCustomAttribute<ArrayAttribute>(false) != null;
            DrawIfNotNull(position, property, label, property.objectReferenceValue, isNeedIndent);

            EditorGUI.EndProperty();
        }

        protected override void DrawShortcut(Rect position, SerializedProperty property, Object targetObject) { }
    }
}