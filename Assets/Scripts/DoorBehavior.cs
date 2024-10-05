using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public Color DoorColor;
    [SerializeField] private bool _playerInRange;
    [SerializeField] private KeyBehaviour _keyForDoor;
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = DoorColor;
        _keyForDoor.GetComponent<MeshRenderer>().material.color = DoorColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            foreach (KeyBehaviour key in PlayerController.Instance.KeysCollected) {
                if (key == _keyForDoor) {
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = false;
    }
}
