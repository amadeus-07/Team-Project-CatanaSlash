using Core;
using UnityEngine;
using UnityEngine.AI;

public class StrawberryBehaviour : Enemy, IBehaviour
{
    [SerializeField] private float minDistanceFollow;
    [SerializeField] private float maxDistanceFollow;
    private NavMeshAgent _agent;
    private StateMachine _fsm;

    private float Distance { get => Vector3.Distance(transform.position, Target.Transform.position); }

    private void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = minDistanceFollow;
        _fsm = new StateMachine(this);
    }

    private void Start()
    {
        base.Start();
       
    }


    private bool CanAttack()
    {
        if (Distance > maxDistanceFollow) return false;
        var isDead = Target.Stats.Get<Health>().IsDead.Value;
        return !isDead;
    }

    protected override void OnDead()
    {
        base.OnDead();
        _fsm.Dispose();
    }

}