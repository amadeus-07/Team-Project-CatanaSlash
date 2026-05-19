using Core;
using UnityEngine;

public class FollowState : CharacterState
{
    private readonly Transform? _target;
    private readonly IMovementTo _movement;

    public FollowState(AnimationState animation, Transform? target, IMovementTo movement) : base(animation)
    {
        _target = target;
        _movement = movement;
    }

    protected override void OnExit()
    {
        _movement.Stop();
    }

    protected override void OnFixedUpdate()
    {
        if (_target == null)
            return;
        _movement.MoveTo(_target.transform.position);    
    }

}