// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputsController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputsController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputsController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputsController"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""e1abd47d-28c1-46ef-a2a2-7808c6a94e4b"",
            ""actions"": [
                {
                    ""name"": ""Track1"",
                    ""type"": ""Button"",
                    ""id"": ""caf72f65-ab29-41ec-9475-5ba9bf4e73fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Track2"",
                    ""type"": ""Button"",
                    ""id"": ""749476cc-9198-438b-b5a6-96218b093239"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Track3"",
                    ""type"": ""Button"",
                    ""id"": ""967861c0-7802-44ea-b2a8-b57db1b1fc91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Track4"",
                    ""type"": ""Button"",
                    ""id"": ""e0723d2a-9fea-4a7d-8ccc-eb9d63e26e37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Track5"",
                    ""type"": ""Button"",
                    ""id"": ""2c372b38-7f94-4933-9ebe-f6dd24759184"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1335d09-3458-4835-afc4-0f29541d2f62"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Track1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f4f393f-d8c1-4523-bca3-fdb3d23ddb49"",
                    ""path"": ""<Keyboard>/#(Z)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Track2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a259364c-e97a-430a-858d-b2b07fd6f7e1"",
                    ""path"": ""<Keyboard>/#(E)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Track3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3834f597-89d0-4d57-9641-23b471081fe3"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Track4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb881004-d2bd-47b0-953c-46933bf9854f"",
                    ""path"": ""<Keyboard>/#(T)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Track5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Track1 = m_Default.FindAction("Track1", throwIfNotFound: true);
        m_Default_Track2 = m_Default.FindAction("Track2", throwIfNotFound: true);
        m_Default_Track3 = m_Default.FindAction("Track3", throwIfNotFound: true);
        m_Default_Track4 = m_Default.FindAction("Track4", throwIfNotFound: true);
        m_Default_Track5 = m_Default.FindAction("Track5", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Track1;
    private readonly InputAction m_Default_Track2;
    private readonly InputAction m_Default_Track3;
    private readonly InputAction m_Default_Track4;
    private readonly InputAction m_Default_Track5;
    public struct DefaultActions
    {
        private @PlayerInputsController m_Wrapper;
        public DefaultActions(@PlayerInputsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Track1 => m_Wrapper.m_Default_Track1;
        public InputAction @Track2 => m_Wrapper.m_Default_Track2;
        public InputAction @Track3 => m_Wrapper.m_Default_Track3;
        public InputAction @Track4 => m_Wrapper.m_Default_Track4;
        public InputAction @Track5 => m_Wrapper.m_Default_Track5;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Track1.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack1;
                @Track1.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack1;
                @Track1.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack1;
                @Track2.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack2;
                @Track2.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack2;
                @Track2.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack2;
                @Track3.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack3;
                @Track3.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack3;
                @Track3.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack3;
                @Track4.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack4;
                @Track4.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack4;
                @Track4.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack4;
                @Track5.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack5;
                @Track5.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack5;
                @Track5.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTrack5;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Track1.started += instance.OnTrack1;
                @Track1.performed += instance.OnTrack1;
                @Track1.canceled += instance.OnTrack1;
                @Track2.started += instance.OnTrack2;
                @Track2.performed += instance.OnTrack2;
                @Track2.canceled += instance.OnTrack2;
                @Track3.started += instance.OnTrack3;
                @Track3.performed += instance.OnTrack3;
                @Track3.canceled += instance.OnTrack3;
                @Track4.started += instance.OnTrack4;
                @Track4.performed += instance.OnTrack4;
                @Track4.canceled += instance.OnTrack4;
                @Track5.started += instance.OnTrack5;
                @Track5.performed += instance.OnTrack5;
                @Track5.canceled += instance.OnTrack5;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnTrack1(InputAction.CallbackContext context);
        void OnTrack2(InputAction.CallbackContext context);
        void OnTrack3(InputAction.CallbackContext context);
        void OnTrack4(InputAction.CallbackContext context);
        void OnTrack5(InputAction.CallbackContext context);
    }
}
