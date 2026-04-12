using Core;
using UnityEngine;

public class FollowState : State
{
    private readonly Transform? _target;
    private readonly IMovementTo _movement;

    public FollowState( Transform? target, IMovementTo movement)
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