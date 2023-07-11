using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Shield : Gear
{
    public Rigidbody prefab;
    public float spreadingSpeed = 10f;
    [Range(0.01f, 1f)] public float coolDown = 0.01f;

    public bool shield;

    public override void Use(bool canUse, ShipBase ship)
    {
        if (canUse && Time.time > NextShot)
        {
            NextShot = Time.time + coolDown;
        }
    }
}
