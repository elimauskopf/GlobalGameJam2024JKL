using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool canPlayerMove = false;
    public GameObject poop;
    public Transform buttPosition;
    public AudioClip fart;
    public AudioClip walk;

    Vector2 _moveDirection;
    Rigidbody2D _rigidBody;
    AudioSource _dogSounds;
    AudioSource _buttSounds;

    Vector2 _lookRight = new Vector2(1, 1);
    Vector2 _lookLeft = new Vector2(-1, 1);

    public delegate void PlayerAction();
    public static event PlayerAction OnPlayerPressButton;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _dogSounds = GetComponent<AudioSource>();
        _buttSounds = transform.GetChild(0).GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!canPlayerMove) return;

        //Debug.Log("Registering on move, direction = " + context.ReadValue<Vector2>());
        _moveDirection = context.ReadValue<Vector2>();
        if (_moveDirection.x < 0)
        {
            transform.localScale = _lookLeft;
        }
        else if (_moveDirection.x > 0)
        {
            transform.localScale = _lookRight;
        }
    }

    // When player press E invoke button pressed event
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed) OnPlayerPressButton?.Invoke();

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Instantiate(poop, buttPosition.position, Quaternion.identity);
            _buttSounds.Play();
        }
        
    }

    


}
