using TMPro;
using UdonSharp;
using UnityEngine;

namespace black.kit.vrcui.Examples
{
    /// <summary>The logic of the badge container catalog.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class BadgeContainerCatalog : UdonSharpBehaviour
    {
#pragma warning disable IDE0044
        /// <summary>The badge container.</summary>
        [SerializeField, Tooltip("Specifies the credits.")]
        private TextMeshProUGUI credits;
#pragma warning restore IDE0044

        /// <summary>The unit of the badge container.</summary>
        [SerializeField, Range(1, 1000)]
        [Tooltip("Specifies the unit of the badge container")]
        private int unit = 100;

        /// <summary>The value of the badge container.</summary>
        [SerializeField, Min(0)]
        [Tooltip("Specifies the value of the badge container")]
        private int value = 0;

        /// <summary>Decrease the value of the badge container.</summary>
        public void Decrease()
        {
            value = Mathf.Max(value - unit, 0);
            UpdateView();
        }

        /// <summary>Increase the value of the badge container.</summary>
        public void Increase()
        {
            value = Mathf.Min(value + unit, 65500);
            UpdateView();
        }

        /// <summary>Update the view of the UI.</summary>
        [ContextMenu("Update view")]
        private void UpdateView()
        {
            credits.text = $"{value}";
        }
    }
}
