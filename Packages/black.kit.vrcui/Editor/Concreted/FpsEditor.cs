using UnityEditor;

namespace black.kit.vrcui.Editor
{
    /// <summary>The inspector of the <see cref="Fps"/>.</summary>
    [CustomEditor(typeof(Fps))]
    public sealed class FpsEditor : EditorBase<Fps>
    {
        /// <summary>Initialize the editor.</summary>
        public FpsEditor() : base(L10n.Tr(T.DETAIL_FPS))
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
