using System;
using Pooling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Weapon_Test : Weapon
{
    public float curvature;
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    public override void Fire(bool canShoot)
    {
        // Can't shoot yet
        if (canShoot && Time.time <= NextShot)
            return;
        
        // Increase shoot timer
        NextShot = Time.time + fireRate;

        // Send ray from screen pos
        Vector2Control mousePos = Mouse.current.position;
        
        // To world space
        Vector3 wsPoint = _mainCam.ScreenToWorldPoint(new Vector3(mousePos.x.value, mousePos.y.value, 100f));
        Vector3 dir = AdjustHit(wsPoint);

        // Spawn laser
        var obj = PoolingManager.instance.hitscanPool.Spawn(rayType, transform.position, Quaternion.LookRotation(dir));
        obj.hitscan.OnFire(dir, 0, 5000f);
        Screenshake.instance.Fire(screenshakePower, screenStop);
        InvokeFireEvent();
    }
    
    private Vector3 AdjustHit(Vector3 pt)
    {
        Debug.Log(pt);
        Vector3 mainCamPos = _mainCam.transform.position;
        
        // Hom. vector based on world pos
        Vector3 vv = new Vector3(pt.x, pt.y, pt.z);
        
        // Subtract camera position from it
        vv.x -= mainCamPos.x;
        vv.y -= mainCamPos.y;
        vv.z -= mainCamPos.z;

        // Increase y by curvature factor
        vv = new Vector3(0.0f, (vv.z * vv.z) * curvature, 0.0f);

        var finalVec = pt + vv;
        Debug.Log(finalVec);

        // Send raycast again by finding screen pos of world position hit
        var screenPos = _mainCam.WorldToScreenPoint(finalVec);
        var ray =  _mainCam.ScreenPointToRay(screenPos);
        Vector3 dir = (ray.origin + ray.direction * 100f - transform.position).normalized;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            dir = (hit.point - transform.position).normalized;
            Debug.Log("Hit!");
        }
        return dir;
    }
}