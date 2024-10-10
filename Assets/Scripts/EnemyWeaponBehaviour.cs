using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponBehaviour : WeaponBehaviour
{
    [SerializeField] private float _cooldownTimer;
    private float _timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        RaycastHit hit;
        Vector3 toPlayer = PlayerController.Instance.transform.position - transform.position;
        Physics.Raycast(transform.position, toPlayer, out hit);
        if (hit.transform.tag != "Player") return;

        if (_timer >= _cooldownTimer)
        {
            _timer -= _cooldownTimer;

            Physics.Raycast(transform.position, transform.forward, out hit);
            FireWeapon(hit);
        }
    }
}
