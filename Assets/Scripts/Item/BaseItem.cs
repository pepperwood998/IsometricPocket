using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] protected Collider2D interactionCollider;

    protected bool interactable;

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
