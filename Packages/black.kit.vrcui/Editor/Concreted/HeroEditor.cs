using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox.Editor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="Hero"/>.</summary>
    [CustomEditor(typeof(Hero))]
    public sealed class HeroEditor : EditorBase<Hero>
    {
        /// <summary>The usage of the target.</summary>
        private readonly string[] usage = new string[]
        {
            T.USAGE_REGIST_SPRITES,
            T.USAGE_HERO_1,
        };

        /// <summary>Initialize the editor.</summary>
        public HeroEditor() : base(L10n.Tr(T.DETAIL_HERO))
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
            var image = AutoCompleteObject<Image>(Hero.NAME_IMAGE);
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
                Hero.NAME_SPRITES, TypedTarget.Index);
            if (index < 0)
            {
                return null; // 'sprites' is empty
            }
            var element = sprites.GetArrayElementAtIndex(index);
            return element.objectReferenceValue as Sprite;
        }
    }
}
