using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    AudioClip[] musics;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("MusicController").Length != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(string pMusicType)
    {
        Debug.Log(audioSource.clip + " " + audioSource.isPlaying);
        switch (pMusicType)
        {
            case "MAP":
            if (audioSource.clip != musics[1])
            {
                audioSource.clip = musics[1];
            }
                
                break;
            default:
                if (audioSource.clip != musics[0])
            {
                audioSource.clip = musics[0];
            }
                break;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetVolume(float pV)
    {
        audioSource.volume = pV;
    }
}
