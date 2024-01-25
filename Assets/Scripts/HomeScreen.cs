using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeScreen : MonoBehaviour
{
    GameObject _tutorial;
    Animator _closeTutorialButton;
    // Start is called before the first frame update
    void Awake()
    {
        _tutorial = transform.Find("Tutorial").gameObject;
        _closeTutorialButton = _tutorial.transform.GetChild(0).GetComponent<Animator>();
        _tutorial.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
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
