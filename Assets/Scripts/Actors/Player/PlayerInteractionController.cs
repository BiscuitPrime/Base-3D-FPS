using Interactables;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Class that will handle the player interactions with objects in the world
    /// </summary>
    public class PlayerInteractionController : MonoBehaviour
    {
        #region VARIABLES
        private Camera _cam;
        private RaycastHit hit;
        private IInteractable _interactedEntity;

        [Header("Hand Elements")]
        [SerializeField] private GameObject _playerHand;
        private bool _handIsFree = true; 

        private bool _isHitting;
        #endregion

        private void Awake()
        {
            _cam = GetComponentInChildren<Camera>();
        }

        #region GETTER AND SETTER FUNCTIONS
        public GameObject GetPlayerHand() { return _playerHand; }
        public bool IsHandFree() { return _handIsFree; }
        public void SetIsHandFree(bool status) {  _handIsFree = status; }
        #endregion

        private void Update()
        {
            if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, GameParams.P_INTERACT_RAY_LENGTH) && hit.transform.gameObject.TryGetComponent<IInteractable>(out _interactedEntity))
            {
                _isHitting = true;
                //Deploy UI visual
            }
            else
            {
                _isHitting = false;
                //Hide UI visual
                _interactedEntity = null;
            }
        }

        /// <summary>
        /// Function called by InputManager, when a player is performing an interact
        /// </summary>
        public void TryInteraction()
        {
            if (_isHitting)
            {
                _interactedEntity?.Interact(this);
            }
        }

        /// <summary>
        /// Function called by InputManager, when a player tries to empty their hand
        /// </summary>
        public void Drop()
        {
            if (_playerHand.GetComponentInChildren<IInteractable>() is PickableController)
            {
                _playerHand.GetComponentInChildren<PickableController>().Drop(this);
            }
        }  
    }
}
