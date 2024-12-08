using UnityEditor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="Progress"/>.</summary>
    [CustomEditor(typeof(Progress))]
    public sealed class ProgressEditor : EditorBase<Progress>
    {
        /// <summary>Initialize the editor.</summary>
        public ProgressEditor() : base(L10n.Tr(T.DETAIL_PROGRESS))
        {
        }

        /// <summary>The callback to draw the inspector GUI.</summary>
        public override void OnInspectorGUI()
        {
            DrawBanner();
            DrawDetails();
            base.OnInspectorGUI();
        }
    }
}
