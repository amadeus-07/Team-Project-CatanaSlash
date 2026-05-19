using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Flags]
    public enum SpawnSide
    {
        North = 1 << 0,
        South = 1 << 1,
        East = 1 << 2,
        West = 1 << 3
    }

    [System.Serializable]
    [CreateAssetMenu(menuName = "Level/SpawnSequence")]
    public class SpawnSequence : ScriptableObject
    {
        public List<SpawnStep> steps;
    }

    [System.Serializable]
    public class SpawnStep
    {
        public List<SpawnStepItem> spawnStepItems;
        public float delay;
    }

    [System.Serializable]
    public class SpawnStepItem
    {
        public GameObject enemy;
        public SpawnSide side;
        public int amount = 1;
    }

}