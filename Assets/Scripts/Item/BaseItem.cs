using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] protected Collider2D interactionCollider;
    [SerializeField] protected SpriteOutlineController outlineController;

    protected bool interactable;

    public Vector2 Position => transform.position;

    private void Start()
    {
        ToggleInteractable(true);
    }

    private void Update()
    {
        Tick();
    }

    protected virtual void Tick() { }

    public abstract void Interact(ActorController actor);

    public abstract void GetDrop(ActorController actor);

    public void ToggleTargeting(bool targeting)
    {
        outlineController.ToggleEnable(targeting);
    }

    protected void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    protected virtual void ToggleInteractable(bool interactable)
    {
        this.interactable = interactable;

        interactionCollider.enabled = interactable;
    }
}
