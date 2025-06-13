using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneDetectionStatus : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private Text statusText;
    [SerializeField] private float messageDuration = 4f;

    private bool planeDetected = false;
    private float hideTime;

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
        if (!planeDetected && args.added.Count > 0)
        {
            planeDetected = true;
            statusText.text = "Plane detected!";
            hideTime = Time.time + messageDuration;
        }
    }

    private void Update()
    {
        if (!planeDetected)
        {
            statusText.text = "Searching for plane...";
        }
        else if (Time.time > hideTime)
        {
            statusText.text = "";
        }
    }
}
