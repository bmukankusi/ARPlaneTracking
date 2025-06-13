using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private ARSceneManager sceneManager;
    [SerializeField] private Color[] colors;

    void Start()
    {
        // Create color buttons dynamically
        foreach (Color color in colors)
        {
            GameObject button = new GameObject("ColorButton");
            button.transform.SetParent(transform);

            Image img = button.AddComponent<Image>();
            img.color = color;

            Button btn = button.AddComponent<Button>();
            btn.onClick.AddListener(() => sceneManager.ChangeObjectColor(color));

            // Add simple UI effect
            var colorsBlock = btn.colors;
            colorsBlock.highlightedColor = color * 1.2f;
            btn.colors = colorsBlock;
        }
    }
}