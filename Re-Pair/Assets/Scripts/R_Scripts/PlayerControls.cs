// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/R_Scripts/PlayerControls.inputactions'

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Utilities;

//public class @PlayerControls : IInputActionCollection, IDisposable
//{
//    public InputActionAsset asset { get; }
//    public @PlayerControls()
//    {
//        asset = InputActionAsset.FromJson(@"{
//    ""name"": ""PlayerControls"",
//    ""maps"": [
//        {
//            ""name"": ""Gameplay"",
//            ""id"": ""db03c17b-9a4e-42e1-8916-5b10b36b0a7c"",
//            ""actions"": [
//                {
//                    ""name"": ""Left Movement"",
//                    ""type"": ""Button"",
//                    ""id"": ""2261fae2-fd29-4a84-8633-1d40e072d2cf"",
//                    ""expectedControlType"": """",
//                    ""processors"": """",
//                    ""interactions"": """"
//                },
//                {
//                    ""name"": ""Right Movement"",
//                    ""type"": ""Button"",
//                    ""id"": ""cfb59bba-2ce3-4504-8335-471b85995bff"",
//                    ""expectedControlType"": """",
//                    ""processors"": """",
//                    ""interactions"": """"
//                }
//            ],
//            ""bindings"": [
//                {
//                    ""name"": """",
//                    ""id"": ""24168146-483d-433a-8b4f-b91dda5f30b9"",
//                    ""path"": ""<Gamepad>/leftStick"",
//                    ""interactions"": """",
//                    ""processors"": """",
//                    ""groups"": """",
//                    ""action"": ""Left Movement"",
//                    ""isComposite"": false,
//                    ""isPartOfComposite"": false
//                },
//                {
//                    ""name"": """",
//                    ""id"": ""9d0a8cd2-feff-4803-bcab-452afc19f64b"",
//                    ""path"": ""<Gamepad>/rightStick"",
//                    ""interactions"": """",
//                    ""processors"": """",
//                    ""groups"": """",
//                    ""action"": ""Right Movement"",
//                    ""isComposite"": false,
//                    ""isPartOfComposite"": false
//                }
//            ]
//        }
//    ],
//    ""controlSchemes"": []
//}");
//        // Gameplay
//        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
//        m_Gameplay_LeftMovement = m_Gameplay.FindAction("Left Movement", throwIfNotFound: true);
//        m_Gameplay_RightMovement = m_Gameplay.FindAction("Right Movement", throwIfNotFound: true);
//    }

//    public void Dispose()
//    {
//        UnityEngine.Object.Destroy(asset);
//    }

//    public InputBinding? bindingMask
//    {
//        get => asset.bindingMask;
//        set => asset.bindingMask = value;
//    }

//    public ReadOnlyArray<InputDevice>? devices
//    {
//        get => asset.devices;
//        set => asset.devices = value;
//    }

//    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

//    public bool Contains(InputAction action)
//    {
//        return asset.Contains(action);
//    }

//    public IEnumerator<InputAction> GetEnumerator()
//    {
//        return asset.GetEnumerator();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return GetEnumerator();
//    }

//    public void Enable()
//    {
//        asset.Enable();
//    }

//    public void Disable()
//    {
//        asset.Disable();
//    }

//    // Gameplay
//    private readonly InputActionMap m_Gameplay;
//    private IGameplayActions m_GameplayActionsCallbackInterface;
//    private readonly InputAction m_Gameplay_LeftMovement;
//    private readonly InputAction m_Gameplay_RightMovement;
//    public struct GameplayActions
//    {
//        private @PlayerControls m_Wrapper;
//        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
//        public InputAction @LeftMovement => m_Wrapper.m_Gameplay_LeftMovement;
//        public InputAction @RightMovement => m_Wrapper.m_Gameplay_RightMovement;
//        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
//        public void Enable() { Get().Enable(); }
//        public void Disable() { Get().Disable(); }
//        public bool enabled => Get().enabled;
//        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
//        public void SetCallbacks(IGameplayActions instance)
//        {
//            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
//            {
//                @LeftMovement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMovement;
//                @LeftMovement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMovement;
//                @LeftMovement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMovement;
//                @RightMovement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMovement;
//                @RightMovement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMovement;
//                @RightMovement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMovement;
//            }
//            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
//            if (instance != null)
//            {
//                @LeftMovement.started += instance.OnLeftMovement;
//                @LeftMovement.performed += instance.OnLeftMovement;
//                @LeftMovement.canceled += instance.OnLeftMovement;
//                @RightMovement.started += instance.OnRightMovement;
//                @RightMovement.performed += instance.OnRightMovement;
//                @RightMovement.canceled += instance.OnRightMovement;
//            }
//        }
//    }
//    public GameplayActions @Gameplay => new GameplayActions(this);
//    public interface IGameplayActions
//    {
//        void OnLeftMovement(InputAction.CallbackContext context);
//        void OnRightMovement(InputAction.CallbackContext context);
//    }
//}
