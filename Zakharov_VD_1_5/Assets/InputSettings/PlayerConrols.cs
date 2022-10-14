//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/InputSettings/PlayerConrols.inputactions
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

public partial class @PlayerConrols : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerConrols()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerConrols"",
    ""maps"": [
        {
            ""name"": ""PlayerKeyboardMap"",
            ""id"": ""73082fff-f299-4a6b-adef-219f8bdaa812"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8c404e35-8910-436f-badd-002f156ef793"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Event"",
                    ""type"": ""Button"",
                    ""id"": ""16de87a6-754f-46c6-a8a7-c8eb18167493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""3302369d-c5e4-4d13-b7c6-05570ffd752f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""d7fce8fd-12d2-4cb4-90d5-e59a3cf03a70"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""wasd"",
                    ""id"": ""c02dc983-2133-482b-8954-98f0416ce8bc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5d699f48-4274-420b-8f4f-5bba62a51752"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""678d251c-fcba-4bba-8cae-ce50e4d1c633"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fbcb310a-4082-4a3d-8906-194747382be0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""798ef058-a7a4-4dcc-ba12-1b1fe91386f1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""701a1296-de43-4653-92a7-f146ef4335e1"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""158c4ed4-5cbe-48c8-ab34-e89b10b58359"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c8fc6e86-6943-4c29-98f0-d49d541071a0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""88360986-45fc-4924-bf93-de7669fd0f99"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5517c28-fc8b-4ce6-8b71-fe81343673ab"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a1e88512-b8c8-4b80-bd09-747a2a934f12"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Event"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bd827e7-7246-47d6-a587-8660153f8918"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Event"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad9302a5-0841-433e-bd8c-68781503f768"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8324ed13-68a1-4c96-812b-f84db5b0d791"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3eb553e8-69d3-437f-90af-24088d86f3b4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c753489-063c-4677-b458-db04948ba150"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerKeyboardMap
        m_PlayerKeyboardMap = asset.FindActionMap("PlayerKeyboardMap", throwIfNotFound: true);
        m_PlayerKeyboardMap_Movement = m_PlayerKeyboardMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerKeyboardMap_Event = m_PlayerKeyboardMap.FindAction("Event", throwIfNotFound: true);
        m_PlayerKeyboardMap_Shoot = m_PlayerKeyboardMap.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerKeyboardMap_Rotation = m_PlayerKeyboardMap.FindAction("Rotation", throwIfNotFound: true);
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

    // PlayerKeyboardMap
    private readonly InputActionMap m_PlayerKeyboardMap;
    private IPlayerKeyboardMapActions m_PlayerKeyboardMapActionsCallbackInterface;
    private readonly InputAction m_PlayerKeyboardMap_Movement;
    private readonly InputAction m_PlayerKeyboardMap_Event;
    private readonly InputAction m_PlayerKeyboardMap_Shoot;
    private readonly InputAction m_PlayerKeyboardMap_Rotation;
    public struct PlayerKeyboardMapActions
    {
        private @PlayerConrols m_Wrapper;
        public PlayerKeyboardMapActions(@PlayerConrols wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerKeyboardMap_Movement;
        public InputAction @Event => m_Wrapper.m_PlayerKeyboardMap_Event;
        public InputAction @Shoot => m_Wrapper.m_PlayerKeyboardMap_Shoot;
        public InputAction @Rotation => m_Wrapper.m_PlayerKeyboardMap_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_PlayerKeyboardMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerKeyboardMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerKeyboardMapActions instance)
        {
            if (m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnMovement;
                @Event.started -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnEvent;
                @Event.performed -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnEvent;
                @Event.canceled -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnEvent;
                @Shoot.started -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnShoot;
                @Rotation.started -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_PlayerKeyboardMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Event.started += instance.OnEvent;
                @Event.performed += instance.OnEvent;
                @Event.canceled += instance.OnEvent;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public PlayerKeyboardMapActions @PlayerKeyboardMap => new PlayerKeyboardMapActions(this);
    public interface IPlayerKeyboardMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnEvent(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}