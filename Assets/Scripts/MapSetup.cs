using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSetup : MonoBehaviour
{

    [SerializeField]
    GameObject goboBase;
    [SerializeField]
    GameObject goboAlch;
    [SerializeField]
    GameObject goboMage;

    [SerializeField]
    GameObject player1Selector;
    [SerializeField]
    GameObject player2Selector;
    public static int player1Selected;
    public static int player2Selected;
    [SerializeField]
    GameObject mapSelector;
    public static int mapSelected;
    string[] scenes = {"Map/HeavenMap/HeavenMap","Map/CaveMap/CaveMap"};
    void Start()
    {
        GameObject o1 = GameObject.FindGameObjectWithTag("Player1Selector");
        GameObject o2 = GameObject.FindGameObjectWithTag("Player2Selector");
        if (o1 != null && o2 != null)
        {
            o1.GetComponent<Switch>().index = player1Selected;
            o2.GetComponent<Switch>().index = player2Selected;
        }

        foreach (string scene in scenes)
        {
            if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName(scene)))
            {
                SpawnPlayer(player1Selected,1);
                SpawnPlayer(player2Selected,2);
                break;
            }
        }
            
        
    }


    public void ChangeToMap()
    {
        SceneManager.LoadScene(scenes[mapSelected]);
    }

    public void SetPlayer1Select()
    {
        player1Selected = player1Selector.GetComponent<Switch>().index;
    }
    public void SetPlayer2Select()
    {
        player2Selected = player2Selector.GetComponent<Switch>().index;
    }
    public void SetMap()
    {
        mapSelected = mapSelector.GetComponent<SwitchMap>().GetIndex();
     }

    void SpawnPlayer(int pCharID, int pPlayerNumber)
    {
        string spawnTag = "Spawn" + pPlayerNumber;
        GameObject spawn = GameObject.FindGameObjectWithTag(spawnTag);

        switch (pCharID)
        {
            case 0:
                Instantiate(goboBase, spawn.transform);
                break;
            case 1:
                Instantiate(goboAlch, spawn.transform);
                break;
            case 2:
                Instantiate(goboMage, spawn.transform);
                break;

            default:
                break;
        }

    }
}
