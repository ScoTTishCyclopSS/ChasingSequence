using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public WeaponManager.SlotType slotType;
    public float fireSpeed;
    public float fireRate;
    protected float NextShot;
    
    public UnityEvent onFire;
    public abstract void Fire(bool canShoot);

    // Method to be called by the derived classes when they want to fire the weapon.
    protected void InvokeFireEvent()
    {
        onFire?.Invoke();
    }
}
