using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRb;
    private float bulletSpeed = 300f;
    private Vector3 bulletDirection;
    private SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set
        {
            if (value < 100f)
            { bulletSpeed = 100f; }
            else { bulletSpeed = value; }
        }
    }
    public Vector3 BulletDirection
    {
        get { return bulletDirection; }
        set { bulletDirection = value; }
    }
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); //for the moment it will destroy the enemy but we'll make it take some damage before the enemy is destroyed
            Destroy(gameObject);
            spawnManager.IsInPosition = false;

        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerTakeDamage(1);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //At the moment it works for the player spaceship. There will be changes to be used by the enemy and use vector3.back
        MoveForward();
    }


    void MoveForward()
    {
        bulletRb.AddForce(bulletDirection * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
