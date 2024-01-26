using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormToButtons : MonoBehaviour
{
    private GameObject thoughtCanvas;
    public TMP_InputField inputField;
    private PlayerController playerController;
    private Transform buttonsParent;

    private string _inputText;
    private int _formCounter;
    private int _buttonIndex;

    public string inputPhraseOne;
    public string inputPhraseTwo;
    public string inputPhraseThree;



    private void Awake()
    {
        thoughtCanvas = GameObject.Find("DogThoughtCanvas");
        //inputField = thoughtCanvas.transform.Find("InputField").GetComponent<TMP_InputField>();
        playerController = GameObject.Find("Dog").GetComponent<PlayerController>();
        buttonsParent = GameObject.Find("Buttons").transform;
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

       /* if (words.Length > buttonsParent.childCount)
        {
            Array.Resize(ref words, buttonsParent.childCount);
        }*/

        Shuffle(words);

        PopulateButtons(words);
        
        _formCounter++;

        if (_formCounter == 1)
        {
            
            inputField.textComponent.text = "";
            inputField.text = inputPhraseTwo;
            _inputText = "";

        } else if (_formCounter == 2)
        {
            inputField.textComponent.text = "";
            inputField.text = inputPhraseThree;
            _inputText = "";

        } else
        {
            CloseForm();
        }
       

        
    }

    void Shuffle(string[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            string temp = s[i];
            int random = UnityEngine.Random.Range(i, s.Length);
            s[i] = s[random];
            s[random] = temp;
        }
    }

    // Populate buttons with word list, add filler if phrase too short
    void PopulateButtons(string[] words)
    {
        int j = 0;
        int categoryLength;

        if (_formCounter == 0 || _formCounter == 1) // nouns, adjectives
        {
            categoryLength = 5;
        }  else // Verbs
        {
            categoryLength = 4;
        }

        print(_buttonIndex);
        for(int i = 0; i < words.Length; i++) 
        {
            if (i < categoryLength)
            {
                buttonsParent.GetChild(i + _buttonIndex).GetComponent<ButtonController>().word = words[i];
                j++;

                if (i >= 1) _buttonIndex++;

            }
            
        }

        
        if (j < categoryLength - 1)
        {
            for (int y = j; y < categoryLength; y++)
            {
             
                buttonsParent.GetChild(y + _buttonIndex).GetComponent<ButtonController>().word = "HUNGRY"; //  <--  FILLER WORDS GO HERE
                _buttonIndex++;
            }
        }

    
    }

    void CloseForm()
    {
        thoughtCanvas.SetActive(false);
        playerController.canPlayerMove = true;
        
    }
}
