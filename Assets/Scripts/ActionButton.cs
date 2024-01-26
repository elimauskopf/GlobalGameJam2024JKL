using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActionButton : MonoBehaviour
{
    public bool resetButton;
    public bool finishButton;
    public bool newWordsButton;
    private TextToSpeech textToSpeech;

    [SerializeField]
    GameObject inputTextObject;

    TextMeshProUGUI responseText;
    GameObject pressE;

    private bool _playerNearButton;

    private void Awake()
    {
        pressE = transform.GetChild(1).gameObject;
        pressE.SetActive(false);
        responseText = GameObject.Find("Canvas").transform.Find("Response").GetComponent<TextMeshProUGUI>();
        textToSpeech = GetComponent<TextToSpeech>();
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerPressButton += ButtonPressed;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerPressButton -= ButtonPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dog")
        {
            pressE.SetActive(true);
            _playerNearButton = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Dog")
        {
            pressE.SetActive(false);
            _playerNearButton = false;
        }
    }

    void ButtonPressed()
    {
        if (!_playerNearButton) return;

        if(resetButton)
        {
            ResetWords();
        }
        else if(finishButton)
        {
            FinishInput();
        }
        else if(newWordsButton)
        {
            NewWords();
        }
        //animator.SetTrigger("pressed");
    }
    public void ResetWords()
    {
        responseText.text = "";
    }

    public void FinishInput()
    {
        if(textToSpeech != null)
        {
            textToSpeech.ReadText(responseText.text);
        }
        //wait until done reading
        //human responds
        //new day
        //move on to new prompt
    }

    public void NewWords()
    {
        if (inputTextObject.activeSelf)
        {
            return;
        }
        FormToButtons.Instance.ResetForm();
    }
}
