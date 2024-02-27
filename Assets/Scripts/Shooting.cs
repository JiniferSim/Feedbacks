using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float shootingSpeed;
    [SerializeField] float shootingRate;
    [SerializeField] float shootingDistanceMax;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            Shoot(); 
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.position += transform.forward * shootingSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
