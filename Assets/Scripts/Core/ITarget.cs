using Core;
using UnityEngine;

namespace Core
{
    public interface ITarget
    {
        Transform Transform { get; }
        StatsContext Stats { get; }
    }

}