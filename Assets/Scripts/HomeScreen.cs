using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenTutorial()
    {

    }
}
