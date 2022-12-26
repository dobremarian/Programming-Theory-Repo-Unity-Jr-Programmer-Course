using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int playerHealth = 10;
    private GameObject thePlayer;
   
    void Start()
    {
        instance = this;

        thePlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            Destroy(thePlayer);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
    }
}
