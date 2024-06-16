using UdonSharp;
using UnityEngine;
using black.kit.toybox;

namespace black.kit.vrcui.Examples
{
    /// <summary>The logic of the status catalog.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class StatusCatalog : IntervalBase
    {
#pragma warning disable IDE0044
        /// <summary>The placeholder of the detail.</summary>
        [SerializeField, Tooltip("Specifies the progress U# component.")]
        private Progress progress;
#pragma warning restore IDE0044
        /// <summary>Delta of the progress per interval.</summary>
        [SerializeField, Range(0.1f, 5f)]
        [Tooltip("Specifies the delta of the progress")]
        private float delta = 1f;

        /// <summary>Update the view of the UI.</summary>
        public override void UpdateView()
        {
            var gap = Random.Range(0f, 0.5f);
            progress.Value = (progress.Value + delta + gap) % progress.Limit;
        }

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        protected override bool ValidateInspector() => !!progress;
    }
}
