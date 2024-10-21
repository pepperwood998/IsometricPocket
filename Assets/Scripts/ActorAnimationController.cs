using UnityEngine;

public class ActorAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int _lastAnimIndex;

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

    public bool TryMove(Vector2 direction)
    {
        string[] animNames = StaticAnimNames;
        direction = direction.normalized;
        bool move = direction.sqrMagnitude > 0.01f;
        if (move)
        {
            animNames = RunAnimNames;

            _lastAnimIndex = GetMoveAnimIndexFromDir(direction);
        }

        animator.Play(animNames[_lastAnimIndex]);

        return move;
    }

    private int GetMoveAnimIndexFromDir(Vector2 direction)
    {
        float sliceAngle = 360f / 8f;
        float angleOffset = sliceAngle / 2f;

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
