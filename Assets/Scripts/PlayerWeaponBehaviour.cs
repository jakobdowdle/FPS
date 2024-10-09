using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerWeaponBehaviour : WeaponBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                FireWeapon(hit);
            }
        }
    }

    
}
