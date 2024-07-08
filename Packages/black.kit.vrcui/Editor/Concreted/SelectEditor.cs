using TMPro;
using UnityEditor;
using UnityEngine;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="Select"/>.</summary>
    [CustomEditor(typeof(Select))]
    public sealed class SelectEditor : EditorBase<Select>
    {
        /// <summary>Initialize the editor.</summary>
        public SelectEditor() : base(L10n.Tr(T.DETAIL_SELECT))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_COMPONENT), style);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(L10n.Tr(T.USAGE_EVENT_BUTTON), style);
            DrawUdonEvent(L10n.Tr(T.USAGE_DECREMENT));
            DrawUdonEvent(L10n.Tr(T.USAGE_INCREMENT));
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            var (values, index, size) =
                GetArrayProperty(Select.NAME_VALUES, TypedTarget.Index);
            var text = AutoCompleteObject<TextMeshProUGUI>(Select.NAME_TEXT);
            if (text && size > 0)
            {
                text.text =
                    values.GetArrayElementAtIndex(index).stringValue;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
