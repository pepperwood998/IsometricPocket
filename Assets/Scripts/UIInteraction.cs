using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    public static UIInteraction Instance { get; private set; }

    [SerializeField] private RectTransform root;
    [SerializeField] private Camera worldCamera;
    [SerializeField] private RectTransform textInteractPoint;
    [SerializeField] private RectTransform textDropPoint;
    [SerializeField] private Vector2 offset;

    private Transform _targetInteract;
    private Transform _targetDrop;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ToggleInteract(false);
        ToggleDrop(false);
    }

    private void Update()
    {
        if (_targetInteract)
        {
            var anchoredPosition = GetShowPosition(_targetInteract.position);

            textInteractPoint.anchoredPosition = anchoredPosition;
        }

        if (_targetDrop)
        {
            var anchoredPosition = GetShowPosition(_targetDrop.position);

            textDropPoint.anchoredPosition = anchoredPosition;
        }
    }

    public void ShowInteract(Transform target)
    {
        _targetInteract = target;

        var anchoredPosition = GetShowPosition(target.position);
        textInteractPoint.anchoredPosition = anchoredPosition;

        ToggleInteract(true);
        ToggleDrop(false);
    }

    public void HideInteract()
    {
        _targetInteract = null;

        ToggleInteract(false);
    }

    private void ToggleInteract(bool enable)
    {
        textInteractPoint.gameObject.SetActive(enable);
    }

    public void ShowDrop(Transform target)
    {
        _targetDrop = target;

        var anchoredPosition = GetShowPosition(target.position);
        textDropPoint.anchoredPosition = anchoredPosition;

        ToggleInteract(false);
        ToggleDrop(true);
    }

    public void HideDrop()
    {
        _targetDrop = null;

        ToggleDrop(false);
    }


    private void ToggleDrop(bool enable)
    {
        textDropPoint.gameObject.SetActive(enable);
    }

    private Vector2 GetShowPosition(Vector2 worldPosition)
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(worldCamera, worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(root, screenPoint, null, out var anchoredPosition);
        return anchoredPosition + offset;
    }
}
