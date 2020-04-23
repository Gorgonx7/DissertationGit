using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class ColorImage : MonoBehaviour
{
    public ColorPicker picker;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();

    }

    private void OnDestroy()
    {
      
    }

    private void ColorChanged(Color newColor)
    {
        image.color = newColor;
    }
}
