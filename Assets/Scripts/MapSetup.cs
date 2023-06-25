using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetup : MonoBehaviour
{

    [SerializeField]
    GameObject goboBase;
    [SerializeField]
    GameObject goboAlch;
    [SerializeField]
    GameObject goboMage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
