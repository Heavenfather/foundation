﻿using Pancake;
using Pancake.Apex;
using Pancake.ApexEditor;
using UnityEditor;
using UnityEngine;

namespace PancakeEditor
{
    public class PopupPickupDrawer : FieldView, ITypeValidationCallback
    {
        private const string NAME_CLASS_INHERIT = "Pancake.UI.UIPopup";

        public override void OnGUI(Rect position, SerializedField element, GUIContent label)
        {
            position = EditorGUI.PrefixLabel(position, label);

            string buttonLabel = "Select type...";

            if (!string.IsNullOrEmpty(element.GetString()))
            {
                if (Editor.TryFindTypeByFullName(NAME_CLASS_INHERIT, out var type))
                {
                    var result = type.GetAllSubClass();
                    foreach (var type1 in result)
                    {
                        if (type1.Name == element.GetString())
                        {
                            buttonLabel = element.GetString();
                            break;
                        }

                        buttonLabel = "Failed load...";
                    }
                }
            }

            if (GUI.Button(position, buttonLabel, EditorStyles.popup))
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("None (-1)"),
                    false,
                    () =>
                    {
                        element.SetString(string.Empty);
                        element.GetSerializedObject().ApplyModifiedProperties();
                    });

                if (Editor.TryFindTypeByFullName(NAME_CLASS_INHERIT, out var type))
                {
                    var result = type.GetAllSubClass();
                    for (var i = 0; i < result.Count; i++)
                    {
                        if (i == 0) menu.AddSeparator("");

                        int cachei = i;
                        menu.AddItem(new GUIContent($"{result[i].Name} ({i})"),
                            false,
                            () =>
                            {
                                element.SetString(result[cachei].Name);
                                element.GetSerializedObject().ApplyModifiedProperties();
                            });
                    }
                }

                menu.DropDown(position);
            }
        }

        /// <summary>
        /// Return true if this property valid the using with this attribute.
        /// If return false, this property attribute will be ignored.
        /// </summary>
        /// <param name="property">Reference of serialized property.</param>
        public bool IsValidProperty(SerializedProperty property) { return property.propertyType == SerializedPropertyType.String; }
    }
}