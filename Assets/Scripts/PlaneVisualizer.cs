using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject placedObject;

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (placedObject != null)
        {
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;

            Debug.Log($"Planes changed. Added: {args.added.Count}, Updated: {args.updated.Count}, Removed: {args.removed.Count}");

            foreach (var plane in args.added)
            {
                Debug.Log($"New plane detected: {plane.trackableId}, size: {plane.size}");
            }
        }
    }
}