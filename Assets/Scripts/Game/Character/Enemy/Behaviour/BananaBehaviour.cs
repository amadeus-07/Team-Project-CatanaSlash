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
        var idle = new IdleState();
        var follow = new FollowState( Target.Transform, new TransformMovement(transform, new ReactiveProperty<float>(3.5f)));
        var combat = new CombatState(Target.Stats.Get<Health>(), Stats.Get<AttackDamage>(), Stats.Get<AttackSpeed>().Duration);
        _fsm.AddTransition(follow, idle, () => Distance <= minDistanceToAttack);
        _fsm.AddTransition(idle, follow, () => Distance >= maxDistanceToAttack);
        _fsm.AddTransition(idle, combat, CanAttack);
        _fsm.AddTransition(combat, idle, () => !CanAttack());
        _fsm.Start(idle);
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