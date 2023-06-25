using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMap : MonoBehaviour
{
   // Start is called before the first frame update
    public GameObject[] Map;
    int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index > 1)
        index = 1;
 
        if(index < 0)
        index = 0;

        if(index == 0)
        {
            Map[0].gameObject.SetActive(true);
        }
    }

    public void NextMap()
    {
        index += 1;

        for(int i = 0; i < Map.Length; i++)
        {
            Map[i].gameObject.SetActive(false);
            Map[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

        public void PreviousMap()
        {
        index -= 1;

        for(int i = 0; i < Map.Length; i++)
        {
            Map[i].gameObject.SetActive(false);
            Map[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }
}
