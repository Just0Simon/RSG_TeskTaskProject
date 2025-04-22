using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Content.Features.ItemEffectsModule.Scripts.Input
{
    public class ActiveItemsInputListener : IActiveItemsInputListener, IInitializable, IDisposable
    {
        private const string PLAYER_ACTION_MAP = "Player";
        private const string NUMBER_ONE_ACTION = "Numbers";
        private const string HEAL_ACTION = "Heal";
        
        public event Action<int> OnActiveItemNumberPressed;
        public event Action OnHealActivateActionPerformed;
        
        private readonly InputActionAsset _inputActions;
        private InputAction _numbersAction;
        private InputAction _healAction;

        public ActiveItemsInputListener(InputActionAsset inputActionAsset)
        {
            _inputActions = inputActionAsset;
            Debug.Log($"{nameof(ActiveItemsInputListener)} constructed");
        }

        public void Initialize() {
            _inputActions.Enable();
            
            _numbersAction = _inputActions.FindActionMap(PLAYER_ACTION_MAP).FindAction(NUMBER_ONE_ACTION);
            _healAction = _inputActions.FindActionMap(PLAYER_ACTION_MAP).FindAction(HEAL_ACTION);
            
            _numbersAction.performed += OnNumbersActionPerformed;
            _healAction.performed += OnHealActionPerformed;
            Debug.Log($"{nameof(ActiveItemsInputListener)} initialized)");
        }
        
        private void OnNumbersActionPerformed(InputAction.CallbackContext obj)
        {
            var number = Mathf.FloorToInt(obj.ReadValue<float>());
            OnActiveItemNumberPressed?.Invoke(number);
            
            Debug.Log($"Number Pressed: {number}");
        }

        private void OnHealActionPerformed(InputAction.CallbackContext obj)
        {
            OnHealActivateActionPerformed?.Invoke();
            Debug.Log($"Heal Action Performed");
        }

        public void Dispose() {
            _inputActions.Disable();
            
            _numbersAction.performed -= OnNumbersActionPerformed;
        }
    }
}