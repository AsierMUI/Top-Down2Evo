using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    float health, maxHealth = 1f;


    public float detectionRange = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }
    private void Update()
    {
        if (target)

        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
