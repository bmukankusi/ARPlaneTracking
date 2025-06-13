using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material objectMaterial; // Assign in inspector

    public void ChangeColor(Color newColor)
    {
        objectMaterial.color = newColor;
    }
}
