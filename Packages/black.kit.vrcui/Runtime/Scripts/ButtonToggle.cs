using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.vrcui
{
    /// <summary>The toggle switch look like a button.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ButtonToggle : UdonSharpBehaviour
    {
        /// <summary>The property name of the animators.</summary>
        public const string NAME_ANIMATORS = nameof(animators);

        /// <summary>The property name of the toggles.</summary>
        public const string NAME_TOGGLES = nameof(toggles);

        /// <summary>
        /// The trigger name when the toggle is neutral.
        /// </summary>
        private const string TRIGGER_NEUTRAL = "Neutral";

        /// <summary>
        /// The trigger name when the toggle is selected.
        /// </summary>
        private const string TRIGGER_SELECTED = "Selected";

        /// <summary>
        /// The trigger name when the toggle is unselected.
        /// </summary>
        private const string TRIGGER_UNSELECTED = "UnSelected";

#pragma warning disable IDE0044
        /// <summary>The animator.</summary>
        [SerializeField, Tooltip("Specifies the animator.")]
        private Animator animator;

        /// <summary>List of the animators.</summary>
        [SerializeField, Tooltip("Specifies the animators.")]
        private Animator[] animators;

        /// <summary>List of the toggles.</summary>
        [SerializeField, Tooltip("Specifies the toggles.")]
        private Toggle[] toggles;
#pragma warning restore IDE0044

        /// <summary>The animator.</summary>
        public Animator Animator => animator;

        /// <summary>The callback when the value is changed.</summary>
        public void OnValueChanged()
        {
            var toggle = GetComponent<Toggle>();
            if (!toggle)
            {
                return;
            }
            if (toggle.isOn)
            {
                SetTrigger(TRIGGER_SELECTED, TRIGGER_UNSELECTED);
                SetTriggerToToggles(TRIGGER_SELECTED, TRIGGER_UNSELECTED);
            }
            else if (!IsAnyOn())
            {
                SetTrigger(TRIGGER_NEUTRAL);
                SetTriggerToToggles(TRIGGER_NEUTRAL);
            }
        }

        /// <summary>Determines whether any toggle is on.</summary>
        /// <returns>
        /// <c>true</c> if any toggle is on; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAnyOn()
        {
            foreach (var t in toggles)
            {
                if (t.isOn)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sets the trigger to the animators.
        /// </summary>
        /// <param name="self">The trigger name for the self.</param>
        /// <param name="others">The trigger name for the others.</param>
        private void SetTrigger(string self, string others = null)
        {
            var me = Animator;
            foreach (var a in animators)
            {
                a.SetTrigger(a == me ? self : others ?? self);
            }
        }

        /// <summary>
        /// Sets the trigger to the animators.
        /// </summary>
        /// <param name="self">The trigger name for the self.</param>
        /// <param name="others">The trigger name for the others.</param>
        private void SetTriggerToToggles(string self, string others = null)
        {
            var me = GetComponent<Toggle>();
            foreach (var t in toggles)
            {
                var bt = t.GetComponent<ButtonToggle>();
                if (!bt)
                {
                    continue;
                }
                var animator = bt.Animator;
                if (animator)
                {
                    animator.SetTrigger(t == me ? self : others ?? self);
                }
            }
        }
    }
}
