using System;
using System.Linq;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace black.kit.vrcui.Editor
{
    /// <summary>The base class for the custom editor.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class EditorBase<Tb> : UnityEditor.Editor
        where Tb : UdonSharpBehaviour
    {
        /// <summary>The options of the list of the inspector.</summary>

        protected struct ListOptions
        {
            /// <summary>The list is ordered.</summary>
            public bool ordered;

            /// <summary>The list is selectable.</summary>
            public bool selectable;

            public readonly void Deconstruct(
                out bool ordered, out bool selectable)
            {
                ordered = this.ordered;
                selectable = this.selectable;
            }
        }

        /// <summary>The unique identifier of the banner.</summary>
        private const string BANNER_UNIQUE =
            "527e92187b43d4f45adc44eb8b19d697";

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        public EditorBase(string details) : base()
        {
            this.details = details;
        }

        /// <summary>The default style of the inspector.</summary>
        protected readonly Lazy<GUIStyle> defaultStyle =
            new(() => new(GUI.skin.label)
            {
                richText = true,
                wordWrap = true
            });

        /// <summary>The details of the target.</summary>
        private readonly string details;

        /// <summary>The texture of the banner.</summary>
        private Texture banner;

        /// <summary>The target of the inspector.</summary>
        protected Tb TypedTarget => target as Tb;

        /// <summary>
        /// Auto-complete the object reference of the specified component.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The component.</returns>
        protected T AutoCompleteObject<T>(string propertyName)
            where T : Component
        {
            var target = TypedTarget;
            var component = target.GetComponent<T>();
            var prop = serializedObject.FindProperty(propertyName);
            if (component && prop.objectReferenceValue == null)
            {
                prop.objectReferenceValue = component;
            }
            return prop.objectReferenceValue as T ?? component;
        }

        /// <summary>Draw the banner of the inspector.</summary>
        protected void DrawBanner()
        {
            if (!banner)
            {
                LoadTexture();
            }
            if (!banner)
            {
                return;
            }
            const float PADDING = 20f;
            var width = EditorGUIUtility.currentViewWidth - PADDING * 2f;
            var rect =
                new Rect()
                {
                    width = width,
                    height = width * .25671406f
                };
            var rect2 = GUILayoutUtility.GetRect(rect.width, rect.height);
            rect.x = PADDING - 4f;
            rect.y = rect2.y;
            EditorGUILayout.Space();
            GUI.DrawTexture(rect, banner, ScaleMode.StretchToFill);
            EditorGUILayout.Space();
        }

        /// <summary>
        /// Draw the Udon event of the inspector.
        /// </summary>
        /// <param name="argument">The argument of the Udon event.</param>
        protected void DrawUdonEvent(string argument)
        {
            var list = new[]
            {
                T.USAGE_RUNTIME_ONLY,
                T.USAGE_THIS_COMPONENT,
                T.USAGE_SEND_CUSTOM_EVENT,
                argument,
            };
            EditorGUI.indentLevel++;
            DrawList(list, new() { selectable = true });
            EditorGUI.indentLevel--;
        }

        /// <summary>Draw the list of the inspector.</summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="selectable">The list is selectable.</param>
        protected void DrawList(string[] list, ListOptions options = new ())
        {
            var (ordered, selectable) = options;
            var style = defaultStyle.Value;
            Action<string> output = selectable
                ? item => EditorGUILayout.SelectableLabel(item, style)
                : item => EditorGUILayout.LabelField(item, style);
            Func<string, int, string> getText = ordered
                ? (item, index) => $"{index + 1}.{L10n.Tr(item)}"
                : (item, _) => L10n.Tr(item);
            foreach (
                var (item, index)
                in list.Select((item, index) => (item, index)))
            {
                output(getText(item, index));
            }
        }

        /// <summary>Draw the description of the inspector.</summary>
        protected void DrawDetails()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            var style = defaultStyle.Value;
            var className = TypedTarget.GetType().FullName;
            EditorGUILayout.LabelField($"<b>{className}</b>", style);
            EditorGUILayout.LabelField(details, style);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        /// <summary>Load the texture of the banner.</summary>
        private void LoadTexture()
        {
            var path = AssetDatabase.GUIDToAssetPath(BANNER_UNIQUE);
            banner = AssetDatabase.LoadAssetAtPath(
                path, typeof(Texture)) as Texture;
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable() => LoadTexture();
#pragma warning restore IDE0051
    }
}
