using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface ISpawnPointProvider
    {
        IReadOnlyList<Transform> GetAll(SpawnSide side);
    }

}