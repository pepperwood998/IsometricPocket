using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] private ActorMoveController moveController;
    [SerializeField] private ActorInteractionController interactionController;
    [SerializeField] private ActorAnimationController animController;
    [SerializeField] private Transform statusPoint;

    public Transform StatusPoint => statusPoint;
    public Vector2 Position => transform.position;

    public Vector2 Direction { get; private set; }

    public void Move(Vector2 axisValues)
    {
        moveController.Move(axisValues);
        bool move = animController.TryMove(axisValues);
        if (move)
        {
            Direction = axisValues.normalized;
        }
    }

    public void Interact()
    {
        interactionController.TryInteractItem();
    }

    public void PickUp(PickableItem item)
    {
        interactionController.PickUp(item);
    }

    public void Drop()
    {
        interactionController.TryDropHolding();
    }
}
