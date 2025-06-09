using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox.Editor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="ImageToggle"/>.</summary>
    [CustomEditor(typeof(ImageToggle))]
    public sealed class ImageToggleEditor : EditorBase<ImageToggle>
    {
        /// <summary>The usage of the target.</summary>
        private readonly string[] usage = new[]
        {
            T.USAGE_REGIST_SPRITES,
            T.USAGE_ICON_TOGGLE_1,
        };

        /// <summary>Initialize the editor.</summary>
        public ImageToggleEditor() : base(L10n.Tr(T.DETAIL_ICON_TOGGLE))
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
            DrawList(
                usage,
                new ListOptions(ordered: true, tr: (t) => L10n.Tr(t)));
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            var images = serializedObject.FindProperty(
                ImageToggle.NAME_IMAGES);
            if (images.arraySize >= 2)
            {
                var image = images
                    .GetArrayElementAtIndex(1)
                    .objectReferenceValue as Image;
                if (image)
                {
                    image.sprite = GetSprite(
                        ImageToggle.NAME_SPRITES, TypedTarget.Index);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
