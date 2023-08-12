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

    private void Awake()
    {
        PlayerControls = new Controls();
        _equipmentManager = GetComponent<WeaponManager>();
    }

    private void OnEnable()
    {
        PlayerControls.Gameplay.Enable();
        
        MoveAction = PlayerControls.Gameplay.Movement;
        ShootPrimaryAction = PlayerControls.Gameplay.ShootingPrimary;
        ShootSecondaryAction = PlayerControls.Gameplay.ShootingSecondary;
        
        MoveAction.performed += OnMove;
        MoveAction.canceled += OnMove;

        ShootPrimaryAction.performed += OnShootPrimary;
        ShootPrimaryAction.canceled += OnShootPrimary;

        ShootSecondaryAction.performed += OnShootSecondary;
        ShootSecondaryAction.canceled += OnShootSecondary;
    }

    private void OnDisable()
    {
        PlayerControls.Gameplay.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        MoveDirection = new Vector2(ctx.ReadValue<float>(), 0f);
    }
    
    private void OnShootPrimary (InputAction.CallbackContext ctx)
    {
        _equipmentManager.UseWeapon(WeaponManager.SlotType.Primary, ctx.performed);
    }
    
    private void OnShootSecondary (InputAction.CallbackContext ctx)
    {
        _equipmentManager.UseWeapon(WeaponManager.SlotType.Secondary, ctx.performed);
    }
}