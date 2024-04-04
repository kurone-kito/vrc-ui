using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace black.kit.vrcui
{
    /// <summary>The toggle switch of the hero section.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public sealed class Hero : UdonSharpBehaviour
    {
        /// <summary>The property name of the toggle group.</summary>
        public const string NAME_TOGGLE_GROUP = nameof(toggleGroup);

        /// <summary>The property name of the toggles.</summary>
        public const string NAME_TOGGLES = nameof(toggles);

#pragma warning disable IDE0044
        /// <summary>The toggle group of the UI.</summary>
        [SerializeField, Tooltip("Specifies the toggle group of the UI.")]
        private ToggleGroup toggleGroup;

        /// <summary>List of the toggles of the UI.</summary>
        [SerializeField, Tooltip("Specifies the toggles of the UI.")]
        private Toggle[] toggles;
#pragma warning restore IDE0044

        /// <summary>The index of the selected toggle.</summary>
        public int Index { get; private set; }

        /// <summary>Decrements the index of the selected toggle.</summary>
        public void Decrement()
        {
            Index = (Index + toggles.Length - 1) % toggles.Length;
            UpdateView();
        }

        /// <summary>Increments the index of the selected toggle.</summary>
        public void Increment()
        {
            Index = (Index + 1) % toggles.Length;
            UpdateView();
        }

        /// <summary>Update the view of the UI.</summary>
        private void UpdateView() => toggles[Index].isOn = true;
    }
}
