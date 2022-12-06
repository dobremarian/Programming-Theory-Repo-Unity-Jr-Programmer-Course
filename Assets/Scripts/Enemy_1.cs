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
        nOBullets = 1;
        bRate = 0.2f;
        bSpeed = 300f;
        wTime = 2f;
    }
    
    protected override void Update()
    {
        MoveEnemyShip();
    }

    protected override IEnumerator ShootingCo()
    {
        return null;
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

            if(gameObject.transform.position.x == xPosRange)
            {
                isRight = true;
            }
            else if(gameObject.transform.position.x == -xPosRange)
            {
                isRight = false;
            }
        }
    }
}
