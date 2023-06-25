using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Gobo;
    public GameObject[] Text;
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
 
        if(index < 0)
        index = 0;

        if(index == 0)
        {
            Gobo[0].gameObject.SetActive(true);
            Text[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;

        for(int i = 0; i < Gobo.Length; i++)
        {
            Gobo[i].gameObject.SetActive(false);
            Gobo[index].gameObject.SetActive(true);
            Text[i].gameObject.SetActive(false);
            Text[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

        public void Previous()
        {
        index -= 1;

        for(int i = 0; i < Gobo.Length; i++)
        {
            Gobo[i].gameObject.SetActive(false);
            Gobo[index].gameObject.SetActive(true);
            Text[i].gameObject.SetActive(false);
            Text[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }
}
