using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _rotationSensitivity;
    [SerializeField] private float _minVerticalRotation, _maxVerticalRotation;
    [SerializeField] private GameObject _playerCapsule;
    private Vector3 _horizontalRotation, _verticalRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * _rotationSensitivity;
        _verticalRotation.x += -Input.GetAxis("Mouse Y") * Time.deltaTime * _rotationSensitivity;
        _verticalRotation.x = Mathf.Clamp(_verticalRotation.x, _minVerticalRotation, _maxVerticalRotation);

        _playerCapsule.transform.eulerAngles = _horizontalRotation;
        transform.eulerAngles = new Vector3(_verticalRotation.x, transform.eulerAngles.y);
    }
}
