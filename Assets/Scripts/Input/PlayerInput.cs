using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UIManager uIManager;
        // Game Actions 
        public event UnityAction onMove = delegate { };
        public event UnityAction offMove = delegate { };
        public event UnityAction onFire = delegate { };
        public event UnityAction offFire = delegate { };
        // UI Actions
        public event UnityAction onPause = delegate { };
        public event UnityAction onUnPause = delegate { };

        private void OnEnable()
        {

            onMove += playerController.OnMove;
            offMove += playerController.OffMove;
                
            onFire += playerController.OnFire;
            offFire += playerController.OffFire;
            onPause += uIManager.OnPause;
            onUnPause += uIManager.OnUnPause;

        }
        private void OnDisable()
        {
            onMove -= playerController.OnMove;
            offMove -= playerController.OffMove;
            onFire -= playerController.OnFire;
            offFire -= playerController.OffFire;
            onPause -= uIManager.OnPause;
            onUnPause -= uIManager.OnUnPause;
        }
        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (UIManager.Instance.Pause == false)
                {
                    
                    onPause.Invoke();
                }
                else
                {
                    onUnPause.Invoke();
                }
            }

        }
        public void OnUnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (UIManager.Instance.Pause == false)
                {
                    onPause.Invoke();
                }
                else
                {
                    onUnPause.Invoke();
                }
            }
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            playerController.Dirction = context.ReadValue<Vector2>();
     
        }
        public void OnShoot(InputAction.CallbackContext context)
        {

            if (context.phase == InputActionPhase.Performed)
            {
                onFire.Invoke();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                offFire.Invoke();
            }
        }

    }
}