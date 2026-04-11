using Core;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(StatsContext))]
public abstract class Character : MonoBehaviour, ITarget
{
    public Transform Transform => transform;

    public StatsContext Stats { get; private set; }

    protected void Awake()
    {
        Stats = GetComponent<StatsContext>();
    }

    protected void Start()
    {
        Stats.Get<Health>().OnDead += OnDead;
        Stats.Get<Health>().OnDamage += OnDamage;
    }

    protected abstract void OnDamage(int delta);

    protected abstract void OnDead();

    protected void OnDestroy()
    {
        if (Stats.Get<Health>() != null)
            Stats.Get<Health>().OnDead -= OnDead;

    }
}