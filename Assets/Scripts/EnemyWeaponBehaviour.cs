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
        if(_timer >= _cooldownTimer)
        {
            _timer -= _cooldownTimer;
            RaycastHit hit;
            Physics.Raycast(transform.position, PlayerController.Instance.transform.position - transform.forward, out hit);
            if (hit.transform.tag != "Player") return;
            FireWeapon(hit);
            
        }
    }
}
