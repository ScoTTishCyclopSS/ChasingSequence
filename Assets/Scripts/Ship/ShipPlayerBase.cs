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
    private InputAction AbilityActionA{ get; set; }
    private InputAction AbilityActionB { get; set; }

    private void Awake()
    {
        PlayerControls = new Controls();
    }

    private void OnEnable()
    {
        PlayerControls.Gameplay.Enable();
        
        // load actions
        MoveAction = PlayerControls.Gameplay.Movement;
        ShootPrimaryAction = PlayerControls.Gameplay.ShootingPrimary;
        ShootSecondaryAction = PlayerControls.Gameplay.ShootingSecondary;
        AbilityActionA = PlayerControls.Gameplay.UsingAbilityA;
        AbilityActionB = PlayerControls.Gameplay.UsingAbilityB;

        // subscribe
        MoveAction.performed += OnMove;
        MoveAction.canceled += OnMove;

        ShootPrimaryAction.performed += OnShootPrimary; // on press
        ShootPrimaryAction.canceled += OnShootPrimary; // on release

        ShootSecondaryAction.performed += OnShootSecondary;
        ShootSecondaryAction.canceled += OnShootSecondary;
        
        AbilityActionA.performed += OnUseAbilityA;
        AbilityActionA.canceled += OnUseAbilityA;
        
        AbilityActionB.performed += OnUseAbilityB;
        AbilityActionB.canceled += OnUseAbilityB;
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
        //IsPrimaryShooting = ctx.performed;
        UseGear(GearSlot.Primary, ctx.performed);
    }
    
    private void OnShootSecondary (InputAction.CallbackContext ctx)
    {
        //IsSecondaryShooting = ctx.performed;
        UseGear(GearSlot.Secondary, ctx.performed);
    }
    
    private void OnUseAbilityA (InputAction.CallbackContext ctx)
    {
        IsUsingAbilityA = ctx.performed;
    }
    
    private void OnUseAbilityB (InputAction.CallbackContext ctx)
    {
        IsUsingAbilityB = ctx.performed; 
    }
}