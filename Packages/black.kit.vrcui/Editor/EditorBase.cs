using UdonSharp;
using UnityEditor;
using black.kit.toybox.Editor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The base class for the custom editor.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class EditorBase<Tb> : toybox.Editor.EditorBase<Tb>
        where Tb : UdonSharpBehaviour
    {
        /// <summary>The information of the banner.</summary>
        private static readonly BannerInit bannerInit = new()
        {
            AspectRatio = 3.77448071f,
            Unique = "527e92187b43d4f45adc44eb8b19d697"
        };

        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        public EditorBase(string details) : base(details, bannerInit)
        {
        }

        /// <summary>
        /// Draw the Udon event of the inspector.
        /// </summary>
        /// <param name="argument">The argument of the Udon event.</param>
        protected void DrawUdonEvent(string argument) =>
            EditorUtils.DrawUdonEvent(argument, style: defaultStyle.Value);

        /// <summary>Draw the list of the inspector.</summary>
        /// <param name="list">The list to draw.</param>
        /// <param name="selectable">The list is selectable.</param>
        protected void DrawList(string[] list, ListOptions options = new ()) =>
            EditorUtils.DrawList(list, style: defaultStyle.Value, options);

        /// <summary>Get the property of the array.</summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="index">The index of the array.</param>
        /// <returns>The property of the array.</returns>
        protected (SerializedProperty, int, int) GetArrayProperty(
            string name, int index)
        {
            var property = serializedObject.FindProperty(name);
            var s = property.arraySize;
            return (
                property,
                s == 0 ? -1 : ((index < 0 ? s + index % s : index) % s),
                s);
        }
    }
}
