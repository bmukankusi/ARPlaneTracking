using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneVisibilityDebugger : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TogglePlaneVisibility();
        }
    }

    private void TogglePlaneVisibility()
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(!plane.gameObject.activeSelf);
            Debug.Log($"Plane {plane.trackableId} visibility: {plane.gameObject.activeSelf}");
        }
    }
}