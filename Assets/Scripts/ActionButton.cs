using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class ActionButton : MonoBehaviour
{
    public bool resetButton;
    public bool finishButton;
    public bool newWordsButton;
    public TMP_Text speechBubbleText;
    private TextToSpeech textToSpeech;

    private bool _isHumanResponding;
    float humanReponseTime = 2;

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

    IEnumerator HumanResponse()
    {
        
        print("RESPONDING");
        _isHumanResponding = true;
        string oldText = speechBubbleText.text;
        speechBubbleText.text = "Nice one Bunny";

        yield return new WaitForSeconds(humanReponseTime);

        speechBubbleText.text = oldText;
        _isHumanResponding = false;


    }

    public void FinishInput()
    {
        if(textToSpeech != null && !_isHumanResponding)
        {
            textToSpeech.ReadText(responseText.text);
        }

        if (!_isHumanResponding) StartCoroutine(HumanResponse());

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
