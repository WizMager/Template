using System;
using UnityEngine;

namespace Animancer.Components
{
    [Serializable]
    public class MotionClipTransition : ClipTransition
    {
        [SerializeField] private bool applyRootMotion;

        /// <inheritdoc />
        public override void Apply(AnimancerState state)
        {
            base.Apply(state);
            state.Root.Component.Animator.applyRootMotion = applyRootMotion;
        }
    }
}