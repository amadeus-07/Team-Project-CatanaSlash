using System;
using Core;
using UniRx;

public sealed class AttackSpeed : ReactiveProperty<float>, IStat
{
    public readonly ReactiveProperty<float> Duration;

    public AttackSpeed(float value)
    {
        Value = Math.Max(0, value);
        Duration = new ReactiveProperty<float>(1f / value);
        this.Subscribe(s => Duration.Value = 1f / s);
    }
}