// GENERATED AUTOMATICALLY FROM 'Assets/StarFighters/StarFighterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace StarlightDrifter.StarFighter
{
    public class @StarFighterControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @StarFighterControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""StarFighterControls"",
    ""maps"": [
        {
            ""name"": ""StarFighter"",
            ""id"": ""7a579a83-e27e-4db4-a10b-351e90dc7609"",
            ""actions"": [
                {
                    ""name"": ""Pitch"",
                    ""type"": ""Button"",
                    ""id"": ""ab2c7b66-8c7f-4416-bee1-adb1e40b6cd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""Button"",
                    ""id"": ""04fe2e2a-7520-4240-9e5b-0fa33f2e1f6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""2bf2f7e5-cac6-468d-bcf6-6fed54548f07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1f5a4905-ca90-4290-9d9f-82b1ef04db92"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0a9895a9-2c6c-455d-a1ba-faa6409a5a28"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""251e9366-c07b-4c9d-95c3-459ca4accc37"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""27ff2fe3-651a-4fad-bebc-db8e9854350a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""345f45af-ed35-4e50-805c-37ea9d43209c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f4be330-5f56-48ec-9ce2-22701935ea4f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fd9fc3f5-a4a2-407f-b72a-e2e85ce28b30"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d3cb4b3a-0c04-4015-8f6b-7bc53f609027"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ec7f649-eedd-4972-bd0b-58af49f61675"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // StarFighter
            m_StarFighter = asset.FindActionMap("StarFighter", throwIfNotFound: true);
            m_StarFighter_Pitch = m_StarFighter.FindAction("Pitch", throwIfNotFound: true);
            m_StarFighter_Yaw = m_StarFighter.FindAction("Yaw", throwIfNotFound: true);
            m_StarFighter_Roll = m_StarFighter.FindAction("Roll", throwIfNotFound: true);
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

        // StarFighter
        private readonly InputActionMap m_StarFighter;
        private IStarFighterActions m_StarFighterActionsCallbackInterface;
        private readonly InputAction m_StarFighter_Pitch;
        private readonly InputAction m_StarFighter_Yaw;
        private readonly InputAction m_StarFighter_Roll;
        public struct StarFighterActions
        {
            private @StarFighterControls m_Wrapper;
            public StarFighterActions(@StarFighterControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pitch => m_Wrapper.m_StarFighter_Pitch;
            public InputAction @Yaw => m_Wrapper.m_StarFighter_Yaw;
            public InputAction @Roll => m_Wrapper.m_StarFighter_Roll;
            public InputActionMap Get() { return m_Wrapper.m_StarFighter; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(StarFighterActions set) { return set.Get(); }
            public void SetCallbacks(IStarFighterActions instance)
            {
                if (m_Wrapper.m_StarFighterActionsCallbackInterface != null)
                {
                    @Pitch.started -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnPitch;
                    @Pitch.performed -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnPitch;
                    @Pitch.canceled -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnPitch;
                    @Yaw.started -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnYaw;
                    @Yaw.performed -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnYaw;
                    @Yaw.canceled -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnYaw;
                    @Roll.started -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnRoll;
                    @Roll.performed -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnRoll;
                    @Roll.canceled -= m_Wrapper.m_StarFighterActionsCallbackInterface.OnRoll;
                }
                m_Wrapper.m_StarFighterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pitch.started += instance.OnPitch;
                    @Pitch.performed += instance.OnPitch;
                    @Pitch.canceled += instance.OnPitch;
                    @Yaw.started += instance.OnYaw;
                    @Yaw.performed += instance.OnYaw;
                    @Yaw.canceled += instance.OnYaw;
                    @Roll.started += instance.OnRoll;
                    @Roll.performed += instance.OnRoll;
                    @Roll.canceled += instance.OnRoll;
                }
            }
        }
        public StarFighterActions @StarFighter => new StarFighterActions(this);
        private int m_MouseandKeyboardSchemeIndex = -1;
        public InputControlScheme MouseandKeyboardScheme
        {
            get
            {
                if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
                return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
            }
        }
        public interface IStarFighterActions
        {
            void OnPitch(InputAction.CallbackContext context);
            void OnYaw(InputAction.CallbackContext context);
            void OnRoll(InputAction.CallbackContext context);
        }
    }
}
