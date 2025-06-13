using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [System.Serializable]
    public class ColorButton
    {
        public Button button;
        public Color color;
    }

    [Header("References")]
    [SerializeField] private ARSceneManager arSceneManager;
    [SerializeField] private ColorButton[] colorButtons;

    void Start()
    {
        foreach (var colorButton in colorButtons)
        {
            // Set button appearance
            colorButton.button.GetComponent<Image>().color = colorButton.color;

            // Add click listener
            colorButton.button.onClick.AddListener(() =>
            {
                if (arSceneManager != null && arSceneManager.SpawnedObject != null)
                {
                    arSceneManager.ChangeObjectColor(colorButton.color);
                }
            });
        }
    }
}