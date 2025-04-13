using Player;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Class used by Pickable entities : entities that can be picked up by the player
    /// </summary>
    public class PickableController : MonoBehaviour, IInteractable
    {
        /// <summary>
        /// Function handling the pickup of the pickable entity
        /// </summary>
        /// <param name="interactor">Interactor calling the interact function</param>
        public void Interact(PlayerInteractionController interactor)
        {
            if (interactor.IsHandFree())
            {
                transform.position = interactor.GetPlayerHand().transform.position;
                transform.parent = interactor.GetPlayerHand().transform;
                interactor.SetIsHandFree(false);
            }
        }

        /// <summary>
        /// Function handling the drop of the pickable entity
        /// </summary>
        /// <param name="interactor">Interactor calling the drop function</param>
        public void Drop(PlayerInteractionController interactor)
        {
            transform.parent = null;
            interactor.SetIsHandFree(true);
        }
    }
}
