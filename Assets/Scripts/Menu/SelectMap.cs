using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
     public void GoBack(){
        SceneManager.LoadScene(0);
    }

    public void SetCharacter(){
        SceneManager.LoadScene(2);
    }
}
