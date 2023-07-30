using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicStarter : MonoBehaviour
{
    void Start()
    {
        MusicController musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>();
        musicController.PlayMusic("MENU");
        musicController.SetVolume(PlayerPrefs.GetFloat("VolumeValue",1f));
    }
}
