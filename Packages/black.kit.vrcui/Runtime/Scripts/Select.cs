using TMPro;
using UdonSharp;
using UnityEngine;
using black.kit.toybox;

namespace black.kit.vrcui
{
    /// <summary>The toggle switch of the text.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [AddComponentMenu("black.kit.vrcui/Select")]
    public sealed class Select : SelectBase
    {
        /// <summary>The property name of the values.</summary>
        public const string NAME_VALUES = nameof(values);

        /// <summary>The property name of the placeholder.</summary>
        public const string NAME_TEXT = nameof(text);

#pragma warning disable IDE0044
        /// <summary>List of the values of the UI.</summary>
        [SerializeField, Tooltip("Specifies the values string")]
        private string[] values;

        /// <summary>placeholder of the UI.</summary>
        [SerializeField, Tooltip("Specifies the placeholder of the UI.")]
        private TextMeshProUGUI text;
#pragma warning restore IDE0044

        /// <summary>Gets the class name of the subject.</summary>
        public override string ClassName => nameof(Select);

        /// <summary>The values of the UI.</summary>
        protected override object[] Values => values;

        /// <summary>Update the view of the UI.</summary>
        protected override void UpdateView()
        {
            if (text)
            {
                text.text = values.At(Index);
            }
        }
    }
}
