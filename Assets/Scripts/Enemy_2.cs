using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    //enemy 2 starts shooting two bullets
    //after each shot, the angle gets wider until it reaches the amount of shots needed to be fired

    private float yRotationAmount = 7;
    private float xBulletsDistance = 5;
    private float yDefaultRotation = 1;
    private float zPlayer;

    protected override void Awake()
    {
        base.Awake();
        numberOfBullets = 2;
        bulletRate = 0.3f;
        bulletSpeed = 100f;
        waveTime = 3f;
        fireTime = 1.8f;
        isCoActive = false;

        zPlayer = GameObject.Find("Player").GetComponent<Transform>().transform.position.z;
    }
    protected override void Update()
    {
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
        float yRot = yDefaultRotation;
        float positiveAngle;

        if (!isCoActive)
        {
            while (IsAlive && IsInPosition)
            {
                yield return new WaitForSeconds(0.1f);

                while (fTime > 0)
                {
                    float xPos;
                    //this is the enemy 1 attack
                    //we'll probably do a for loop for the number of bullets and then add the rotation
                    //the rotation will be positive for one and negative for the other
                    //the position of the bullet will be slighly moved to the left and right, depending of the angle
                   
                    
                    yield return new WaitForSeconds(bulletRate);
                    for (int i = 0; i < numberOfBullets; i++)
                    {
                        if(i % 2 == 0)
                        {
                            xPos = FirePoint.position.x - xBulletsDistance;
                            positiveAngle = -1;
                        }
                        else
                        {
                            xPos = FirePoint.position.x + xBulletsDistance;
                            positiveAngle = 1;
                        }
                        Vector3 pos = new Vector3(xPos, FirePoint.position.y, FirePoint.position.z);
                        GameObject bulletInstance = Instantiate(Bullet, pos, Bullet.transform.rotation);
                        bulletInstance.transform.Rotate(Vector3.forward * yRot * positiveAngle, Space.Self);
                        var direction = BulletDirection(yRot, positiveAngle);
                        bulletInstance.GetComponent<Bullet>().BulletDirection = direction * 0.1f;
                        bulletInstance.GetComponent<Bullet>().BulletSpeed = bulletSpeed;
                    }
                    

                    /*
                    yield return new WaitForSeconds(bulletRate);
                    GameObject bulletInstance = Instantiate(Bullet, FirePoint.position, Bullet.transform.rotation);
                    bulletInstance.GetComponent<Bullet>().BulletDirection = Vector3.back;
                    bulletInstance.GetComponent<Bullet>().BulletSpeed = bulletSpeed;*/

                    fTime -= bRate;
                    yRot += yRotationAmount;


                }
                fTime = fireTime * 10;
                yRot = yDefaultRotation;
                yield return new WaitForSeconds(waveTime - fireTime);
            }
        }
        yield break;
    }

    Vector3 BulletDirection(float angle, float positive)
    {
        return new Vector3(-angle * -positive, 0, zPlayer);
    }

}
