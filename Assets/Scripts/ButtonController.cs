using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private GameObject text;
    private Animator animator;
    private TextToSpeech textToSpeech;


    public string word;
    private bool _playerNearButton;

    private void OnEnable()
    {
        PlayerController.OnPlayerPressButton += ButtonPressed;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerPressButton -= ButtonPressed;
    }
    private void Awake()
    {
        text = transform.Find("Text").gameObject;
        textToSpeech = GetComponent<TextToSpeech>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Dog")
        {
            text.SetActive(true);
            _playerNearButton = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Dog")
        {
            text.SetActive(false);
            _playerNearButton = false;
        }
    }

    void ButtonPressed()
    {
        if (!_playerNearButton) return;

        print("pressed");
        animator.SetTrigger("pressed");
        textToSpeech.ReadText(word);
    }

}
