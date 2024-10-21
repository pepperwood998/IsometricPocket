using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Other Fields")]
    [SerializeField] private BaseActorInputController actorInputController;

    [Header("Testing Fields")]
    [SerializeField] private ActorController actorController;

    private void Awake()
    {
        actorInputController.RegisterPhysicsMoveHandler(actorController.Move);
        actorInputController.RegisterInteractionHandler(actorController.Interact);
        actorInputController.RegisterDropHandler(actorController.Drop);
    }
}
