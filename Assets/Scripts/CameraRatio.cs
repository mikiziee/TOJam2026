using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraRatio : MonoBehaviour
{
    public Vector2 targetAspectRatio = new Vector2(16, 9);
    private Camera _camera;

    void Start() => _camera = GetComponent<Camera>();

    void Update() => AdjustCamera();

    void AdjustCamera()
    {
        float targetAspect = targetAspectRatio.x / targetAspectRatio.y;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Rect rect = _camera.rect;

        if (scaleHeight < 1.0f) // Pillarbox
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else // Letterbox
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }
        _camera.rect = rect;
    }
}
