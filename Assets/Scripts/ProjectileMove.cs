using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;

    void Start()
    {
        Debug.Log(transform.forward);
    }

    void Update()
    {
        if(speed != 0) 
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}
