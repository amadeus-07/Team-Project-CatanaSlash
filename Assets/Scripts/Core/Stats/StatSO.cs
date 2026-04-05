using Core;
using UnityEngine;

namespace Core
{
    public abstract class StatSO : ScriptableObject
    {
        public abstract IStat Create();
    }

}