using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponBehaviour : WeaponBehaviour
{
    [SerializeField] private float _cooldownTimer;
    private float _timer;

    private EnemyBehaviour _enemyBehaviour;

    void Start()
    {
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_enemyBehaviour != null && _enemyBehaviour.IsDead()) return;
            _timer += Time.deltaTime;
        RaycastHit hit;
        Vector3 toPlayer = PlayerController.Instance.transform.position - transform.position;
        Physics.Raycast(transform.position, toPlayer, out hit);
        if (hit.transform.tag != "Player") return;
        transform.LookAt(PlayerController.Instance.transform);
        if (_timer >= _cooldownTimer)
        {
            _timer = 0;

            Physics.Raycast(transform.position, transform.forward, out hit);
            FireWeapon(hit);
        }
    }
}
