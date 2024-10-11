using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject _enemyCapsule;
    private Rigidbody _rigidbody;

    private EnemyBehaviour _enemyBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    void FixedUpdate() {

        if (_enemyBehaviour != null && _enemyBehaviour.IsDead()) {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        _rigidbody.velocity = transform.forward * _movementSpeed;
    }
   
    private void OnCollisionEnter(Collision collision) {

        Quaternion targetRotation = Quaternion.Euler(0f, 45f, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * targetRotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
