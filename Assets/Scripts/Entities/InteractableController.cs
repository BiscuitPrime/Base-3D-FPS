using Player;
using UnityEngine;

namespace Interactables
{
    /// <summary>
    /// Class used by Interactable entities : entities that can be interacted with but are NOT picked by the player
    /// </summary>
    public class InteractableController : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerInteractionController interactor)
        {
        }
    }
}
