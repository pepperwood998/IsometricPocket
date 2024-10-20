using UnityEngine;

public class ActorAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public readonly static string[] StaticAnimNames =
    {
        "Static N", "Static NW", "Static W", "Static SW",
        "Static S", "Static SE", "Static E", "Static NE"
    };

    public readonly static string[] RunAnimNames =
    {
        "Run N", "Run NW", "Run W", "Run SW",
        "Run S", "Run SE", "Run E", "Run NE"
    };

    public void Move(Vector2 direction)
    {
        string[] animNames = StaticAnimNames;
        if (direction.sqrMagnitude > 0.01f)
        {
            animNames = RunAnimNames;
        }

        int moveAnimIndex = GetMoveAnimIndexFromDir(direction);
        animator.Play(animNames[moveAnimIndex]);
    }

    private int GetMoveAnimIndexFromDir(Vector2 direction)
    {
        float sliceAngle = 360f / 8f;
        float angleOffset = sliceAngle / 2f;

        direction = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        angle += angleOffset; // Centerize target direction
        if (angle < 0f)
        {
            angle += 360f;
        }

        int index = Mathf.FloorToInt(angle / sliceAngle);
        return index;
    }
}
