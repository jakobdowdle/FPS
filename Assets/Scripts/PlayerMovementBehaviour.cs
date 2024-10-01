using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) input += Vector3.left;
        if (Input.GetKey(KeyCode.D)) input += Vector3.right;
        if (Input.GetKey(KeyCode.W)) input += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) input += Vector3.back;
        Vector3 velocity =
            (transform.forward * input.z +
            transform.right * input.x) * _movementSpeed;
        transform.position += velocity * Time.deltaTime;
    }
    private void Update()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotation * _rotationSpeed);
    }
}
