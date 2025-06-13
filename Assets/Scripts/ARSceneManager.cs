using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ARSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private TMP_Text planeDetectionText;
    [SerializeField] private Material objectMaterial;

    private ARPlaneManager planeManager;
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    // Public property to access the spawned object
    public GameObject SpawnedObject => spawnedObject;

    void Start()
    {
        planeManager = GetComponent<ARPlaneManager>();
        raycastManager = GetComponent<ARRaycastManager>();
        planeDetectionText.text = "Searching for planes...";
    }

    void Update()
    {
        if (planeManager.trackables.count > 0 && planeDetectionText.text != "Plane detected!")
        {
            planeDetectionText.text = "Plane detected!";
        }
    }

    public void PlaceObject(Vector2 touchPosition)
    {
        if (spawnedObject != null) return;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            spawnedObject = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);

            // Apply the material to the spawned object
            Renderer renderer = spawnedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = objectMaterial;
            }

            // Disable plane detection after placement
            planeManager.enabled = false;
            planeDetectionText.text = "Object placed!";

            // Disable all plane visuals
            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeObjectColor(Color newColor)
    {
        if (spawnedObject != null)
        {
            // Get or create material instance to avoid changing all objects
            Renderer renderer = spawnedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (renderer.material != null)
                {
                    renderer.material = new Material(renderer.material);
                    renderer.material.color = newColor;
                }
            }
        }
    }
    //Back to MainMenu scene
    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
    }
}