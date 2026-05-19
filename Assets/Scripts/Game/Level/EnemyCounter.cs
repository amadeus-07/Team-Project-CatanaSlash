using System.Linq;
using Core;
using UnityEngine;

public class EnemyCounter : IEnemyCounter
{
    public int Count { get; private set; }

    public EnemyCounter(SpawnSequence spawnSequence)
    {
        Count = spawnSequence.steps
            .SelectMany(s => s.spawnStepItems)
            .Sum(i => i.amount * CountSides(i.side));
    }

    private static int CountSides(SpawnSide side)
    {
        int count = 0;

        if (side.HasFlag(SpawnSide.North)) count++;
        if (side.HasFlag(SpawnSide.South)) count++;
        if (side.HasFlag(SpawnSide.East))  count++;
        if (side.HasFlag(SpawnSide.West))  count++;

        return count;
    }

    public void AddEntity(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Stats.Get<Health>().OnDead += OnDead;
    }

    private void OnDead()
    {
        Count--;
    }


}
