//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/InputSetting/PlayersConrol.inputactions
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

public partial class @PlayersConrol : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayersConrol()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayersConrol"",
    ""maps"": [
        {
            ""name"": ""Players"",
            ""id"": ""50f23e52-82ec-41f9-85f4-315445dbdeb6"",
            ""actions"": [
                {
                    ""name"": ""FirstPlayerMove"",
                    ""type"": ""Value"",
                    ""id"": ""5be8debe-19d4-4423-bfe3-7009446bf539"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondPlayerMove"",
                    ""type"": ""Value"",
                    ""id"": ""488572a9-9f2e-4228-b244-7bde0335b19a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""160fd16c-fc19-4d5f-a97e-c3278c621afc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""063cae22-d1d8-4ccc-8db2-5b6f10bf1e99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Wasd"",
                    ""id"": ""606f658b-b597-423c-abc6-df494c527f14"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstPlayerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7089f15e-37f7-48dd-abac-ad139e9f1e1c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""41b73e84-1dfb-4210-8352-1339148e4e21"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5fa9cb21-9d4a-4683-82b9-207ba697cc97"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66f82cc3-e12a-4b57-a2af-60e052661902"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""99d7b5dc-6a08-44e0-893f-cb968eac0fab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondPlayerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3d7c9291-1fce-4281-8613-0877502ee27f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2705ff3c-8ab7-44cb-9860-f21aca6d7579"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cefb6896-6b13-4871-aab2-3ee9ad444d31"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f6148259-2c5e-4f78-8485-04823c8aec25"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondPlayerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aabfa78f-4189-4ef5-8e2c-d75f943ba17d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bd8eb3a-87fd-408b-ad60-180083d185fa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Players
        m_Players = asset.FindActionMap("Players", throwIfNotFound: true);
        m_Players_FirstPlayerMove = m_Players.FindAction("FirstPlayerMove", throwIfNotFound: true);
        m_Players_SecondPlayerMove = m_Players.FindAction("SecondPlayerMove", throwIfNotFound: true);
        m_Players_Shoot = m_Players.FindAction("Shoot", throwIfNotFound: true);
        m_Players_Pause = m_Players.FindAction("Pause", throwIfNotFound: true);
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

    // Players
    private readonly InputActionMap m_Players;
    private IPlayersActions m_PlayersActionsCallbackInterface;
    private readonly InputAction m_Players_FirstPlayerMove;
    private readonly InputAction m_Players_SecondPlayerMove;
    private readonly InputAction m_Players_Shoot;
    private readonly InputAction m_Players_Pause;
    public struct PlayersActions
    {
        private @PlayersConrol m_Wrapper;
        public PlayersActions(@PlayersConrol wrapper) { m_Wrapper = wrapper; }
        public InputAction @FirstPlayerMove => m_Wrapper.m_Players_FirstPlayerMove;
        public InputAction @SecondPlayerMove => m_Wrapper.m_Players_SecondPlayerMove;
        public InputAction @Shoot => m_Wrapper.m_Players_Shoot;
        public InputAction @Pause => m_Wrapper.m_Players_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Players; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayersActions set) { return set.Get(); }
        public void SetCallbacks(IPlayersActions instance)
        {
            if (m_Wrapper.m_PlayersActionsCallbackInterface != null)
            {
                @FirstPlayerMove.started -= m_Wrapper.m_PlayersActionsCallbackInterface.OnFirstPlayerMove;
                @FirstPlayerMove.performed -= m_Wrapper.m_PlayersActionsCallbackInterface.OnFirstPlayerMove;
                @FirstPlayerMove.canceled -= m_Wrapper.m_PlayersActionsCallbackInterface.OnFirstPlayerMove;
                @SecondPlayerMove.started -= m_Wrapper.m_PlayersActionsCallbackInterface.OnSecondPlayerMove;
                @SecondPlayerMove.performed -= m_Wrapper.m_PlayersActionsCallbackInterface.OnSecondPlayerMove;
                @SecondPlayerMove.canceled -= m_Wrapper.m_PlayersActionsCallbackInterface.OnSecondPlayerMove;
                @Shoot.started -= m_Wrapper.m_PlayersActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayersActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayersActionsCallbackInterface.OnShoot;
                @Pause.started -= m_Wrapper.m_PlayersActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayersActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayersActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FirstPlayerMove.started += instance.OnFirstPlayerMove;
                @FirstPlayerMove.performed += instance.OnFirstPlayerMove;
                @FirstPlayerMove.canceled += instance.OnFirstPlayerMove;
                @SecondPlayerMove.started += instance.OnSecondPlayerMove;
                @SecondPlayerMove.performed += instance.OnSecondPlayerMove;
                @SecondPlayerMove.canceled += instance.OnSecondPlayerMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayersActions @Players => new PlayersActions(this);
    public interface IPlayersActions
    {
        void OnFirstPlayerMove(InputAction.CallbackContext context);
        void OnSecondPlayerMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
