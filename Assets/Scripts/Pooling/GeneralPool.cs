using UnityEngine;

namespace Pooling
{
    public class GeneralPool : PoolType
    {
        public GameObject gameObject { get; private set; }

        public override void Init(GameObject go)
        {
            this.gameObject = go;
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.SetActive(true);
        }
    }
}