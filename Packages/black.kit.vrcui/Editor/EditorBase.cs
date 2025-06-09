using UdonSharp;
using UnityEditor;
using UnityEngine;
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

        /// <summary>Get sprite from an array property.</summary>
        /// <param name="propertyName">Name of the array property.</param>
        /// <param name="index">Index of the array.</param>
        /// <returns>The sprite at the specified index, or null if none.</returns>
        protected Sprite GetSprite(string propertyName, int index)
        {
            var (property, i, _) = GetArrayProperty(propertyName, index);
            if (i < 0)
            {
                return null; // property array is empty
            }
            var element = property.GetArrayElementAtIndex(i);
            return element.objectReferenceValue as Sprite;
        }
    }
}
