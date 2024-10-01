using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
            movementDirection += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.A))
            movementDirection += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.S))
            movementDirection += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.D))
            movementDirection += Vector3.right;

        Debug.Log(transform.forward);
        transform.position +=
            (movementDirection.z * transform.forward +
            movementDirection.x * transform.right) *
            _movementSpeed * Time.deltaTime;
        //transform.position += movementDirection * _movementSpeed * Time.deltaTime;
    }
    private void Update()
    {
        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Mouse X");
        transform.Rotate(rotation * Time.deltaTime * _rotationSpeed);
    }
}
