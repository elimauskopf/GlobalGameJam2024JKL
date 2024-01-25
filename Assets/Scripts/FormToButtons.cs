using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormToButtons : MonoBehaviour
{
    private GameObject thoughtCanvas;
    private PlayerController playerController;
    private string _inputText;

    private void Awake()
    {
        thoughtCanvas = GameObject.Find("DogThoughtCanvas");
        playerController = GameObject.Find("Dog").GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInputText(string s)
    {
        _inputText = s;
    }

    public void GenerateWords()
    {
        string[] words = _inputText.Split(' ');
        Shuffle(words);

        

        CloseForm();

        
    }

    void Shuffle(string[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            string temp = s[i];
            int random = Random.Range(i, s.Length);
            s[i] = s[random];
            s[random] = temp;
        }
    }

    void CloseForm()
    {
        thoughtCanvas.SetActive(false);
        playerController.canPlayerMove = true;
        
    }
}
