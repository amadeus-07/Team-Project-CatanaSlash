using Core;
using UniRx;
using UnityEngine;

public sealed class ShootState : CharacterState
{
    private readonly Cooldown _cooldown;
    private readonly ReactiveProperty<int> _damage;
    private readonly ReactiveProperty<float> _speed;
    private readonly Transform _firePoint;

    public ShootState(
        AnimationState animation,
        Transform firePoint,
        ReactiveProperty<float> attackSpeed,
        ReactiveProperty<int> damage,
        ReactiveProperty<float> projectileSpeed) : base(animation)
    {
        _firePoint = firePoint;
        _damage = damage;
        _speed = projectileSpeed;

        _cooldown = new Cooldown(attackSpeed, Attack);
    }

    protected override void OnInitialize()
    {
        _cooldown.AddTo(GlobalDisposables);
    }



    protected override void OnUpdate()
    {
        _cooldown.Activate();
    }

    private void Attack()
    {
        if (_firePoint == null || !_firePoint.gameObject.activeInHierarchy)
            return;

    }
}
