using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void Start()
    {
        
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EndPoint")
        {
            Debug.Log("Hurray! You made it to the end!");
        }
        
    }
    private void Update()
    {
        
    }
}
