using System;
using UnityEngine;

public class ActorInteractionController : MonoBehaviour
{
    [SerializeField] private ActorController actor;
    [SerializeField] private CircleCollider2D rangeCollider;
    [SerializeField] private LayerMask itemLayerMask;

    private RaycastHit2D[] _cachedHits = new RaycastHit2D[10];

    private PickableItem _holdingItem;

    public void CheckInteractItem()
    {
        int count = CheckHits(itemLayerMask, out var hits);
        for (int i = 0; i < count; i++)
        {
            var hit = hits[i];
            if (hit.collider)
            {
                var item = hit.collider.GetComponentInParent<BaseItem>();
                if (item)
                {
                    item.Interact(actor);
                    break;
                }
            }
        }
    }

    public void PickUp(PickableItem item)
    {
        _holdingItem = item;
    }

    public void TryDropHolding()
    {
        if (_holdingItem)
        {
            _holdingItem.GetDrop(actor);
        }
        _holdingItem = null;
    }

    private int CheckHits(int layerMask, out RaycastHit2D[] hits)
    {
        int count = Physics2D.CircleCastNonAlloc(rangeCollider.transform.position, rangeCollider.radius, Vector2.zero, _cachedHits, 0, layerMask);
        hits = _cachedHits;
        return count;
    }
}
