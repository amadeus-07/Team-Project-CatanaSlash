using System;
using Core;
using UniRx;

public sealed class AttackDamage : ReactiveProperty<int>, IStat
{
    public AttackDamage(int value)
    {
        Value = Math.Max(0, value);
    }
}