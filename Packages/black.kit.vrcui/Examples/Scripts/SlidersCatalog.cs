using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox;

namespace black.kit.vrcui.Examples
{
    /// <summary>The logic of the sliders catalog.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class SlidersCatalog : IntervalBase
    {
#pragma warning disable IDE0044
        /// <summary>The peak level slider.</summary>
        [SerializeField, Tooltip("Specifies the peak level slider.")]
        private Slider[] peakLevel;

        /// <summary>The RMS level slider.</summary>
        [SerializeField, Tooltip("Specifies the RMS level slider.")]
        private Slider[] rmsLevel;
#pragma warning restore IDE0044

        /// <summary>The limit of the peak.</summary>
        [SerializeField, Range(0.01f, 1f)]
        [Tooltip("Specifies the limit of the peak")]
        private float peak = 0.5f;

        /// <summary>Update the view of the UI.</summary>
        public override void UpdateView()
        {
            var peakValue = Random.Range(0f, peak);
            foreach (var slider in peakLevel)
            {
                slider.value = peakValue;
            }
            var rmsReduce = Mathf.Max(0f, Random.Range(0f, 0.33f) - 0.1f);
            var rmsValue = Mathf.Max(0f, peakValue - rmsReduce);
            foreach (var slider in rmsLevel)
            {
                slider.value = rmsValue;
            }
        }

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        protected override bool ValidateInspector() =>
            peakLevel.Length > 0 && rmsLevel.Length > 0;
    }
}
