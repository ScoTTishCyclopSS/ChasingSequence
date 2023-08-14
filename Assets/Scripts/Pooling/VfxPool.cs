using UnityEngine.VFX;

namespace Pooling
{
    using UnityEngine;

    public class VfxPool : PoolType
    {
        public GameObject gameObject { get; private set; }
        public VisualEffect vfx { get; private set; }

        public override void Init(GameObject go)
        {
            this.gameObject = go;
            vfx = go.GetComponent<VisualEffect>();
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.SetActive(true);
            vfx.Play();
        }
    }
}