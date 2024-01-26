using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeScreen : MonoBehaviour
{
    public GameObject inputCanvas;

    GameObject _tutorial;
    GameObject _startScreen;
    Animator _closeTutorialButton;
    // Start is called before the first frame update
    void Awake()
    {
        _startScreen = transform.GetChild(0).gameObject;
        _tutorial = transform.Find("Tutorial").gameObject;
        _closeTutorialButton = _tutorial.transform.GetChild(0).GetComponent<Animator>();
        _tutorial.SetActive(false);

        inputCanvas.SetActive(false);
    }

    public void StartGame()
    {
        inputCanvas.SetActive(true);
        _startScreen.SetActive(false);
    }
    public void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        _closeTutorialButton.SetTrigger("Press");
        StartCoroutine(WaitToClose());
    }

    IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(0.3f);
        _tutorial.SetActive(false);
    }
}
