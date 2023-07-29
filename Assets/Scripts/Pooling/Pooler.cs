namespace Pooling
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class Pooler<T> where T : PoolType, new()
    {
        private PoolingManager _manager;
        public void Init(PoolingManager manager)
        {
            _manager = manager;
            CreateDictionary();
        }

        [System.Serializable]
        public class PoolObject
        {
            public string tag;
            public GameObject prefab;
            [Min(1)] public int size;
        }

        public List<PoolObject> pool;

        private Dictionary<string, Queue<T>> dict;
        
        public void CreateDictionary()
        {
            dict = new Dictionary<string, Queue<T>>();

            foreach (var poolDefinition in pool)
            {
                var objectPool = new Queue<T>();
                for (int i = 0; i < poolDefinition.size; i++)
                {
                    GameObject obj = _manager.Spawn(poolDefinition.prefab);
                    obj.SetActive(false);
                    var poolObject = new T();
                    poolObject.Init(obj);
                    objectPool.Enqueue(poolObject);
                }
                
                dict.Add(poolDefinition.tag, objectPool);
            }
        }

        public T Spawn(string tag, Vector3 position, Quaternion rotation)
        {
            if(string.IsNullOrEmpty(tag)) return null;

            if (!dict.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag \'" + tag + "\' doesn't exist");
                return null;
            }

            var objectToSpawn = dict[tag].Dequeue();

            objectToSpawn.Spawn(position, rotation);

            dict[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
