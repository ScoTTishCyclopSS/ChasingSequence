using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_RapidFireBlaster : Gear
{
    public Rigidbody laserPrefab;

    private enum BlasterMode
    {
        Single,
        Double,
        Triple
    }

    public override void Use(bool canShoot, ShipBase ship)
    {
        if (canShoot && Time.time > NextShot)
        {
            NextShot = Time.time + fireRate;
            ship.InstantiateProjectile(laserPrefab, fireSpeed);
        }
    }
}
