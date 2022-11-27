using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpaceshipPrefabs;
    public List<GameObject> activeEnemies;
    private int maxEnemies = 5;
    private float moveShipsSpeed = 20f;
    private Transform spawnOrigin;
    private float xDistanceBetweenShips = 60f;
    private float zToMove = 60f;
    private bool isMoved = false;

    void Start()
    {
        spawnOrigin = GameObject.Find("Spawn Origin").GetComponent<Transform>();
        SpawnWave();
    }

    
    void Update()
    {
        /*
        if(!isMoved)
        {
            MoveShipsInPosition();
            isMoved = true;
        }*/

        MoveShipsInPosition();
    }

    void SpawnWave()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
            int rand = Random.Range(0, enemySpaceshipPrefabs.Count);
            Vector3 pos = new Vector3(spawnOrigin.position.x + i * xDistanceBetweenShips, spawnOrigin.position.y, spawnOrigin.position.z);
            GameObject temp = Instantiate(enemySpaceshipPrefabs[rand], pos, enemySpaceshipPrefabs[rand].transform.rotation);
            activeEnemies.Add(temp);
        }

        isMoved = false;
    }

    void MoveShipsInPosition()
    {
        float step = moveShipsSpeed * Time.deltaTime;

        for(int i = 0; i < activeEnemies.Count; i++)
        {
            Vector3 targetPosition = new Vector3(activeEnemies[i].transform.position.x, activeEnemies[i].transform.position.y, zToMove);
            activeEnemies[i].transform.position = Vector3.MoveTowards(activeEnemies[i].transform.position, targetPosition, step);
        }
    }
}
