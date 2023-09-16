using Pooling;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_Test : Weapon
{
    public override void Fire(bool canShoot)
    {
        if (canShoot && Time.time > NextShot)
        {
            NextShot = Time.time + fireRate;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.value,
                Mouse.current.position.y.value, 0));
            Vector3 dir;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                dir = (hit.point - transform.position).normalized;
            }
            else
            {
                dir = transform.forward;
            }
            var obj = PoolingManager.instance.hitscanPool.Spawn(rayType, transform.position,
                Quaternion.LookRotation(dir));
            obj.hitscan.OnFire(dir, 0);
            Screenshake.instance.Fire(screenshakePower, screenStop);
            InvokeFireEvent();
        }
    }
}