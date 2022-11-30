using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpaceshipPrefabs;
    [SerializeField] float moveShipsTime = 1.1f;
    [SerializeField] List<GameObject> activeEnemies;
    private Player thePlayer;
    private int maxEnemies = 5;
    private float moveShipsSpeed = 20f;
    private Transform spawnOrigin;
    private float xDistanceBetweenShips = 60f;
    private float zToMove = 60f;
    private bool isInPosition = false;

    void Start()
    {
        spawnOrigin = GameObject.Find("Spawn Origin").GetComponent<Transform>();
        thePlayer = GameObject.Find("Player").GetComponent<Player>();
        SpawnWave();
    }


    void Update()
    {

        if (!isInPosition)
        {
            StartCoroutine(MoveShipsInPositionCo());
        }
        else
        {
            thePlayer.CanFire = true;
        }

    }


    void SpawnWave()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            int rand = Random.Range(0, enemySpaceshipPrefabs.Count);
            Vector3 pos = new Vector3(spawnOrigin.position.x + i * xDistanceBetweenShips, spawnOrigin.position.y, spawnOrigin.position.z);
            GameObject temp = Instantiate(enemySpaceshipPrefabs[rand], pos, enemySpaceshipPrefabs[rand].transform.rotation);
            activeEnemies.Add(temp);
        }

        isInPosition = false;
    }

    IEnumerator MoveShipsInPositionCo()
    {
        yield return new WaitForSeconds(moveShipsTime);
        float step = moveShipsSpeed * Time.deltaTime;

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            Vector3 targetPosition = new Vector3(activeEnemies[i].transform.position.x, activeEnemies[i].transform.position.y, zToMove);
            activeEnemies[i].transform.position = Vector3.MoveTowards(activeEnemies[i].transform.position, targetPosition, step);
            if (activeEnemies[i].transform.position.z == zToMove)
            {
                isInPosition = true;
            }
            else
            {
                isInPosition = false;
            }
        }

    }
}
