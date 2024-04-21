using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.vrcui.Editor
{
    /// <summary>
    /// The inspector of the <see cref="ToggleWithAnimation"/>.
    /// </summary>
    [CustomEditor(typeof(ToggleWithAnimation))]
    public sealed class ToggleWithAnimationEditor
        : EditorBase<ToggleWithAnimation>
    {
        /// <summary>The usage of the target.</summary>
        private readonly string[] usage = new[]
        {
            T.USAGE_LINK_ANIMATOR,
            T.USAGE_LINK_TOGGLE,
            T.USAGE_EVENT_TOGGLE,
        };

        /// <summary>Initialize the editor.</summary>
        public ToggleWithAnimationEditor()
            : base(L10n.Tr(T.DETAIL_TOGGLE_WITH_ANIMATION))
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
            DrawList(usage, new() { Ordered = true });
            DrawUdonEvent(T.USAGE_ON_VALUE_CHANGED);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            var animator = AutoCompleteObject<Animator>(
                ToggleWithAnimation.NAME_ANIMATOR);
            var toggle = AutoCompleteObject<Toggle>(
                ToggleWithAnimation.NAME_TOGGLE);
            var param = serializedObject.FindProperty(
                ToggleWithAnimation.NAME_PARAMETER);
            if (animator)
            {
                animator.SetBool(
                    param.stringValue, !!toggle && toggle.isOn);
                animator.Update(Time.deltaTime * 100f);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
