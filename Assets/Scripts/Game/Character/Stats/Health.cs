using System;
using Core;
using UniRx;
using UnityEngine;

public sealed class Health : IStat, IDisposable
{
    private readonly CompositeDisposable _disposables = new();

    public Health(int max, int current, float invulTime = 0.5f)
    {
        _invulTime = invulTime;
        
        Max = new ReactiveProperty<int>(Mathf.Max(1, max));
        Current = new ReactiveProperty<int>(Mathf.Clamp(current, 0, Max.Value));

        IsInvulnerable = new ReactiveProperty<bool>(false);

        IsDead = Current
            .Select(v => v <= 0)
            .DistinctUntilChanged()
            .ToReadOnlyReactiveProperty()
            .AddTo(_disposables);

        IsDead
            .Where(d => d)
            .Subscribe(_ => OnDead?.Invoke())
            .AddTo(_disposables);

        Max.Subscribe(m =>
        {
            if (Current.Value > m)
                Current.Value = m;
        }).AddTo(_disposables);
    }

    private readonly float _invulTime;

    public ReactiveProperty<int> Max { get; }
    public ReactiveProperty<int> Current { get; }

    public ReactiveProperty<bool> IsInvulnerable { get; }
    public IReadOnlyReactiveProperty<bool> IsDead { get; }

    public event Action OnDead;
    public event Action<int> OnDamage;

    public void ChangeCurrent(int delta)
    {
        // если получаем урон и сейчас неуязвимы — игнор
        if (delta < 0 && IsInvulnerable.Value)
            return;

        if (delta < 0)
        {
            OnDamage?.Invoke(-delta);
            StartInvulnerability();
        }

        SetCurrent(Current.Value + delta);
    }

    private void StartInvulnerability()
    {
        IsInvulnerable.Value = true;

        Observable.Timer(TimeSpan.FromSeconds(_invulTime))
            .Subscribe(_ => IsInvulnerable.Value = false)
            .AddTo(_disposables);
    }

    public void SetCurrent(int value)
        => Current.Value = Mathf.Clamp(value, 0, Max.Value);

    public void Dispose()
        => _disposables.Dispose();
}
