using Core;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class OrangeBehaviour : Enemy
{
    [SerializeField] private float minDistanceFollow;
    [SerializeField] private float maxDistanceFollow;

    private NavMeshAgent agent;
    private StateMachine attackFsm;
    private StateMachine movementFsm;

    private float Distance =>
        Vector3.Distance(transform.position, Target.Transform.position);

    protected void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        attackFsm = new StateMachine(this);
        movementFsm = new StateMachine(this);
    }

    protected void Start()
    {
        base.Start();

      
    }

  

    protected override void OnDead()
    {
        base.OnDead();
        attackFsm.Dispose();
        movementFsm.Dispose();
    }
}
