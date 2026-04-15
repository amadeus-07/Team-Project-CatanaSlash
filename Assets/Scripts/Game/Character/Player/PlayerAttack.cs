using System;
using Core;
using UniRx;
using UnityEngine;
using VContainer;

public class PlayerAttack : MonoBehaviour
{
    [Inject] private PlayerInput input;
    [SerializeField] StatsContext stats;
    [SerializeField] private float distance;
    Cooldown cooldown;



    void Start()
    {
        cooldown = new Cooldown(
            stats.Get<AttackSpeed>().Duration,
            Attack,
            true
        ).AddTo(this);

        input.Attack.Subscribe(_ => cooldown.Activate())
            .AddTo(this);
    }

    void Attack()
    {
        float hitDelay = 0.15f; // под тайминг анимации

        Observable.Timer(TimeSpan.FromSeconds(hitDelay))
            .Subscribe(_ => DoDamage())
            .AddTo(this);
    }

    void DoDamage()
    {
        
        var damage = stats.Get<AttackDamage>().Value;

        foreach (var col in Physics.OverlapSphere(transform.position, distance))
        {
            if (col.TryGetComponent(out StatsContext target)
                && target != stats)
            {
                target.Get<Health>().ChangeCurrent(-damage);
            }
        }
    }

}
