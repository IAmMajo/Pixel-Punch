using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Gobos;
    public Sprite[] Texts;
    public int index;

    Image preview;
    [SerializeField]
    GameObject textArea;
    Image textPreview;
    [SerializeField]
    GameObject remeberer;
    void Start()
    {
        preview = GetComponent<Image>();

        textPreview = textArea.GetComponent<Image>();
    }

    void Update()
    {
        preview.sprite = Gobos[index];
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
    }
}
