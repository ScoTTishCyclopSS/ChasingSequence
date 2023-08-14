using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class ShipPlayerBase : ShipBase
{
    // controls
    private Controls PlayerControls { get; set; }
    private InputAction MoveAction { get; set; }
    private InputAction ShootPrimaryAction { get; set; }
    private InputAction ShootSecondaryAction { get; set; }
    
    // todo: weapon switcher
    
    // Weapon manager
    private WeaponManager _equipmentManager;

    private bool shootingPrimary;
    private bool shootingSecondary;
    
    private void Awake()
    {
        PlayerControls = new Controls();
        _equipmentManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        if (shootingPrimary && _equipmentManager.GetCurrentWeapon(WeaponManager.SlotType.Primary).firingMode == Weapon.FiringMode.automatic)
        {
            _equipmentManager.UseWeapon(WeaponManager.SlotType.Primary, true);
        }
        if (shootingSecondary && _equipmentManager.GetCurrentWeapon(WeaponManager.SlotType.Secondary).firingMode == Weapon.FiringMode.automatic)
        {
            _equipmentManager.UseWeapon(WeaponManager.SlotType.Secondary, true);
        }
    }

    private void OnEnable()
    {
        PlayerControls.Gameplay.Enable();
        
        MoveAction = PlayerControls.Gameplay.Movement;
        ShootPrimaryAction = PlayerControls.Gameplay.ShootingPrimary;
        ShootSecondaryAction = PlayerControls.Gameplay.ShootingSecondary;
        
        MoveAction.performed += OnMove;
        MoveAction.canceled += OnMove;

        ShootPrimaryAction.performed += (ctx) => OnShootPrimary(true);
        ShootPrimaryAction.canceled += (ctx) => OnShootPrimary(false);

        ShootSecondaryAction.performed +=(ctx) => OnShootSecondary(true);
        ShootSecondaryAction.canceled += (ctx) => OnShootSecondary(false);
    }

    private void OnDisable()
    {
        PlayerControls.Gameplay.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        MoveDirection = new Vector2(ctx.ReadValue<float>(), 0f);
    }
    
    private void OnShootPrimary (bool held)
    {
        shootingPrimary = held;
        _equipmentManager.UseWeapon(WeaponManager.SlotType.Primary, held);
    }
    
    private void OnShootSecondary (bool held)
    {
        shootingSecondary = held;
        _equipmentManager.UseWeapon(WeaponManager.SlotType.Secondary, held);
    }
}