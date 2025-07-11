using UnityEngine;
using UnityEngine.InputSystem;

namespace Caber.DemoGame.Player
{
    public class PlayerMove : MonoBehaviour
    {
        //_rigid body is a private perameter tieing the rigidbody to the rest of the player
        private Rigidbody _rigidbody;
        // moveSpeed is the base speed multiplier for player movment
        public float moveSpeed = 10f;
        public float jumpForce = 2000f;
        public float rotateSpeed = 10f;
        // 
        public InputActionAsset InputActions;
        
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _lookAction;
        
        private Vector2 _moveInput;
        private Vector2 _lookInput;
    
        /* Start runs when the script is called
         in: void
         out: void
         throws: none
         */
        void Start()
        {
            InputActions.FindActionMap("Player").Enable();
        }

        /* Awake runs when the script is initialized
         in: void
         out: void
         throws: none
         */
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _moveAction = InputSystem.actions.FindAction("Move");
            _lookAction = InputSystem.actions.FindAction("Look");
            _jumpAction = InputSystem.actions.FindAction("Jump");
        }

        /* Update runs every frame
         in: void
         out: void
         throws: none
         */
        void Update()
        {
            _moveInput = _moveAction.ReadValue<Vector2>();
            _lookInput = _lookAction.ReadValue<Vector2>();

            if (_jumpAction.WasReleasedThisFrame())
            {
                Jump();
            }
            
            GroundedMove();
        }
    
        /* FixedUpdate runs when the script is initialized
         in: void
         out: void
         throws: none
         */
        void FixedUpdate()
        {
            
        }

        private void OnEnable()
        {
            InputActions.FindActionMap("Player").Enable();
        }
        
        private void OnDisable()
        {
            InputActions.FindActionMap("Player").Disable();
        }
    
        /* GroundedMove moves the player called in Update while on the floor or in the air
         in: void
         out: void
         throws: none
         */
        void GroundedMove()
        {
            _rigidbody.MovePosition(_rigidbody.position +
                                    transform.forward * _moveInput.y * moveSpeed * Time.deltaTime);
        }
        
        private void Jump()
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("Jump: "+jumpForce);
        }

    }
    
}
