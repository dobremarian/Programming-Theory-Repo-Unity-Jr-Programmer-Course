using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float zBound = 120f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(gameObject.transform.position.z >= zBound)
        {
            Destroy(gameObject);
        }
    }
}
