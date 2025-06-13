using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputController : MonoBehaviour
{
    [SerializeField] private ARSceneManager sceneManager;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2f;

    private GameObject spawnedObject;
    private Vector2 touch1StartPos, touch2StartPos;
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (sceneManager.SpawnedObject == null) return;

        spawnedObject = sceneManager.SpawnedObject;

        // Handle single touch for placement
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            sceneManager.PlaceObject(Touchscreen.current.primaryTouch.position.ReadValue());
        }

        // Handle two touches for scaling and rotation
        if (Touchscreen.current.touches.Count == 2)
        {
            var touch1 = Touchscreen.current.touches[0];
            var touch2 = Touchscreen.current.touches[1];

            // On first frame of two touches
            if (touch1.press.wasPressedThisFrame || touch2.press.wasPressedThisFrame)
            {
                touch1StartPos = touch1.position.ReadValue();
                touch2StartPos = touch2.position.ReadValue();
                initialDistance = Vector2.Distance(touch1StartPos, touch2StartPos);
                initialScale = spawnedObject.transform.localScale;
            }

            // Current touch positions
            Vector2 touch1CurrentPos = touch1.position.ReadValue();
            Vector2 touch2CurrentPos = touch2.position.ReadValue();

            // Calculate scaling
            float currentDistance = Vector2.Distance(touch1CurrentPos, touch2CurrentPos);
            float scaleFactor = currentDistance / initialDistance;
            Vector3 newScale = initialScale * scaleFactor;
            newScale = Vector3.ClampMagnitude(newScale, maxScale);
            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);
            spawnedObject.transform.localScale = newScale;

            // Calculate rotation
            Vector2 previousDirection = touch2StartPos - touch1StartPos;
            Vector2 currentDirection = touch2CurrentPos - touch1CurrentPos;
            float angle = Vector2.SignedAngle(previousDirection, currentDirection);
            spawnedObject.transform.Rotate(Vector3.up, -angle * rotationSpeed * Time.deltaTime);
        }
    }
}