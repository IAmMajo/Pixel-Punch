using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMap : MonoBehaviour
{
    public Sprite[] Maps;
    public Sprite[] Texts;
    public static int index;

    Image preview;

    [SerializeField]
    GameObject textArea;
    Image textPreview;
    void Start()
    {
        index = 0;
        preview = GetComponent<Image>();
        preview.sprite = Maps[index];
        textPreview = textArea.GetComponent<Image>();
        textPreview.sprite = Texts[index];
    }

    public int GetIndex()
    {
        return index;
    }

    public void Next()
    {
        if (index < Maps.Length - 1)
        {
            index += 1;
        }
        else
        {
            index = 0;
        }

        preview.sprite = Maps[index];
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
            index = Maps.Length - 1;
        }

        preview.sprite = Maps[index];
        textPreview.sprite = Texts[index];
    }
}
