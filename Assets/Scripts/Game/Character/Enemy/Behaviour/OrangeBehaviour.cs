using Core;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class OrangeBehaviour : Enemy
{
    [SerializeField] private float minDistanceFollow;
    [SerializeField] private float maxDistanceFollow;
    [SerializeField] private Transform projectileSpawnPoint;

    [Inject] private IProjectileFactory projectileFactory;

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

        var movement = new NavMeshMovement(agent);

        var keepDistance = new KeepDistanceState(
            AnimationStateFactory.Create("Walk"),
            transform,
            Target?.Transform,
            movement,
            minDistanceFollow
        );

        var shoot = new ShootState(
            AnimationStateFactory.Create("Attack"),
            projectileSpawnPoint,
            Stats.Get<AttackSpeed>().Duration,
            Stats.Get<AttackDamage>(),
            new ReactiveProperty<float>(20)
        );

        var idle = new IdleState(AnimationStateFactory.Create("Idle"));

        movementFsm.Start(keepDistance);

        attackFsm.AddTransition(idle, shoot, IsPlayerVisible);
        attackFsm.AddTransition(shoot, idle, () => !IsPlayerVisible());
        attackFsm.Start(idle);
    }

    private void FixedUpdate()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        var direction = Target.Transform.position - transform.position;
        var rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rotation,
            Time.deltaTime * 2f
        );
    }

    private bool IsPlayerVisible()
    {
        var origin = transform.position;
        var direction = Target.Transform.position - origin;
        direction.y = 0f;
        direction.Normalize();

        if (Physics.Raycast(origin, direction, out var hit, 100f))
        {
            Debug.DrawLine(origin, hit.point, Color.green);
            return hit.collider.transform == Target.Transform;
        }

        Debug.DrawRay(origin, direction * 100f, Color.red);
        return false;
    }

    protected override void OnDead()
    {
        base.OnDead();
        attackFsm.Dispose();
        movementFsm.Dispose();
    }
}
