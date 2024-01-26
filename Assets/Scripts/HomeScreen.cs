using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeScreen : MonoBehaviour
{
    public GameObject inputCanvas;
    public GameObject _actionButtonsParent;

    GameObject _tutorial;
    GameObject _startScreen;
    GameObject _credits;
    Animator _closeTutorialButton;
    // Start is called before the first frame update
    void Awake()
    {
        _startScreen = transform.GetChild(0).gameObject;
        _tutorial = transform.Find("Tutorial").gameObject;
        _credits = transform.Find("Credits").gameObject;
        _closeTutorialButton = _tutorial.transform.GetChild(0).GetComponent<Animator>();
        _tutorial.SetActive(false);
        _credits.SetActive(false);
        _actionButtonsParent.SetActive(false);

        inputCanvas.SetActive(false);
    }

    public void StartGame()
    {
        //inputCanvas.SetActive(true);
        FormToButtons.Instance.ResetForm();
        _startScreen.SetActive(false);
        //_actionButtonsParent.SetActive(true);
    }
    public void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        _closeTutorialButton.SetTrigger("Press");
        _tutorial.SetActive(false);
    }

    public void OpenCredits()
    {
        _credits.SetActive(true);
    }
    public void CloseCredits()
    {
        _credits.SetActive(false);
    }
}
