using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private Transform followTarget;
    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform maxPoint;
    [SerializeField] private float smoothSpeed;

    private void LateUpdate()
    {
        var cameraPosition = targetCamera.transform.position;
        var targetPosition = new Vector3(followTarget.position.x, followTarget.position.y, cameraPosition.z);
        var position = Vector3.Lerp(cameraPosition, targetPosition, Time.deltaTime * smoothSpeed);

        var cameraSize = GetCameraSize();
        position = new Vector3(
            Mathf.Clamp(position.x, minPoint.position.x + cameraSize.x, maxPoint.position.x - cameraSize.x),
            Mathf.Clamp(position.y, minPoint.position.y + cameraSize.y, maxPoint.position.y - cameraSize.y),
            position.z);
        targetCamera.transform.position = position;
    }

    private Vector2 GetCameraSize()
    {
        float sizeY = targetCamera.orthographicSize;
        float sizeX = sizeY * targetCamera.aspect;
        return new Vector2(sizeX, sizeY);
    }
}
