using UdonSharp;
using UnityEngine;
using black.kit.vrcui;

namespace black.kit.vrcui.Example
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ProgressController : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>The progress component.</summary>
        [SerializeField, Tooltip("Specifies the progress component.")]
        private Progress progress;
#pragma warning restore IDE0044

        public void Decrement() => progress.Value -= Random.Range(0f, 30f);

        public void Increment() => progress.Value += Random.Range(0f, 30f);
    }
}
