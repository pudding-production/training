using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] int maxHealth = 100;
    [SerializeField] BoxCollider2D boxCollider2D;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount, float direction)
    {
        currentHealth -= amount;
        // Play hurt animation

        // Apply push
        rb.AddForce(new Vector2(250 * direction * amount, 250 * (amount / 2)));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(boxCollider2D);
    }
}
