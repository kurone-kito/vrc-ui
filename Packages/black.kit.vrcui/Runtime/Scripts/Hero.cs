using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox;

namespace black.kit.vrcui
{
    /// <summary>
    /// This component is the toggle switch helper for the hero section.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [AddComponentMenu("black.kit.vrcui/Hero")]
    public sealed class Hero : SelectBase
    {
        /// <summary>The property name of the image.</summary>
        public const string NAME_IMAGE = nameof(image);

        /// <summary>The property name of the sprites.</summary>
        public const string NAME_SPRITES = nameof(sprites);

        /// <summary>The warning message of the page mark.</summary>
        private const string WARN_NO_PAGE_MARK =
            "The page mark component is not set.";

        /// <summary>The warning message of the page marks pane.</summary>
        private const string WARN_NO_PAGE_MARKS_PANE =
            "The page marks pane is not set.";

        /// <summary>The warning message when inspectors are not set.</summary>
        private const string WARN_NULL = "Some inspector values is null.";

#pragma warning disable IDE0044
        /// <summary>The image's placeholder.</summary>
        [SerializeField, Tooltip("Specifies the image's placeholder.")]
        private Image image;

        /// <summary>The page mark.</summary>
        [SerializeField, Tooltip("Specifies the page mark.")]
        private Toggle pageMark;

        /// <summary>The page marks pane.</summary>
        [SerializeField, Tooltip("Specifies the page marks pane.")]
        private ToggleGroup pageMarksPane;

        /// <summary>List of the sprites.</summary>
        [SerializeField, Tooltip("Specifies the sprites.")]
        private Sprite[] sprites;
#pragma warning restore IDE0044

        /// <summary>Gets the class name of the subject.</summary>
        public override string ClassName => nameof(Hero);

        /// <summary>The values of the UI.</summary>
        protected override object[] Values => sprites;

        /// <summary>The page marks of the UI.</summary>
        private Toggle[] pageMarks;

        /// <summary>Update the view of the UI.</summary>
        protected override void UpdateView()
        {
            if (!image || sprites.Length == 0)
            {
                return;
            }
            image.sprite = sprites.At(Index);
            if (pageMarks != null)
            {
                pageMarks.At(Index).isOn = true;
            }
        }

#pragma warning disable IDE0051
        /// <summary>
        /// The callback when the application is quitting.
        /// </summary>
        void OnApplicationQuit()
        {
            if (pageMarks == null)
            {
                return;
            }
            for (var i = pageMarks.Length; --i >= 0;)
            {
                Destroy(pageMarks[i].gameObject);
                pageMarks[i] = null;
            }
            pageMarks = null;
        }

        /// <summary>The callback when the object is initialized.</summary>
        private void Start()
        {
            if (!image || sprites.Length == 0)
            {
                Log.Warn(WARN_NULL, Constants.APP_NAME);
                return;
            }
            if (!pageMark)
            {
                Log.Warn(WARN_NO_PAGE_MARK, Constants.APP_NAME);
                return;
            }
            if (!pageMarksPane)
            {
                Log.Warn(WARN_NO_PAGE_MARKS_PANE, Constants.APP_NAME);
                return;
            }
            pageMarks = new Toggle[sprites.Length];
            var length = pageMarks.Length;
            for (var i = 0; i < length; ++i) // due to sibling order
            {
                var obj = Instantiate(
                    pageMark.gameObject, pageMarksPane.transform);
                obj.SetActive(true);
                pageMarks[i] = obj.GetComponent<Toggle>();
                pageMarks[i].group = pageMarksPane;
            }
            UpdateView();
        }
#pragma warning restore IDE0051
    }
}
