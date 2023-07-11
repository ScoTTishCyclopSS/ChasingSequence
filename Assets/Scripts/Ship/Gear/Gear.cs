using System;
using UnityEngine;

public abstract class Gear : MonoBehaviour
{
    public string Name { get; set; }

    public float fireSpeed = 20f;
    
    [Range(0.01f, 1f)] public float fireRate = 0.01f;
    
    protected float NextShot;
    
    public abstract void Use(bool canShoot, ShipBase ship);
}

public class Pup : Gear
{
    public int sus = 1;
    public override void Use(bool canShoot, ShipBase ship)
    {
        throw new NotImplementedException();
    }
}