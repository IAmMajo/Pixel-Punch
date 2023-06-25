using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChar : MonoBehaviour
{
    public void GoBack(){
        SceneManager.LoadScene(0);
    }

    public void SetMap(){
        SceneManager.LoadScene(3);
    }

    }
