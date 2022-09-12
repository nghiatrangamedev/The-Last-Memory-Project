using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _playerObject; 

    float _mouseX;
    float _mouseY;
    float _mouseSpeed = 100f;
    float _xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _mouseSpeed * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _mouseSpeed * Time.deltaTime;

        if (_mouseX != 0)
        {
            _playerObject.transform.Rotate(Vector3.up * _mouseX);
        }

        if (_mouseY != 0)
        {
            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -45, 45);
            transform.localRotation = Quaternion.Euler(_xRotation, transform.localRotation.y, transform.localRotation.z);
        }
    }
}
