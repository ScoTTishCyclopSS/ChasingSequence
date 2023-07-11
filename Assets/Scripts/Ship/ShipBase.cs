using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GearFactory))]
public class ShipBase : MonoBehaviour
{
    private Rigidbody Rb { get; set; }

    #region Movement

    protected Vector2 MoveDirection { get; set; }
    [Header("Movement Settings")] public float drag = 8f;
    public float tiltAngle = 30f;
    public float jerkForce = 2f;
    [Range(0, 1)] public float rotationSpeed = 0.07f;

    #endregion

    #region Weapons

    private GearFactory gearFactory;
    
    private Gear _primary;
    private Gear _secondary;
    private Gear _abilityA;
    private Gear _abilityB;
    
    protected bool IsPrimaryShooting { get; set; }
    protected bool IsSecondaryShooting { get; set; }
    protected bool IsUsingAbilityA { get; set; }
    protected bool IsUsingAbilityB { get; set; }

    #endregion

    private void Start()
    {
        gearFactory = GetComponent<GearFactory>();
        gearFactory.OnGearChanged += HandleGearChanged;
        Rb = GetComponent<Rigidbody>();
        Rb.drag = drag;
    }
    
    private void HandleGearChanged(GearSlot slot)
    {
        /*switch (slot)
        {
            case GearSlot.Primary:
                _primary = gearFactory.GetGear(GearSlot.Primary);
                break;
            case GearSlot.Secondary:
                _secondary = gearFactory.GetGear(GearSlot.Secondary);
                break;
            case GearSlot.AttackAbility:
                break;
            case GearSlot.DefenceAbility:
                break;
        }*/
    }


    protected void UseGear(GearSlot slot, bool b)
    {
        gearFactory.GetGear(slot).Use(b, this);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (MoveDirection != Vector2.zero)
        {
            Rb.AddForce(MoveDirection * jerkForce, ForceMode.Impulse);
        }
        RotationAfterMove();
    }

    protected virtual void RotationAfterMove()
    {
        var newRotation = Quaternion.Euler(MoveDirection.y, 0f, -(tiltAngle * MoveDirection.x));
        Rb.rotation = Quaternion.Slerp(Rb.rotation, newRotation, rotationSpeed);
    }

    public void InstantiateProjectile(Rigidbody prefab, float speed)
    {
        var projectile = Instantiate(prefab, Rb.position, Quaternion.identity);
        projectile.AddForce(projectile.transform.forward * speed, ForceMode.Force);
    }

}