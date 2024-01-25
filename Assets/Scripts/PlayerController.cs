using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Vector2 _moveDirection;
    Rigidbody2D _rigidBody;

    Vector2 _lookRight = new Vector2(1, 1);
    Vector2 _lookLeft = new Vector2(-1, 1);

    public delegate void PlayerAction();
    public static event PlayerAction OnPlayerPressButton;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
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

    


}
