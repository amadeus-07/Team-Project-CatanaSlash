using UnityEngine;

namespace Core
{
    public interface IEnemyCounter
    {
        int Count {get;}
        void AddEntity(GameObject entity);
    }
}
