using Pooling;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_Test : Weapon
{
    public float m_Curvature = 0.002f;

    public override void Fire(bool canShoot)
    {
        if (canShoot && Time.time > NextShot)
        {
            NextShot = Time.time + fireRate;
            var ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.value,
                Mouse.current.position.y.value, 0));
            Vector3 dir;
            if (Physics.Raycast(ray, out var hit))
            {
                hit = adjustHit(hit);
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

    private RaycastHit adjustHit(RaycastHit hit)
    {
        var pt = hit.point;
        var dist = hit.distance;

        var vv = new Vector4(pt.x, pt.y, pt.z, 1.0f);

        vv.x -= Camera.main.transform.position.x;
        vv.y -= Camera.main.transform.position.y;
        vv.z -= Camera.main.transform.position.z;

        // Increase y by curvature factor (originally -m_Curvature)
        vv = new Vector4((vv.z * vv.z + vv.x * vv.x) * m_Curvature, 0.0f, (vv.z * vv.z + vv.x * vv.x) * m_Curvature, 0.0f);

        var finalVec = new Vector3(pt.x, pt.y + vv.y, pt.z);

        // Send raycast again by finding screen pos of world position hit
        RaycastHit hit2;
        var screenPos = Camera.main.WorldToScreenPoint(finalVec);
        var ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out hit2, 100f)) return hit2;

        return hit;
    }
}