using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance { get; private set; }

    public float maxVolume;

    AudioSource _musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _musicSource = GetComponent<AudioSource>();
    }
    public void ChangeMusicVolume(float percent)
    {
        float volume = percent * maxVolume;
        _musicSource.volume = volume;
    }
}
