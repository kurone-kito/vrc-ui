using UdonSharp;
using UnityEditor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The base class for the custom editor.</summary>
    /// <typeparam name="Tb">The type of the target.</typeparam>
    public abstract class SelectEditorBase<Tb> : EditorBase<Tb>
        where Tb : UdonSharpBehaviour
    {
        /// <summary>Initialize the editor.</summary>
        /// <param name="details">The details of the target.</param>
        public SelectEditorBase(string details) : base(details)
        {
        }

        /// <summary>Get the property of the array.</summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="index">The index of the array.</param>
        /// <returns>The property of the array.</returns>
        protected (SerializedProperty, int, int) GetArrayProperty(
            string name, int index)
        {
            var property = serializedObject.FindProperty(name);
            var size = property.arraySize;
            var i = index < 0 ? size + index % size : index;
            return new(property, i % size, size);
        }
    }
}
