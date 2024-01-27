using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormToButtons : MonoBehaviour
{
    public static FormToButtons Instance { get; private set; }

    public GameObject thoughtCanvas;
    public TMP_InputField inputField;
    private PlayerController playerController;
    private Transform buttonsParent;
    public GameObject speechBubbleParent;
    public TMP_Text speechBubbleText;

    public string[] promptText;
    public AudioClip[] promptAudio;

    AudioSource _promptAudioSource;
    TextMeshProUGUI responseText;
    List<string> allWordList = new List<string>();

    private string _inputText;
    private int _formCounter;
    private int _buttonIndex;
    private int categoryLength = 5;

    public string inputPhraseOne;
    public string inputPhraseTwo;
    public string inputPhraseThree;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //thoughtCanvas = GameObject.Find("DogThoughtCanvas");
        print(thoughtCanvas);
        //inputField = thoughtCanvas.transform.Find("InputField").GetComponent<TMP_InputField>();
        playerController = GameObject.Find("Dog").GetComponent<PlayerController>();
        buttonsParent = GameObject.Find("Buttons").transform;
        _promptAudioSource = GetComponent<AudioSource>();
        responseText = GameObject.Find("Canvas").transform.Find("Response").GetComponent<TextMeshProUGUI>();

    }

    public void AddToInputText(string s)
    {
        //_inputText = s;
    }

    public void GenerateWords()//called every time Player presses Submit
    {
        _inputText = inputField.text;
        _inputText = _inputText.Trim(); // remove leading and trailing whitespace
        string[] words = _inputText.Split(' ');

        if (words.Length != categoryLength) // If word input not right, rest form tell player
        {
            inputField.textComponent.text = "";
            inputField.text = "Please enter " + categoryLength + " words seperated by a space";
            _inputText = "";
            return;
        }

        _formCounter++;
        
        foreach(string word in words)
        {
            allWordList.Add(word);
        }

        if(_formCounter == 0)
        {
            inputField.textComponent.text = "";
            inputField.text = inputPhraseOne;
            _inputText = "";
        }
        else if (_formCounter == 1) // Adjectives
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
            allWordList.Add("Bunny");
            Shuffle(allWordList);
            PopulateButtons(allWordList);
            CloseForm();
        }
    }

    void Shuffle(List<string> s)
    {
        for (int i = 0; i < s.Count; i++)
        {
            string temp = s[i];
            int random = UnityEngine.Random.Range(i, s.Count);
            s[i] = s[random];
            s[random] = temp;
        }
    }

    // Populate buttons with word list
    void PopulateButtons(List<string> words)
    {
        foreach (string word in words)
        {
            buttonsParent.GetChild(_buttonIndex).GetComponent<ButtonController>().word = word;        
            _buttonIndex++;
        }
    }

    void CloseForm()
    {
        Debug.Log("Closing form");
        thoughtCanvas.SetActive(false);
        int value = UnityEngine.Random.Range(0, promptText.Length);

        speechBubbleText.text = promptText[value];
        _promptAudioSource.clip = promptAudio[value];
        _promptAudioSource.Play();
        speechBubbleParent.SetActive(true);
        playerController.canPlayerMove = true;
    }

    public void ResetForm()//called when asked to enter new prompts
    {
        inputField.textComponent.text = "";
        inputField.text = inputPhraseOne;
        _inputText = "";

        _formCounter = 0;
        _buttonIndex = 0;
        allWordList.Clear();
        thoughtCanvas.SetActive(true);
        speechBubbleParent.SetActive(false);
        responseText.text = "";
    }
}
