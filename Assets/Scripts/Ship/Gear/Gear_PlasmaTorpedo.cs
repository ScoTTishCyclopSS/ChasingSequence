using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_PlasmaTorpedo : Gear
{
    public Rigidbody prefab;

    public bool torpedo;

    private enum TorpedoMode
    {
        Single,
        Double,
        HorizontalDischarge
    }

    public override void Use(bool canShoot, ShipBase ship)
    {
        if (canShoot && Time.time > NextShot)
        {
            NextShot = Time.time + fireRate;
            ship.InstantiateProjectile(prefab, fireSpeed);
        }
    }
}
