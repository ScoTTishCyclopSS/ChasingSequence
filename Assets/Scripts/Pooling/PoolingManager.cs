using System;
using UnityEngine;

namespace Pooling
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager instance { get; private set; }
        public Pooler<GeneralPool> objectPool;
        public Pooler<HitscanPool> hitscanPool;
        public Pooler<VfxPool> vfxPool;
        public Pooler<SfxPool> sfxPool;

        private void Awake()
        {
            if (instance == null)
            { 
                hitscanPool.Init(this);
                objectPool.Init(this);
                vfxPool.Init(this);
                sfxPool.Init(this);
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