using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] private ActorMoveController moveController;
    [SerializeField] private ActorAnimationController animController;

    public void Move(Vector2 axisValues)
    {
        moveController.Move(axisValues);
        animController.Move(axisValues);
    }
}
