using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int nOBullets; //number of bullets that the enemy fires each wave
    private float bRate; //the rate at wich each bullet is instantiated
    private float bSpeed; //the speed of the bullet
    private float wTime; //the time between waves of shooting
    private bool isAlive;
    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }
    private GameObject bullet;
    public GameObject Bullet
    {
        get { return bullet; }
    }
    void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        //at the moment we created a basic parent enemy scrips
        //we'll make a coroutine Shooting(number of bullets, bullet rate, bullet speed, time before fireing another bullet wave,
        // potentially rows of bullets or just tranform the rotation of the bullet when is instantiated)
        //we'll overload it so each child enemy scrips has a different type of shooting
        //potentially we'll add a variable inPosition so that after a ship dies a new one is created and is added
        //and moves in position

        //we'll probably have to rethink the way we made our game. there is no point in doing inheritance since nothing is different from each enemy.
        //one idea is to spawn an enemy ship at a time and have each do a different thing
        //one can move one way, one can move a different way, one can shoot something else besides a bullet
        //one can just move towards the player and try to crash into him
    }

    protected virtual IEnumerator ShootingCo(int numberOfBullets, float bulletRate, float bulletSpeed, float waveTime)
    {
        return null;
    }
}
