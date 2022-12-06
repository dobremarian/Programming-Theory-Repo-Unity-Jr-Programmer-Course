using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpaceshipPrefabs;
    [SerializeField] float moveShipTime = 1.1f;
    //[SerializeField] List<GameObject> activeEnemies;
    private GameObject enemyShip;
    private Player thePlayer;
    //private int maxEnemies = 5;
    private float moveShipSpeed = 20f;
    private float zPosSpawn = 110f;
    private float xRangeSpawn = 120f;
    //private Transform spawnOrigin;
    //private float xDistanceBetweenShips = 60f;
    private float zToMove = 60f;
    private bool isInPosition = false;

    public bool IsInPosition
    {
        get { return isInPosition; }
        set { isInPosition = value; }
    }

    void Start()
    {
        //spawnOrigin = GameObject.Find("Spawn Origin").GetComponent<Transform>();
        thePlayer = GameObject.Find("Player").GetComponent<Player>();
        //SpawnWave();
        //SpawnShip();
    }


    void Update()
    {
        if(enemyShip == null)
        {
            SpawnShip();
            thePlayer.CanFire = false;
        }
        else
        {
            if (!isInPosition)
            {
                //StartCoroutine(MoveShipsInPositionCo());
                StartCoroutine(MoveShipInPositionCo());
            }
            else
            {
                thePlayer.CanFire = true;
                if(enemyShip != null)
                {
                    enemyShip.GetComponent<Enemy>().IsInPosition = true;
                    //at the moment the error is because the other enemies dont have an enemy script on them
                }
            }
        }


    }

    void SpawnShip()
    {
        int rand = Random.Range(0, enemySpaceshipPrefabs.Count);
        float randX = Random.Range(-xRangeSpawn, xRangeSpawn);
        Vector3 pos = new Vector3(randX, 0, zPosSpawn);
        enemyShip = Instantiate(enemySpaceshipPrefabs[rand], pos, enemySpaceshipPrefabs[rand].transform.rotation);

    }

    IEnumerator MoveShipInPositionCo()
    {
        yield return new WaitForSeconds(moveShipTime);
        float step = moveShipSpeed * Time.deltaTime;
        if(enemyShip != null)
        {
            Vector3 targetPosition = new Vector3(enemyShip.transform.position.x, enemyShip.transform.position.y, zToMove);
            enemyShip.transform.position = Vector3.MoveTowards(enemyShip.transform.position, targetPosition, step);
            if (enemyShip.transform.position.z == zToMove)
            {
                isInPosition = true;
            }
            else
            {
                isInPosition = false;
            }
        }
        
    }

    /*
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
    }*/

    /*
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
    */
}
