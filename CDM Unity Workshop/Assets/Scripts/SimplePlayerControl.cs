using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerControl : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;

    private Vector3 _input;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the old input system (WASD or Arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        _input = new Vector3(moveHorizontal, 0, moveVertical);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Move the player in the input direction
        _rb.MovePosition(transform.position + _input * _speed * Time.deltaTime);
    }
}
