using UnityEngine;
using Weapons;

namespace Pooling
{
    public class HitscanPool : PoolType
    {
        public GameObject gameObject { get; private set; }
        public Hitscan hitscan { get; private set; }

        public override void Init(GameObject go)
        {
            this.gameObject = go;
            hitscan = go.GetComponent<Hitscan>();
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
        }
    }
}