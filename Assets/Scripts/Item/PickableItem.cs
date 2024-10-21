using UnityEngine;

public class PickableItem : BaseItem
{
    private Transform _followTarget;

    protected override void Tick()
    {
        base.Tick();

        CheckFollowTarget();
    }

    public override void Interact(ActorController actor)
    {
        if (!interactable)
        {
            return;
        }

        actor.PickUp(this);

        ToggleInteractable(false);

        _followTarget = actor.StatusPoint;
    }

    public override void GetDrop(ActorController actor)
    {
        SetPosition(actor.Position + actor.Direction * 0.25f);

        ToggleInteractable(true);

        _followTarget = null;
    }

    private void CheckFollowTarget()
    {
        if (_followTarget)
        {
            SetPosition(_followTarget.position);
        }
    }
}
