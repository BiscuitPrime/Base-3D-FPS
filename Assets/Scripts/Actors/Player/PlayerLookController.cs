using UnityEngine;

namespace Player
{
    /// <summary>
    /// Class used to handle the look inputs of the player, allowing it to look around the game
    /// </summary>
    public class PlayerLookController : MonoBehaviour
    {
        #region VARIABLES
        private Camera _cam;
        private float _upRotation = 0f;
        [SerializeField] private readonly float _xSensitivity = 40f;
        [SerializeField] private readonly float _ySensitivity = 40f;
        #endregion

        private void Awake()
        {
            _cam = GetComponentInChildren<Camera>();
        }

        /// <summary>
        /// Look Function
        /// </summary>
        /// <param name="input">Look input i.e. mouse delta</param>
        public void Look(Vector2 input)
        {
            float mouseX = input.x;
            float mouseY = input.y;
            //Looking up and down :
            _upRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
            _upRotation = Mathf.Clamp(_upRotation, -GameParams.P_CAMERA_SENSITIVITY, GameParams.P_CAMERA_SENSITIVITY);
            //apply it :
            _cam.transform.localRotation = Quaternion.Euler(_upRotation, 0f, 0f);
            //rotate left-right :
            transform.Rotate(_xSensitivity * (mouseX * Time.deltaTime) * Vector3.up);
        }
    }
}
