using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool _playerOne = true;

    [SerializeField]
    private float _acceleration = 10.0f;

    [SerializeField]
    private float _maxSpeed = 20.0f;

    [SerializeField]
    private float _jumpPower = 10.0f;

    private Rigidbody _rigidbody;
    private float _moveInput;

    public bool IsPlayerOne { get { return _playerOne; } }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_playerOne)
        {
            _moveInput = Input.GetAxisRaw("Player1Horizontal");
            if (Input.GetKeyDown(KeyCode.W))
                Jump();
        }
        else
        {
            _moveInput = Input.GetAxisRaw("Player2Horizontal");
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Jump();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = new Vector3();
        deltaMovement.x = _moveInput * _acceleration;
        _rigidbody.AddForce(deltaMovement * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 newVelocity = _rigidbody.velocity;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -_maxSpeed, _maxSpeed);
        _rigidbody.velocity = newVelocity;
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }
}
