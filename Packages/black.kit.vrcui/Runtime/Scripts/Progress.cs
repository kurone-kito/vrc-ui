using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using black.kit.toybox;

namespace black.kit.vrcui
{
    /// <summary>The progress widget</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class Progress : UdonSharpBehaviour
    {
        /// <summary>The warning of the null.</summary>
        private const string WARN_NULL = "Some inspector values is null.";

#pragma warning disable IDE0044
        /// <summary>The placeholder of the detail.</summary>
        [SerializeField, Tooltip("Specifies the placeholder of the detail.")]
        private TextMeshProUGUI detail;

        /// <summary>The placeholder of percentage.</summary>
        [SerializeField, Tooltip("Specifies the placeholder of percentage.")]
        private TextMeshProUGUI percentage;

        /// <summary>The slider of the UI.</summary>
        [SerializeField, Tooltip("Specifies the slider of the UI.")]
        private Slider slider;
#pragma warning restore IDE0044

        /// <summary>The format of the percentage.</summary>
        [SerializeField, Tooltip("Specifies the format of the percentage.")]
        private string formatPercentage = "P2";

        /// <summary>The format of the detail.</summary>
        [SerializeField, Tooltip("Specifies the format of the detail.")]
        private string formatDetail = "F2";

        /// <summary>The limit of the slider.</summary>
        [Min(1), SerializeField]
        [Tooltip("Specifies the limit of the slider.")]
        private float limit = 255f;

        /// <summary>The unit of the detail.</summary>
        [SerializeField, Tooltip("Specifies the unit of the detail.")]
        private string unit = "MB";

        /// <summary>The value of the slider.</summary>
        [Min(0), SerializeField]
        [Tooltip("Specifies the value of the slider.")]
        private float value;

        /// <summary>The format of the percentage.</summary>
        public string FormatPercentage
        {
            get => formatPercentage;
            set {
                formatPercentage = value;
                UpdateView();
            }
        }

        /// <summary>The format of the detail.</summary>
        public string FormatDetail
        {
            get => formatDetail;
            set {
                formatDetail = value;
                UpdateView();
            }
        }

        /// <summary>The limit of the slider.</summary>
        /// <remarks>
        /// If the value is 0, it will be set to 1.
        /// </remarks>
        public float Limit
        {
            get => limit;
            set {
                limit = value <= 0 || Mathf.Approximately(value, 0f)
                    ? 1f
                    : value;
                UpdateView();
            }
        }

        /// <summary>The unit of the detail.</summary>
        public string Unit
        {
            get => unit;
            set {
                unit = value;
                UpdateView();
            }
        }

        /// <summary>The value of the slider.</summary>
        public float Value
        {
            get => value;
            set {
                this.value = Mathf.Clamp(value, 0f, Limit);
                UpdateView();
            }
        }

        /// <summary>The percentage of the slider.</summary>
        public float Percentage =>
            Mathf.Clamp01(
                value / (Mathf.Approximately(limit, 0f) ? 1f : limit));

        /// <summary>Update the view of the UI.</summary>
        [ContextMenu("Update view")]
        public void UpdateView()
        {
            if (!slider || !percentage || !detail)
            {
                Log.Warn(WARN_NULL);
                return;
            }
            slider.maxValue = limit;
            slider.value = value;
            percentage.text = Percentage.ToString(formatPercentage);
            var strValue = value.ToString(formatDetail);
            var strLimit = limit.ToString(formatDetail);
            detail.text = $"{strValue} {unit}/{strLimit} {unit}";
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable() => UpdateView();

        /// <summary>
        /// The callback when changing the inspector values.
        /// </summary>
        private void OnValidate() => UpdateView();
#pragma warning restore IDE0051
    }
}
