using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : Enemy
{
    //Enemy 3 will not shoot bullets but instead it will follow the player unitil it reaches a certin point and them just go out of the scene

    float zMaxPoint = -20f;
    float moveSpeed = 100f;
    Transform thePlayer;
    Vector3 lastPlayerPos;
    private SpawnManager spawnManager;

    protected override void Awake()
    {
        isCoActive = false;
        waveTime = .5f;
        thePlayer = GameObject.Find("Player").GetComponent<Transform>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }
    protected override void Update()
    {
        if (IsAlive && IsInPosition)
        {
            StartCoroutine(EnemyAttackCo());
            isCoActive = true;
        }

        if(transform.position.z < -120f)
        {
            Destroy(gameObject);
            spawnManager.IsInPosition = false;
        }
    }
    protected override IEnumerator EnemyAttackCo()
    {
        float step = moveSpeed * Time.deltaTime;

        yield return new WaitForSeconds(waveTime);
        if(gameObject.transform.position.z > zMaxPoint)
        {
            transform.LookAt(thePlayer);
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.position, step);
            lastPlayerPos = thePlayer.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, lastPlayerPos * 10, 2 * step);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerTakeDamage(2);
            Destroy(gameObject);
            spawnManager.IsInPosition = false;
        }
    }
}
