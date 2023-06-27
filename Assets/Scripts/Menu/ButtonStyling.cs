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
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            ColorBlock colors = button.colors;
            colors.selectedColor = selectionColor;
            colors.normalColor = defaultColor;
            colors.highlightedColor = selectionColor;
            button.colors = colors;
        }
    }
}
