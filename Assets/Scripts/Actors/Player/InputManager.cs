using UnityEngine;
using static PlayerInputs;

namespace Player
{
    /// <summary>
    /// Class used to handle the player input as part of the new input system
    /// </summary>
    [RequireComponent(typeof(PlayerLookController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerInteractionController))]
    public class InputManager : MonoBehaviour
    {
        #region VARIABLES
        private PlayerInputs _input;
        private PlayerInputs.OnFootActions _onFootActions;
        
        private PlayerMovementController _movementController;
        private PlayerLookController _lookController;
        private PlayerInteractionController _interactionController;
        #endregion

        #region SETUP FUNCTIONS
        private void Awake()
        {
            _movementController = GetComponent<PlayerMovementController>();
            _lookController = GetComponent<PlayerLookController>();
            _interactionController = GetComponent<PlayerInteractionController>();

            _input = new PlayerInputs();
            _onFootActions = _input.OnFoot;

            SetCallbackActions();
        }

        /// <summary>
        /// Function that will setup the callback actions for the various inputs
        /// </summary>
        private void SetCallbackActions()
        {
            _onFootActions.Jump.performed += ctx => _movementController.Jump();
            _onFootActions.Interact.performed += ctx => _interactionController.TryInteraction();
            _onFootActions.Drop.performed += ctx => _interactionController.Drop();
        }

        private void OnEnable()
        {
            //we enable the player's input system when the player is enabled itself :
            _onFootActions.Enable();
        }

        private void OnDisable()
        {
            //we disable the player's input system when the player is disabled itself :
            _onFootActions.Disable();
        }
        #endregion

        #region UPDATES
        // FIXEDUPDATE FOR PHYSICS MOVEMENTS
        private void FixedUpdate()
        {
            _movementController.Move(_onFootActions.Movement.ReadValue<Vector2>());
        }

        // LATEUPDATE FOR CAMERA MOVEMENTS
        private void LateUpdate()
        {
            _lookController.Look(_onFootActions.Look.ReadValue<Vector2>());
        }

        //UPDATE FOR WEAPON/ACTIONS HANDLING
        private void Update()
        {

        }
        #endregion

    }
}
