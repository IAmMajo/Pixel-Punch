using UnityEngine;
using UnityEngine.UI;

public class ButtonStyling : MonoBehaviour
{
    [SerializeField]
    Color defaultColor;

    [SerializeField]
    Color selectionColor;

    private void Start()
    {
        foreach (Button button in FindObjectsOfType<Button>())
        {
            ColorBlock colors = button.colors;
            colors.selectedColor = selectionColor;
            colors.normalColor = defaultColor;
            colors.highlightedColor = selectionColor;
            button.colors = colors;
        }

        foreach (Toggle toggle in FindObjectsOfType<Toggle>())
        {
            ColorBlock colors = toggle.colors;
            colors.selectedColor = selectionColor;
            colors.normalColor = defaultColor;
            colors.highlightedColor = selectionColor;
            toggle.colors = colors;
        }

        foreach(Slider slider in FindObjectsOfType<Slider>())
        {
            ColorBlock colors = slider.colors;
            colors.selectedColor = selectionColor;
            colors.normalColor = defaultColor;
            colors.highlightedColor = selectionColor;
            slider.colors = colors;
        }
    }
}
