using UdonSharp;
using UnityEngine;

namespace black.kit.vrcui
{
    /// <summary>The base class of the interval logic.</summary>
    public abstract class IntervalBase : UdonSharpBehaviour
    {
        /// <summary>The warning of the null.</summary>
        private const string WARN_NULL = "Some inspector values is null.";

        /// <summary>The interval of the progress.</summary>
        [SerializeField, Range(1f / 60f, 0.3f)]
        [Tooltip("Specifies the interval of the progress")]
        private float interval = 0.1f;

        /// <summary>The interval of the progress.</summary>
        public float Interval => interval;

        /// <summary>Update the view of the UI.</summary>
        public void InternalUpdateView()
        {
            UpdateView();
            SendCustomEventDelayedSeconds(nameof(InternalUpdateView), interval);
        }

        /// <summary>Update the view of the UI.</summary>]
        [ContextMenu("Update view")]
        public abstract void UpdateView();

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        protected abstract bool ValidateInspector();

        /// <summary>The callback when the object is initialized.</summary>
        protected virtual void Start()
        {
            if (!ValidateInspector())
            {
                Debug.LogWarning(WARN_NULL);
                return;
            }
            SendCustomEventDelayedFrames(nameof(InternalUpdateView), 1);
        }
    }
}
