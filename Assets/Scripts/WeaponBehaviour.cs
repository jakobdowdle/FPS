using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;

    public void FireWeapon(RaycastHit hit)
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        GetComponent<AudioSource>().Play();
        projectile.transform.position = hit.point;
        projectile.transform.parent = hit.transform;
        if (hit.transform.tag == "Enemy" || hit.transform.tag == "Player")
        {
            CharacterBehavior character = hit.transform.GetComponent<CharacterBehavior>();
            Debug.Log("omar");
            character.Hit();
        }
    }
}
