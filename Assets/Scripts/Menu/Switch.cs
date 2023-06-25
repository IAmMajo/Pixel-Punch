using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Gobos;
    public GameObject[] Texts;
    int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index > 2)
            index = 2;

        if (index < 0)
            index = 0;

        if (index == 0)
        {
            Gobos[0].gameObject.SetActive(true);
            Texts[0].gameObject.SetActive(true);
        }
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


        for (int i = 0; i < Gobos.Length; i++)
        {
            Gobos[i].gameObject.SetActive(false);
            Gobos[index].gameObject.SetActive(true);
            Texts[i].gameObject.SetActive(false);
            Texts[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

    public void Previous()
    {
        if (index > 0)
        {
            index -= 1;
        }
        else
        {
            index = Gobos.Length-1;
        }
        

        for (int i = 0; i < Gobos.Length; i++)
        {
            Gobos[i].gameObject.SetActive(false);
            Gobos[index].gameObject.SetActive(true);
            Texts[i].gameObject.SetActive(false);
            Texts[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }
}
