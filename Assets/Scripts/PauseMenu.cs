using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameObject _main;
    Slider _volumeSlider;
    Slider _musicSlider;

    private void Awake()
    {
        _main = transform.GetChild(0).gameObject;
        _volumeSlider = _main.transform.Find("VolumeSlider").GetComponent<Slider>();
        _musicSlider = _main.transform.Find("MusicVolume").GetComponent<Slider>();
    }
    private void Start()
    {
        _volumeSlider.value = AudioListener.volume;
        _musicSlider.value = 1;
        _main.SetActive(false);
    }

    public void PauseGame()
    {
        Debug.Log("Pause button pressed");
        if(_main.activeSelf)
        {
            Debug.Log("Enabling menu");
            _main.SetActive(false);
        }
        else
        {
            Debug.Log("Enabling menu");
            _main.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        _main.SetActive(false);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Home");
    }
    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
    }
    public void ChangeMusicVolume()
    {
        MusicController.Instance.ChangeMusicVolume(_musicSlider.value);
    }
}
