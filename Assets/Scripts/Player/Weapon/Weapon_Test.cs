using Pooling;
using UnityEngine;

public class Weapon_Test : Weapon
{
    public override void Fire(bool canShoot)
    {
        if (canShoot && Time.time > NextShot)
        {
            NextShot = Time.time + fireRate;
            var obj = PoolingManager.instance.hitscanPool.Spawn("testRay", transform.position,
                Quaternion.LookRotation(transform.forward));
            obj.hitscan.OnFire(transform.forward, 0);
            InvokeFireEvent();
        }
    }
}