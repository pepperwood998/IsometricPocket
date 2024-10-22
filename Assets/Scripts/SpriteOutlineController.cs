using UnityEngine;

public class SpriteOutlineController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void ToggleEnable(bool enable)
    {
        var material = spriteRenderer.material;
        material.SetInt("_Enable", enable ? 1 : 0);
    }
}
