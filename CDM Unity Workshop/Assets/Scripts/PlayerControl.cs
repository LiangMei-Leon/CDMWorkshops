using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _inputVector;
    private Vector3 _input;
    private GameControl _inputActions;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _inputActions = new GameControl();
        // Bind the movement action
        _inputActions.Player.Move.performed += ctx => _inputVector = ctx.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += ctx => _inputVector = Vector2.zero;
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        _input = new Vector3(_inputVector.x, 0, _inputVector.y);

        // Calculate the direction to look at based on input
        // Quaternion targetRotation = Quaternion.LookRotation(_input, Vector3.up);

        // Smoothly rotate the character toward the input direction
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _rb.MovePosition(transform.position + _input * _speed * Time.deltaTime);
    }
}
