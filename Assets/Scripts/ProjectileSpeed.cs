using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : MonoBehaviour
{
    // Speed of the projectile
    public float speed = 10f;

  

    void Start()
    {
       
    }

    void Update()
    {
        // Move the projectile forward in its local direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

  
}
