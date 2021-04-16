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
                    ""type"": ""PassThrough"",
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
    public struct DefaultActions
    {
        private @PlayerInputsController m_Wrapper;
        public DefaultActions(@PlayerInputsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Track1 => m_Wrapper.m_Default_Track1;
        public InputAction @Track2 => m_Wrapper.m_Default_Track2;
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
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnTrack1(InputAction.CallbackContext context);
        void OnTrack2(InputAction.CallbackContext context);
    }
}
