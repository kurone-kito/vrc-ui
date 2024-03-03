using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.vrcui
{
    /// <summary>
    /// This component animates the specified toggle with the specified
    /// animator.
    /// </summary>
    [AddComponentMenu("VRC-UI/Toggle With Animation")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class ToggleWithAnimation : UdonSharpBehaviour
    {
        /// <summary>The property name of the animator.</summary>
        public const string NAME_ANIMATOR = nameof(animator);

        /// <summary>The property name of the parameter.</summary>
        public const string NAME_PARAMETER = nameof(parameter);

        /// <summary>The property name of the toggle.</summary>
        public const string NAME_TOGGLE = nameof(toggle);

#pragma warning disable IDE0044
        /// <summary>The animator of the toggle.</summary>
        [SerializeField, Tooltip("Specifies the animator.")]
        private Animator animator;

        /// <summary>The parameter name of the animator.</summary>
        [SerializeField, Tooltip("Specifies the parameter name.")]
        private string parameter;

        /// <summary>The toggle to be animated.</summary>
        [SerializeField, Tooltip("Specifies the toggle.")]
        private Toggle toggle;
#pragma warning restore IDE0044

        /// <summary>The parameter ID of the animator.</summary>
        private int parameterId;

        /// <summary>
        /// Callback for when the value of the toggle changes.
        /// </summary>
        public void OnValueChanged()
        {
            if (animator == null || string.IsNullOrEmpty(parameter))
            {
                return;
            }
            animator.SetBool(parameterId, toggle.isOn);
        }

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        private void OnEnable()
        {
            if (animator == null || string.IsNullOrEmpty(parameter))
            {
                return;
            }
            parameterId = Animator.StringToHash(parameter);
            animator.SetBool(parameterId, toggle.isOn);
        }
#pragma warning restore IDE0051
    }
}
