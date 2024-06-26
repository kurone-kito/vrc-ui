using UdonSharp;
using UnityEngine;
using black.kit.toybox;

namespace black.kit.vrcui
{
    /// <summary>The toggle switch of the text.</summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class SelectBase : Subject
    {
        /// <summary>The index of the sprite.</summary>
        [SerializeField, Tooltip("Specifies the index of the sprite.")]
        private int index;

        /// <summary>The index of the sprite.</summary>
        public virtual int Index
        {
            get => index;
            set
            {
                var next = Values.AtIndex(value);
                if (index == next)
                {
                    return;
                }
                PreviousIndex = index;
                index = next;
                Notify();
                UpdateView();
            }
        }

        /// <summary>The direction of the index.</summary>
        protected sbyte Direction { get; private set; } = 1;

        /// <summary>The previous index of the sprite.</summary>
        protected int PreviousIndex { get; private set; }

        /// <summary>The values of the UI.</summary>
        protected abstract object[] Values { get; }

        /// <summary>Gets the class name of the subject.</summary>
        public override string ClassName => nameof(SelectBase);

        /// <summary>Decrement the index of the texts.</summary>
        /// <returns>The decremented index.</returns>
        public int Decrement()
        {
            Direction = -1;
            return --Index;
        }

        /// <summary>Increment the index of the texts.</summary>
        /// <returns>The incremented index.</returns>
        public int Increment()
        {
            Direction = 1;
            return ++Index;
        }

        /// <summary>Update the view of the UI.</summary>
        protected abstract void UpdateView();

#pragma warning disable IDE0051
        /// <summary>The callback when the object is enabled.</summary>
        protected virtual void OnEnable() => UpdateView();
#pragma warning restore IDE0051
    }
}
