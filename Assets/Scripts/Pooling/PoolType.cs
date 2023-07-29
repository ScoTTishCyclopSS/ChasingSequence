using UnityEngine;

namespace Pooling
{
    public abstract class PoolType
    {
        public abstract void Init(GameObject go);
        public abstract void Spawn(Vector3 position, Quaternion rotation);
    }
}