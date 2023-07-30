using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicStarter : MonoBehaviour
{
    void Start()
    {
        MusicController musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>();
        musicController.PlayMusic("MAP");
        musicController.SetVolume(PlayerPrefs.GetFloat("VolumeValue",1f));
    }
}
