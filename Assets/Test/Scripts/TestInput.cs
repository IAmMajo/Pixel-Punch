//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Test/Scripts/TestInput.inputactions
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

public partial class @TestInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TestInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TestInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c4f24bd9-c4cb-40a1-b0be-5609ef68bcd2"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e218f9aa-2aa3-4245-aa07-a267ffdf5cd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""86572fb5-3908-4cd4-987e-f2e74236dfb9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveLeftKey"",
                    ""type"": ""Button"",
                    ""id"": ""ebe87645-b015-4722-9018-1fef6053f579"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRightKey"",
                    ""type"": ""Button"",
                    ""id"": ""284e1a64-dbe0-40aa-a282-b46627d2835f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JumpKey"",
                    ""type"": ""Button"",
                    ""id"": ""bdeade6f-29de-4503-8e3b-b541bae9e859"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ac460356-e45f-4aa1-8a33-07ef721e08ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackKey"",
                    ""type"": ""Button"",
                    ""id"": ""c71b5d58-9aaa-46ef-966f-17b2b43e2282"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b874c2a6-6346-425d-aabb-55b0bc23803e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dce9d93-340d-4929-8a89-3a5ad169e518"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""518fa127-e464-4af6-8660-b5a1e8d330b8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeftKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""139c335f-e830-4b49-972b-3d7fb6d8e2a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRightKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c5f14ca-c34b-488c-9c55-19832c78ba30"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd398b08-8d69-4fc1-bf50-971de9a43f2f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b35e3987-6198-4c7c-b915-e83a466b80ed"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_MoveLeftKey = m_Gameplay.FindAction("MoveLeftKey", throwIfNotFound: true);
        m_Gameplay_MoveRightKey = m_Gameplay.FindAction("MoveRightKey", throwIfNotFound: true);
        m_Gameplay_JumpKey = m_Gameplay.FindAction("JumpKey", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_AttackKey = m_Gameplay.FindAction("AttackKey", throwIfNotFound: true);
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
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_MoveLeftKey;
    private readonly InputAction m_Gameplay_MoveRightKey;
    private readonly InputAction m_Gameplay_JumpKey;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_AttackKey;
    public struct GameplayActions
    {
        private @TestInput m_Wrapper;
        public GameplayActions(@TestInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @MoveLeftKey => m_Wrapper.m_Gameplay_MoveLeftKey;
        public InputAction @MoveRightKey => m_Wrapper.m_Gameplay_MoveRightKey;
        public InputAction @JumpKey => m_Wrapper.m_Gameplay_JumpKey;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @AttackKey => m_Wrapper.m_Gameplay_AttackKey;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @MoveLeftKey.started += instance.OnMoveLeftKey;
            @MoveLeftKey.performed += instance.OnMoveLeftKey;
            @MoveLeftKey.canceled += instance.OnMoveLeftKey;
            @MoveRightKey.started += instance.OnMoveRightKey;
            @MoveRightKey.performed += instance.OnMoveRightKey;
            @MoveRightKey.canceled += instance.OnMoveRightKey;
            @JumpKey.started += instance.OnJumpKey;
            @JumpKey.performed += instance.OnJumpKey;
            @JumpKey.canceled += instance.OnJumpKey;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @AttackKey.started += instance.OnAttackKey;
            @AttackKey.performed += instance.OnAttackKey;
            @AttackKey.canceled += instance.OnAttackKey;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @MoveLeftKey.started -= instance.OnMoveLeftKey;
            @MoveLeftKey.performed -= instance.OnMoveLeftKey;
            @MoveLeftKey.canceled -= instance.OnMoveLeftKey;
            @MoveRightKey.started -= instance.OnMoveRightKey;
            @MoveRightKey.performed -= instance.OnMoveRightKey;
            @MoveRightKey.canceled -= instance.OnMoveRightKey;
            @JumpKey.started -= instance.OnJumpKey;
            @JumpKey.performed -= instance.OnJumpKey;
            @JumpKey.canceled -= instance.OnJumpKey;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @AttackKey.started -= instance.OnAttackKey;
            @AttackKey.performed -= instance.OnAttackKey;
            @AttackKey.canceled -= instance.OnAttackKey;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnMoveLeftKey(InputAction.CallbackContext context);
        void OnMoveRightKey(InputAction.CallbackContext context);
        void OnJumpKey(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnAttackKey(InputAction.CallbackContext context);
    }
}
