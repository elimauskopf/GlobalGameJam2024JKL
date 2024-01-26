using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : MonoBehaviour
{
    bool _playerInRadius;
    GameObject _eToInteract;

    private void Awake()
    {
        _eToInteract = transform.GetChild(0).gameObject;
        _eToInteract.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.transform.CompareTag("Player"))
        {
            return;
        }
        _eToInteract.SetActive(true);
        _playerInRadius = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            return;
        }
        _eToInteract.SetActive(false);
        _playerInRadius = false;
    }

    void OnInteract()
    {
        if (_playerInRadius)
        {
            PlayerController.Instance.EatFood();
        }
    }
}
