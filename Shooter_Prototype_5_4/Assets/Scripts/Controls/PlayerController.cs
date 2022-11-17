// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""3aecc059-f3ef-4a1a-8b11-6c39e8d3c415"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a747bbb9-3fac-45fd-94c1-7e6f066d444e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""92e2a67d-c97f-4f1a-9179-2256bb0500f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f39e8dd3-a96a-4208-bc2b-bef92a8dc053"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewX"",
                    ""type"": ""Value"",
                    ""id"": ""bdf6876c-fd17-417a-98aa-082513c8c4d3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewY"",
                    ""type"": ""Value"",
                    ""id"": ""a5f64410-e12f-482e-b57a-bbd3bb810331"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e1a3acec-ed2e-4c19-8a82-361b3616730d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""86571e6d-bed6-4c2e-84dd-438e5ca174c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""789e10a7-ec72-479e-a757-b65d21a023e4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4b4e7fb-136d-4047-9d6c-eb1390f982b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dea3a6e6-b366-40fb-bf2b-ef52bd927767"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""356468ad-e123-47fa-9eee-c170d0ff03c5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eae4b79e-7006-4c4f-a507-1e4b15bfdd33"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3248acb-7e18-41bc-8edd-705b364b3cf9"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f86656d9-88fd-4514-a09c-0a8501c478c7"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Move = m_PlayerMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerMap_Shoot = m_PlayerMap.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMap_Jump = m_PlayerMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMap_ViewX = m_PlayerMap.FindAction("ViewX", throwIfNotFound: true);
        m_PlayerMap_ViewY = m_PlayerMap.FindAction("ViewY", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Move;
    private readonly InputAction m_PlayerMap_Shoot;
    private readonly InputAction m_PlayerMap_Jump;
    private readonly InputAction m_PlayerMap_ViewX;
    private readonly InputAction m_PlayerMap_ViewY;
    public struct PlayerMapActions
    {
        private @PlayerController m_Wrapper;
        public PlayerMapActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMap_Move;
        public InputAction @Shoot => m_Wrapper.m_PlayerMap_Shoot;
        public InputAction @Jump => m_Wrapper.m_PlayerMap_Jump;
        public InputAction @ViewX => m_Wrapper.m_PlayerMap_ViewX;
        public InputAction @ViewY => m_Wrapper.m_PlayerMap_ViewY;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShoot;
                @Jump.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnJump;
                @ViewX.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewX;
                @ViewX.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewX;
                @ViewX.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewX;
                @ViewY.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewY;
                @ViewY.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewY;
                @ViewY.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnViewY;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ViewX.started += instance.OnViewX;
                @ViewX.performed += instance.OnViewX;
                @ViewX.canceled += instance.OnViewX;
                @ViewY.started += instance.OnViewY;
                @ViewY.performed += instance.OnViewY;
                @ViewY.canceled += instance.OnViewY;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnViewX(InputAction.CallbackContext context);
        void OnViewY(InputAction.CallbackContext context);
    }
}
