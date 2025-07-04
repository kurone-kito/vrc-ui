using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Network;
using black.kit.toybox;

namespace black.kit.vrcui
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [AddComponentMenu("black.kit.vrcui/Fps")]
    public sealed class Fps : IntervalBase
    {
        /// <summary>The property name of the FPS.</summary>
        public const string NAME_FPS = nameof(fps);

        /// <summary>The property name of the ping.</summary>
        public const string NAME_PING = nameof(ping);

#pragma warning disable IDE0044
        /// <summary>The text's placeholder to show FPS.</summary>
        [SerializeField, Tooltip("Specifies the text's placeholder to show FP.")]
        private TextMeshProUGUI fps;

        /// <summary>The text's placeholder to show ping.</summary>
        [SerializeField, Tooltip("Specifies the text's placeholder to show ping.")]
        private TextMeshProUGUI ping;

        /// <summary>Whether to use the ping.</summary>
        [SerializeField, Tooltip("Specifies whether to use the ping.")]
        private bool usePing = true;
#pragma warning restore IDE0044

        /// <summary>The frames to calculate the FPS.</summary>
        private int frames;

        /// <summary>Update the view of the UI.</summary>
        public override void UpdateView()
        {
            var pingMs = Mathf.RoundToInt(Stats.RoundTripTime);
            fps.text = $"FPS: {Mathf.RoundToInt(frames / Interval)}";
            ping.text = usePing ? $"Ping: {pingMs}" : string.Empty;
            frames = 0;
        }

        /// <summary>Validate the inspector.</summary>
        /// <returns>Whether the inspectors are valid.</returns>
        /// <remarks>
        /// <c>ping</c> is optional when <c>usePing</c> is disabled.
        /// </remarks>
        protected override bool ValidateInspector() =>
            fps && (!usePing || ping);

#pragma warning disable IDE0051
        /// <summary>Update the frames.</summary>
        private void Update() => frames++;
#pragma warning restore IDE0051
    }
}
