using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Button[] colorButtons;
    [SerializeField] private Color[] colors;

    private void Start()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() => ChangeColor(index));
        }
    }

    private void ChangeColor(int colorIndex)
    {
        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[colorIndex];
            }
        }
    }
}