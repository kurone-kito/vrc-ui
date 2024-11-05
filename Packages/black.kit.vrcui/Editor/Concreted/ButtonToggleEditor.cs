using black.kit.toybox.Editor;
using UnityEditor;
using UnityEngine.UI;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="ButtonToggle"/>.</summary>
    [CustomEditor(typeof(ButtonToggle))]
    public sealed class ButtonToggleEditor : EditorBase<ButtonToggle>
    {
        /// <summary>Initialize the editor.</summary>
        public ButtonToggleEditor() : base(L10n.Tr(T.DETAIL_BUTTON_TOGGLE))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            base.OnInspectorGUI();

            serializedObject.Update();
            var toggle = TypedTarget.GetComponent<Toggle>();
            if (toggle.group)
            {
                var arrayProp = serializedObject.FindProperty(ButtonToggle.NAME_TOGGLES);
                toggle.group.CompleteToggles(arrayProp);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
