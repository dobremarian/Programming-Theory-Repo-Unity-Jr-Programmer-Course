using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    private Rigidbody bulletRb;
    private float bulletSpeed = 300f;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        //At the moment it works for the player spaceship. There will be changes to be used by the enemy and use vector3.back
        MoveForward(Vector3.forward);
    }

    void MoveForward(Vector3 direction)
    {
        bulletRb.AddForce(direction * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
