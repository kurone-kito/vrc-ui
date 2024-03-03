using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.vrcui.Editor
{
    /// <summary>
    /// The inspector of the <see cref="IconToggleEditor"/>.
    /// </summary>
    [CustomEditor(typeof(IconToggle))]
    public sealed class IconToggleEditor : SelectEditorBase<IconToggle>
    {
        /// <summary>The usage of the target.</summary>
        private readonly string[] usage = new[]
        {
            T.USAGE_ICON_TOGGLE_0,
            T.USAGE_ICON_TOGGLE_1,
        };

        /// <summary>Initialize the editor.</summary>
        public IconToggleEditor() : base(L10n.Tr(T.DETAIL_ICON_TOGGLE))
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
            DrawList(usage);
            EditorGUILayout.EndVertical();
            base.OnInspectorGUI();

            serializedObject.Update();
            var image = serializedObject
                .FindProperty(IconToggle.NAME_IMAGES)
                .GetArrayElementAtIndex(1)
                .objectReferenceValue as Image;
            if (image)
            {
                image.sprite = GetSprite();
            }
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>Get the sprite of the icon.</summary>
        /// <returns>The sprite of the icon.</returns>
        private Sprite GetSprite()
        {
            var (sprites, index, _) = GetArrayProperty(
                IconToggle.NAME_SPRITES, TypedTarget.Index);
            var element = sprites.GetArrayElementAtIndex(index);
            return element.objectReferenceValue as Sprite;
        }
    }
}
