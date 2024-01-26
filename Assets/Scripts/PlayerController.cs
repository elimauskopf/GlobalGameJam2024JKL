using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public float speed;
    public int foodUntilPoop;
    public bool canPlayerMove = false;
    public GameObject poop;
    public Transform buttPosition;
    public AudioClip fart;
    public AudioClip walk;

    Vector2 _moveDirection;
    Rigidbody2D _rigidBody;
    AudioSource _dogSounds;
    AudioSource _buttSounds;
    Animator _animator;

    Vector2 _lookRight = new Vector2(1, 1);
    Vector2 _lookLeft = new Vector2(-1, 1);

    public delegate void PlayerAction();
    public static event PlayerAction OnPlayerPressButton;

    bool _isMoving;
    int _currentFoodValue;

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

        _rigidBody = GetComponent<Rigidbody2D>();
        _dogSounds = GetComponent<AudioSource>();
        _buttSounds = transform.GetChild(0).GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
        UpdateAnimation();
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

    void UpdateAnimation()
    {
        if(_rigidBody.velocity.magnitude > 0.1)
        {
            _animator.SetBool("Moving", true);
            _isMoving = true;
        }
        else
        {
            _animator.SetBool("Moving", false);
            _isMoving = false;
        }
        AssignWalkingAudio();
    }

    void AssignWalkingAudio()
    {
        if(_isMoving && !_dogSounds.isPlaying)
        {
            _dogSounds.Play();
        }
        else if(!_isMoving && _dogSounds.isPlaying)
        {
            _dogSounds.Pause();
        }
    }

    public void EatFood()
    {
        if(_currentFoodValue >= foodUntilPoop)
        {
            return;
        }
        _currentFoodValue += 1;     
    }
}
