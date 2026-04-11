using Core;
using UniRx;
using UnityEngine;


public class BananaBehaviour : Enemy
{
    [SerializeField] private float minDistanceToAttack;
    [SerializeField] private float maxDistanceToAttack;
    private StateMachine _fsm;

    private float Distance {get => Vector3.Distance(transform.position, Target.Transform.position); }

    private void Awake()
    {
        base.Awake();
        _fsm = new StateMachine(this);
    }

    private void Start()
    {
      base.Start();
    }


    private bool CanAttack()
    {
        if ( Distance > maxDistanceToAttack) return false;
        var isDead = Target.Stats.Get<Health>().IsDead.Value;
        return !isDead;
    }


    protected override void OnDead()
    {
        base.OnDead();
        _fsm.Dispose();
    }
}