using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Gobos;
    public Sprite[] Texts;
    int index;

    Image preview;
    [SerializeField]
    GameObject textArea;
    Image textPreview;
    void Start()
    {
        index = 0;
        preview = GetComponent<Image>();
        preview.sprite = Gobos[index];
        textPreview = textArea.GetComponent<Image>();
        textPreview.sprite = Texts[index];
    }

    public void Next()
    {
        if (index < Gobos.Length - 1)
        {
            index += 1;
        }
        else
        {
            index = 0;
        }

        preview.sprite = Gobos[index];
        textPreview.sprite = Texts[index];
    }

    public void Previous()
    {
        if (index > 0)
        {
            index -= 1;
        }
        else
        {
            index = Gobos.Length - 1;
        }

        preview.sprite = Gobos[index];
        textPreview.sprite = Texts[index];
    }
}
