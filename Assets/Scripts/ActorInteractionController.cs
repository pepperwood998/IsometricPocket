using UnityEngine;

public class ActorInteractionController : MonoBehaviour
{
    [SerializeField] private ActorController actor;
    [SerializeField] private CircleCollider2D rangeCollider;
    [SerializeField] private LayerMask itemLayerMask;

    private RaycastHit2D[] _cachedHits = new RaycastHit2D[10];

    private BaseItem _targetingItem;
    private PickableItem _holdingItem;

    private void Update()
    {
        BaseItem targetingItem = null;
        if (CheckInteractItem(out var item))
        {
            targetingItem = item;
        }

        if (targetingItem)
        {
            if (_targetingItem != targetingItem)
            {
                if (_targetingItem)
                {
                    _targetingItem.ToggleTargeting(false);
                }

                _targetingItem = targetingItem;
                _targetingItem.ToggleTargeting(true);

                UIInteraction.Instance.ShowInteract(_targetingItem.transform);
            }
        }
        else
        {
            if (_targetingItem)
            {
                _targetingItem.ToggleTargeting(false);
                _targetingItem = null;

                UIInteraction.Instance.HideInteract();
            }
        }
    }

    public void TryInteractItem()
    {
        if (_targetingItem)
        {
            TryDropHolding();

            _targetingItem.Interact(actor);
        }
    }

    public bool CheckInteractItem(out BaseItem targetItem)
    {
        targetItem = null;
        float minSqDist = float.MaxValue;
        int count = CheckHits(itemLayerMask, out var hits);
        for (int i = 0; i < count; i++)
        {
            var hit = hits[i];
            if (hit.collider)
            {
                var item = hit.collider.GetComponentInParent<BaseItem>();
                if (item)
                {
                    float sqDist = (actor.Position - item.Position).sqrMagnitude;
                    if (sqDist < minSqDist)
                    {
                        targetItem = item;
                        minSqDist = sqDist;
                    }
                }
            }
        }

        return targetItem != null;
    }

    public void PickUp(PickableItem item)
    {
        _holdingItem = item;

        UIInteraction.Instance.ShowDrop(_holdingItem.transform);
    }

    public void TryDropHolding()
    {
        if (_holdingItem)
        {
            _holdingItem.GetDrop(actor);
        }
        _holdingItem = null;

        UIInteraction.Instance.HideDrop();
    }

    private int CheckHits(int layerMask, out RaycastHit2D[] hits)
    {
        int count = Physics2D.CircleCastNonAlloc(rangeCollider.transform.position, rangeCollider.radius, Vector2.zero, _cachedHits, 0, layerMask);
        hits = _cachedHits;
        return count;
    }
}
