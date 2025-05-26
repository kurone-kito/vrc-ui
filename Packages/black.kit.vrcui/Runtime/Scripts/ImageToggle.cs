using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox;

namespace black.kit.vrcui
{
    /// <summary>The toggle switch of the icon.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ImageToggle : SelectBase
    {
        /// <summary>The property name of the images.</summary>
        public const string NAME_IMAGES = nameof(images);

        /// <summary>The property name of the sprites.</summary>
        public const string NAME_SPRITES = nameof(sprites);

        /// <summary>The warning of the null.</summary>
        private const string WARN_NULL = "Some inspector values is null.";

#pragma warning disable IDE0044
        /// <summary>List of the images of the UI.</summary>
        [SerializeField, Tooltip("Specifies the images of the UI.")]
        private Image[] images;

        /// <summary>List of the sprites.</summary>
        [SerializeField, Tooltip("Specifies the sprites.")]
        private Sprite[] sprites;
#pragma warning restore IDE0044

        /// <summary>Gets the class name of the subject.</summary>
        public override string ClassName => nameof(ImageToggle);

        /// <summary>The values of the UI.</summary>
        protected override object[] Values => sprites;

        /// <summary>Update the view of the UI.</summary>
        protected override void UpdateView()
        {
            if (images.Length < 2 || sprites.Length == 0)
            {
                Log.Warn(WARN_NULL);
                return;
            }
            var prev = sprites.At(PreviousIndex);
            var curr = sprites.At(Index);
            images[0].sprite = Direction > 0 ? prev : curr;
            images[1].sprite = Direction > 0 ? curr : prev;
        }
    }
}
