using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Player
{
    /// <summary>
    /// Class used to move the player around the game map
    /// The functions are meant to be called from the InputManager class
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        #region VARIABLES
        private CharacterController _charaController;
        private Vector3 _velocity;
        private float _gravity;
        private bool _isGrounded;
        private float _curSpeed;
        [Header("Basic Player Settings")]
        [SerializeField] private float _baseSpeed = 5f;
        [SerializeField] private float _jumpHeight = 3f;
        #endregion

        #region SETUP FUNCTIONS
        private void Awake()
        {
            _charaController = GetComponent<CharacterController>();
            _gravity = GameParams.P_GRAVITY;
            _curSpeed = _baseSpeed;
        }
        #endregion

        #region MOVEMENT FUNCTIONS
        private void FixedUpdate()
        {
            _isGrounded = _charaController.isGrounded;
        }

        /// <summary>
        /// Move function
        /// </summary>
        /// <param name="input">Input of the movement</param>
        public void Move(Vector2 input)
        {
            Vector3 direction = Vector3.zero;
            direction.x = input.x;
            direction.z = input.y;
            
            _charaController.Move(_curSpeed * Time.deltaTime * transform.TransformDirection(direction));
            _velocity.y += _gravity * Time.deltaTime;
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
            _charaController.Move(_velocity * Time.deltaTime);
        }

        /// <summary>
        /// Jump function
        /// </summary>
        public void Jump()
        {
            if (_isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -0.6f * _gravity);
            }
        }
        #endregion

    }
}
