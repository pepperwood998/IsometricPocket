using UnityEngine;

public class ActorMoveController : MonoBehaviour
{
    [Header("Setting Fields")]
    [SerializeField] private float speed = 10f;

    [Header("Other Fields")]
    [SerializeField] private Rigidbody2D rb;

    public void Move(Vector2 axisValues)
    {
        axisValues = axisValues.normalized;
        rb.velocity = axisValues * speed;
    }
}
