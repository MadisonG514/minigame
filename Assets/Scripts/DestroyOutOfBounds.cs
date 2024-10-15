using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 13;
    private float lowerBound = -13;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If object goes past player view in game, remove that object
         if (transform.position.z > topBound)
        {
            Destroy(gameObject); 
        }   else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject); 
        }
    }
}