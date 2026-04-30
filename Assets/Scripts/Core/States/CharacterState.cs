namespace Core
{

    public abstract class CharacterState : State
    {
        private AnimationState _animation;
        public CharacterState(AnimationState animation)
        {
            _animation = animation;
        }

        internal override void Enter()
        {
            base.Enter();
            _animation.Play();
        }
    }
}