using Player;

namespace Interactables
{
    /// <summary>
    /// Interface for Interactable entities : entities that can be interacted with (interactable) and picked up by the player (pickable)
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Function called upon interaction triggered by the player with the interactable entity
        /// </summary>
        /// <param name="interactor">Caller of the interact function</param>
        public void Interact(PlayerInteractionController interactor);
    }
}
