using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int nOBullets; //number of bullets that the enemy fires each wave
    protected float bRate; //the rate at wich each bullet is instantiated
    protected float bSpeed; //the speed of the bullet
    protected float wTime; //the time between waves of shooting

    private Transform firePoint;
    private GameObject bullet;
    private bool isInPosition;
    private bool isAlive;

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }
    public GameObject Bullet
    {
        get { return bullet; }
    }
    public bool IsInPosition
    {
        get { return isInPosition; }
        set { isInPosition = value; }
    }
    protected virtual void Awake()
    {
        bullet = Resources.Load<GameObject>("Bullet");
        firePoint = gameObject.transform.Find("Point To Fire From").GetComponent<Transform>();
    
    }

    // Update is called once per frame
    protected virtual void Update()
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

    protected virtual IEnumerator ShootingCo()
    {
        return null;
    }
}
