using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour
{
    private bool _isDead = false;

    public override void Die()
    {
        transform.Rotate(-75f, 0, 0);
        _isDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead) return;

        RaycastHit hit;
        Vector3 toPlayer = PlayerController.Instance.transform.position - transform.position;
        Physics.Raycast(transform.position, toPlayer, out hit);
        if (hit.transform.tag != "Player") return;
        transform.LookAt(PlayerController.Instance.transform);
    }

    public bool IsDead()
    {
        return _isDead;
    }
}
