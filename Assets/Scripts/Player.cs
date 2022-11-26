using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xLimit = 125f;
    private float moveSpeed = 300f;
    private Rigidbody playerRb;
    private Transform pointToFireFrom;
    [SerializeField] GameObject bullet;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        pointToFireFrom = GameObject.Find("Point To Fire From").GetComponent<Transform>();
    }

    void Update()
    {
        FireBullet();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(gameObject.transform.position.x <= -xLimit)
        {
            gameObject.transform.position = new Vector3(-xLimit, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if(gameObject.transform.position.x >= xLimit)
        {
            gameObject.transform.position = new Vector3(xLimit, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

    }

    void FireBullet()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, pointToFireFrom.position, bullet.transform.rotation);
        }
    }
}
