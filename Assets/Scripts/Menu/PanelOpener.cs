using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject Panel;

    public void OpenSettings(){
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    
}
