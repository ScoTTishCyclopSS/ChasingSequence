using System.Collections;
using System.Collections.Generic;
using Pooling;
using Unity.Mathematics;
using UnityEngine;

public class PoolBinder : MonoBehaviour
{
    public void PlayVFX(string name)
    {
        PoolingManager.instance.vfxPool.Spawn(name, transform.position, Quaternion.identity);
    }
    
    public void PlaySFX(string name)
    {
        PoolingManager.instance.sfxPool.Spawn(name, transform.position, Quaternion.identity);
    }
}
