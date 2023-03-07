//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Movment/MainMovement.inputactions
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

public partial class @MainMovement : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainMovement"",
    ""maps"": [
        {
            ""name"": ""CameraMap"",
            ""id"": ""973ff509-7bef-4567-aeaf-8efabb484868"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6078f5a2-adb5-47e8-9f91-817acb9647d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""9a1245a6-01b8-499b-93fa-8e4b89e19bb4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateToggle"",
                    ""type"": ""Button"",
                    ""id"": ""4c7a2905-b3e5-48b2-8db8-9cbe4aae8437"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dedd8c96-f0ad-431f-acd7-347af14d2f77"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""74b93497-68d1-47d7-bc9b-cf438f0415f8"",
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
                    ""id"": ""4881e6b7-d15a-495f-8775-001bd01bed2a"",
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
                    ""id"": ""f3c00e87-ab6a-425a-9438-568d60d5b0a3"",
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
                    ""id"": ""b38d9a9a-25a0-4515-8613-b1f40abef21b"",
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
                    ""id"": ""9467fc25-1dd7-4975-aa23-0f503cdc4a08"",
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
                    ""id"": ""a1162b37-5f43-4ad9-8d4a-fef6bd7f9fae"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CameraMap
        m_CameraMap = asset.FindActionMap("CameraMap", throwIfNotFound: true);
        m_CameraMap_Move = m_CameraMap.FindAction("Move", throwIfNotFound: true);
        m_CameraMap_Rotate = m_CameraMap.FindAction("Rotate", throwIfNotFound: true);
        m_CameraMap_RotateToggle = m_CameraMap.FindAction("RotateToggle", throwIfNotFound: true);
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

    // CameraMap
    private readonly InputActionMap m_CameraMap;
    private ICameraMapActions m_CameraMapActionsCallbackInterface;
    private readonly InputAction m_CameraMap_Move;
    private readonly InputAction m_CameraMap_Rotate;
    private readonly InputAction m_CameraMap_RotateToggle;
    public struct CameraMapActions
    {
        private @MainMovement m_Wrapper;
        public CameraMapActions(@MainMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CameraMap_Move;
        public InputAction @Rotate => m_Wrapper.m_CameraMap_Rotate;
        public InputAction @RotateToggle => m_Wrapper.m_CameraMap_RotateToggle;
        public InputActionMap Get() { return m_Wrapper.m_CameraMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMapActions set) { return set.Get(); }
        public void SetCallbacks(ICameraMapActions instance)
        {
            if (m_Wrapper.m_CameraMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotate;
                @RotateToggle.started -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotateToggle;
                @RotateToggle.performed -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotateToggle;
                @RotateToggle.canceled -= m_Wrapper.m_CameraMapActionsCallbackInterface.OnRotateToggle;
            }
            m_Wrapper.m_CameraMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @RotateToggle.started += instance.OnRotateToggle;
                @RotateToggle.performed += instance.OnRotateToggle;
                @RotateToggle.canceled += instance.OnRotateToggle;
            }
        }
    }
    public CameraMapActions @CameraMap => new CameraMapActions(this);
    public interface ICameraMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnRotateToggle(InputAction.CallbackContext context);
    }
}
