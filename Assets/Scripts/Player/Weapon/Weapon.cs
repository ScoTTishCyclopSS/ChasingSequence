using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public enum FiringMode
    {
        semiAuto,
        automatic
    }
    
    public WeaponManager.SlotType slotType;
    public string rayType = "testRay";
    public float fireSpeed;
    public float fireRate;
    public float screenshakePower;
    public float screenStop;
    protected float NextShot;

    public FiringMode firingMode;
    
    public UnityEvent onFire;
    public abstract void Fire(bool canShoot);

    // Method to be called by the derived classes when they want to fire the weapon.
    protected void InvokeFireEvent()
    {
        onFire?.Invoke();
    }
}
