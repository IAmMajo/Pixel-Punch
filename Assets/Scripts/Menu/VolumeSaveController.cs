using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private Text volumeTextUI = null;


    private void OnEnable(){
        LoadValues();
    }
    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.00");

    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue",volumeValue);
        LoadValues();
        GameObject.FindGameObjectWithTag("MusicController")?.GetComponent<MusicController>().SetVolume(volumeValue);
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
    }

}
