using System;
using UnityEngine;

namespace Pooling
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager instance { get; private set; }
        public Pooler<GeneralPool> objectPool;
        public Pooler<HitscanPool> hitscanPool;

        private void Awake()
        {
            if (instance == null)
            { 
                hitscanPool.Init(this);
                objectPool.Init(this);
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        internal GameObject Spawn(GameObject prefab)
        {
            return Instantiate(prefab, transform);
        }
    }
}