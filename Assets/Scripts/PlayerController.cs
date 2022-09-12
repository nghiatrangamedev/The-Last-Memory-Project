using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _characterController;
    Vector3 _moveDirection;
    float _horizontalInput;
    float _verticalInput;
    float _movementSpeed = 5f;

    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundMask;
    float _groundDistance = 0.1f;
    bool _isGrounded;

    Vector3 _gravity;
    float _gravitySpeed = 9f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Gravity();
    }

    void Movement()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _moveDirection = transform.right * _horizontalInput + transform.forward * _verticalInput ;

        _characterController.Move(_moveDirection * _movementSpeed * Time.deltaTime);
    }

    void Gravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        
        if (_isGrounded)
        {
            _gravity.y = -2;
        }

        else
        {
            _gravity.y -= _gravitySpeed;
        }

        _characterController.Move(_gravity * Time.deltaTime * Time.deltaTime);
    }
}
