using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormToButtons : MonoBehaviour
{
    public GameObject thoughtCanvas;
    public TMP_InputField inputField;
    private PlayerController playerController;
    private Transform buttonsParent;
    public GameObject speechBubble;

    private string _inputText;
    private int _formCounter;
    private int _buttonIndex;
    private int categoryLength = 5;

    public string inputPhraseOne;
    public string inputPhraseTwo;
    public string inputPhraseThree;



    private void Awake()
    {
        //thoughtCanvas = GameObject.Find("DogThoughtCanvas");
        print(thoughtCanvas);
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

        _inputText = _inputText.Trim(); // remove leading and trailing whitespace
        string[] words = _inputText.Split(' ');

        if (words.Length != categoryLength) // If word input not right, rest form tell player
        {
            inputField.textComponent.text = "";
            inputField.text = "Please enter " + categoryLength + " words seperated by a space";
            _inputText = "";
            return;
        }

      
        Shuffle(words);

        PopulateButtons(words);

        _formCounter++;

        if (_formCounter == 1) // Adjectives
        {
            //categoryLength = 5;
            inputField.textComponent.text = "";
            inputField.text = inputPhraseTwo;
            _inputText = "";

        }
        else if (_formCounter == 2) // VERBS
        {
            //categoryLength = 4;
            inputField.textComponent.text = "";
            inputField.text = inputPhraseThree;
            _inputText = "";

        }
        else
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

    // Populate buttons with word list
    void PopulateButtons(string[] words)
    { 
        foreach (string word in words)
        {
            buttonsParent.GetChild(_buttonIndex).GetComponent<ButtonController>().word = word;        
            _buttonIndex++;
        }
    }

    void CloseForm()
    {
        thoughtCanvas.SetActive(false);
        speechBubble.SetActive(true);  // SET SPEECH BUBBLE TEXT HERE
        playerController.canPlayerMove = true;

    }
}
