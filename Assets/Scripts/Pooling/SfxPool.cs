namespace Pooling
{
    using UnityEngine;
    
    public class SfxPool : PoolType
    {
        public GameObject gameObject { get; private set; }
        public AudioSource sfx { get; private set; }

        public override void Init(GameObject go)
        {
            this.gameObject = go;
            sfx = go.GetComponent<AudioSource>();
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.SetActive(true);
            sfx.pitch = 1 + Random.Range(-0.05f, 0.05f);
            sfx.Play();
        }
    }
}