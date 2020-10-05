// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movements"",
            ""id"": ""7f166158-def9-4581-ac87-63b44daea575"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""b9925e03-3c08-4030-9578-dcb1cef78017"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d6877d8a-4800-4726-bd77-abc0424a5087"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce5c3d3c-ed55-4ba8-8fac-8c83399fae54"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c61b6467-a27c-4c24-afef-c6f8b9254c76"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d603ee6-5d69-4885-b97e-f347ff7ea67a"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""592952fb-1485-40fd-a90e-107f54cf14fa"",
                    ""path"": ""*/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
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
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movements
        m_Movements = asset.FindActionMap("Movements", throwIfNotFound: true);
        m_Movements_Rotate = m_Movements.FindAction("Rotate", throwIfNotFound: true);
        m_Movements_Attack = m_Movements.FindAction("Attack", throwIfNotFound: true);
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

    // Movements
    private readonly InputActionMap m_Movements;
    private IMovementsActions m_MovementsActionsCallbackInterface;
    private readonly InputAction m_Movements_Rotate;
    private readonly InputAction m_Movements_Attack;
    public struct MovementsActions
    {
        private @PlayerInput m_Wrapper;
        public MovementsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Movements_Rotate;
        public InputAction @Attack => m_Wrapper.m_Movements_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Movements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementsActions set) { return set.Get(); }
        public void SetCallbacks(IMovementsActions instance)
        {
            if (m_Wrapper.m_MovementsActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnRotate;
                @Attack.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_MovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public MovementsActions @Movements => new MovementsActions(this);
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    public interface IMovementsActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
