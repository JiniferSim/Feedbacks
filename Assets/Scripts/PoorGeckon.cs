using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoorGeckon : MonoBehaviour
{
    public Animator animator;
    private Vector3 moveDirection;
    public float moveSpeed = 5f;
    private bool isDead = false;
    public float changeDirectionInterval = 3f; // Interval to change direction

    private float timer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Run");
        if (!isDead)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            if (timer >= changeDirectionInterval)
            {
                timer = 0.1f;
                ChangeDirection();
            }
        }
    }
    void OnCollisionEnter (Collision collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Hit");
            animator.SetTrigger("Die");
            isDead = true;
        }
    }
    void ChangeDirection()
    {
        moveDirection = Random.insideUnitSphere;
        moveDirection.y = 0f; // Ensure movement is in the horizontal plane
        moveDirection.Normalize();
    }
}
