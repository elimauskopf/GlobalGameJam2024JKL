using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameObject _main;
    Slider _volumeSlider;

    private void Awake()
    {
        _main = transform.GetChild(0).gameObject;
        _volumeSlider = _main.transform.GetChild(2).GetComponent<Slider>();
    }
    private void Start()
    {
        _volumeSlider.value = AudioListener.volume;
        _main.SetActive(false);
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
}
