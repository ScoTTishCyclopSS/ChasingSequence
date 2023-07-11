//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""54a574e4-ccc5-4a6b-9e7c-c2c0730934ba"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""0f072655-9ec0-42ce-a37d-ae8e4b261488"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootingPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""c411d85a-cfa9-4300-bb17-95686004a4aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShootingSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""1a851a34-daed-4e10-aa79-80fb4edb3818"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UsingAbilityA"",
                    ""type"": ""Button"",
                    ""id"": ""7dad6b40-0c28-4db9-adc1-e6126061963f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UsingAbilityB"",
                    ""type"": ""Button"",
                    ""id"": ""46b28890-7159-4ab0-9916-41eef25c8c37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7fbb553-f1fb-4468-b9f9-c5e900d652f2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""ShootingPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e6a47583-5845-4cc5-a09d-851e7ad2d1c2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3fca0281-11a3-472a-a2c2-f049b1cb69bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""73a1f478-0b1b-4834-a173-c90b7bcb396f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d6dce1ba-d2eb-41f8-9475-82d8d0dffba0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""ShootingSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b67675c6-84e1-4026-981b-ea75fd1a7ef9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""UsingAbilityA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e55bdaac-31e7-4b14-97ca-cb7205afb6da"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControlScheme"",
                    ""action"": ""UsingAbilityB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""a5925d37-affd-4515-aa48-92702813be37"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""744438dd-14ce-4148-9c1e-65c3ad2a99e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30ebde8e-f6d6-4bd6-a660-59977830d7ba"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ControlScheme"",
            ""bindingGroup"": ""ControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_ShootingPrimary = m_Gameplay.FindAction("ShootingPrimary", throwIfNotFound: true);
        m_Gameplay_ShootingSecondary = m_Gameplay.FindAction("ShootingSecondary", throwIfNotFound: true);
        m_Gameplay_UsingAbilityA = m_Gameplay.FindAction("UsingAbilityA", throwIfNotFound: true);
        m_Gameplay_UsingAbilityB = m_Gameplay.FindAction("UsingAbilityB", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_ShootingPrimary;
    private readonly InputAction m_Gameplay_ShootingSecondary;
    private readonly InputAction m_Gameplay_UsingAbilityA;
    private readonly InputAction m_Gameplay_UsingAbilityB;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @ShootingPrimary => m_Wrapper.m_Gameplay_ShootingPrimary;
        public InputAction @ShootingSecondary => m_Wrapper.m_Gameplay_ShootingSecondary;
        public InputAction @UsingAbilityA => m_Wrapper.m_Gameplay_UsingAbilityA;
        public InputAction @UsingAbilityB => m_Wrapper.m_Gameplay_UsingAbilityB;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @ShootingPrimary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingPrimary;
                @ShootingPrimary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingPrimary;
                @ShootingPrimary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingPrimary;
                @ShootingSecondary.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingSecondary;
                @ShootingSecondary.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingSecondary;
                @ShootingSecondary.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootingSecondary;
                @UsingAbilityA.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityA;
                @UsingAbilityA.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityA;
                @UsingAbilityA.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityA;
                @UsingAbilityB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityB;
                @UsingAbilityB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityB;
                @UsingAbilityB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsingAbilityB;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ShootingPrimary.started += instance.OnShootingPrimary;
                @ShootingPrimary.performed += instance.OnShootingPrimary;
                @ShootingPrimary.canceled += instance.OnShootingPrimary;
                @ShootingSecondary.started += instance.OnShootingSecondary;
                @ShootingSecondary.performed += instance.OnShootingSecondary;
                @ShootingSecondary.canceled += instance.OnShootingSecondary;
                @UsingAbilityA.started += instance.OnUsingAbilityA;
                @UsingAbilityA.performed += instance.OnUsingAbilityA;
                @UsingAbilityA.canceled += instance.OnUsingAbilityA;
                @UsingAbilityB.started += instance.OnUsingAbilityB;
                @UsingAbilityB.performed += instance.OnUsingAbilityB;
                @UsingAbilityB.canceled += instance.OnUsingAbilityB;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_ControlSchemeSchemeIndex = -1;
    public InputControlScheme ControlSchemeScheme
    {
        get
        {
            if (m_ControlSchemeSchemeIndex == -1) m_ControlSchemeSchemeIndex = asset.FindControlSchemeIndex("ControlScheme");
            return asset.controlSchemes[m_ControlSchemeSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShootingPrimary(InputAction.CallbackContext context);
        void OnShootingSecondary(InputAction.CallbackContext context);
        void OnUsingAbilityA(InputAction.CallbackContext context);
        void OnUsingAbilityB(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
