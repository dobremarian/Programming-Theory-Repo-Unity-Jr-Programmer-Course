using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{   //enemy 1 will start to move left to right and shoot

    private float xPosRange = 120f;
    private float moveSpeed = 50f;
    private bool isRight = false;

    protected override void Awake()
    {
        base.Awake();
        numberOfBullets = 1;
        bulletRate = 0.2f;
        bulletSpeed = 300f;
        waveTime = 2f;
        fireTime = 1f;
        isCoActive = false;
    }

    protected override void Update()
    {
        MoveEnemyShip();
        if (IsAlive && IsInPosition)
        {
            StartCoroutine(EnemyAttackCo());
            isCoActive = true;

        }
    }

    protected override IEnumerator EnemyAttackCo()
    {
        float fTime = fireTime * 10;
        float bRate = bulletRate * 10;

        if (!isCoActive)
        {
            while (IsAlive && IsInPosition)
            {
                yield return new WaitForSeconds(waveTime - fireTime);

                while (fTime > 0)
                {
                    
                    yield return new WaitForSeconds(bulletRate);
                    GameObject bulletInstance = Instantiate(Bullet, FirePoint.position, Bullet.transform.rotation);
                    bulletInstance.GetComponent<Bullet>().BulletDirection = Vector3.back;
                    bulletInstance.GetComponent<Bullet>().BulletSpeed = bulletSpeed;

                    fTime -= bRate;
                    

                }
                fTime = fireTime * 10;
            }
        }
        yield break;
    }

    void MoveEnemyShip()
    {
        float step = moveSpeed * Time.deltaTime;

        if (IsInPosition)
        {
            Vector3 targetPos;
            if (isRight)
            {
                targetPos = new Vector3(-xPosRange, gameObject.transform.position.y, gameObject.transform.position.z);

            }
            else
            {
                targetPos = new Vector3(xPosRange, gameObject.transform.position.y, gameObject.transform.position.z);

            }

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, step);

            if (gameObject.transform.position.x == xPosRange)
            {
                isRight = true;
            }
            else if (gameObject.transform.position.x == -xPosRange)
            {
                isRight = false;
            }
        }
    }
}
