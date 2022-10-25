using UnityEngine;
using UnityEngine.InputSystem;

namespace _GameCore.Scripts
{
    public class CharacterMovementController : MonoBehaviour
    {
        private PlayerInput _playerInput; 
        private CharacterController _controller;
        public Animator _animator;
        private Vector3 _moveJoystick;
    
        [SerializeField] private float playerSpeed;
    
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
    
        void Start()
        {
            _playerInput = gameObject.GetComponent<PlayerInput>();
            _controller = gameObject.GetComponent<CharacterController>();
            _animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            SetInput();

            if (_moveJoystick != Vector3.zero)
                StartRun();
            
            else
                StopRun();
            
        }
        private void SetInput()
        {
            Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
            _moveJoystick = new Vector3(input.x, 0f, input.y);
        }
        
        private void StartRun()
        {
            _animator.SetBool(IsRunning, true);
            _controller.Move(_moveJoystick * (Time.deltaTime * playerSpeed));
            
            gameObject.transform.forward = _moveJoystick;

            gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        
        private void StopRun()
        {
            _animator.SetBool(IsRunning, false);
        }
        
    }
}
