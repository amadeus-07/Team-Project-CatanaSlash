using UnityEngine;

namespace Core
{
    public sealed class AnimationStateFactory
    {
        private readonly Animator _animator;

        public AnimationStateFactory(Animator animator)
        {
            _animator = animator;
        }

        public AnimationState Create(string name, int layer = 0)
        {
            return new AnimationState(_animator, Animator.StringToHash(name), layer);
        }
    }

}