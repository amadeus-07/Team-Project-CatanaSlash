using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SpawnPointProvider : MonoBehaviour, ISpawnPointProvider
    {
        public Transform north, south, east, west;

        public IReadOnlyList<Transform> GetAll(SpawnSide side)
        {
            var result = new List<Transform>();

            if (side.HasFlag(SpawnSide.North)) result.Add(north);
            if (side.HasFlag(SpawnSide.South)) result.Add(south);
            if (side.HasFlag(SpawnSide.East))  result.Add(east);
            if (side.HasFlag(SpawnSide.West))  result.Add(west);

            return result;
        }
    }
}
