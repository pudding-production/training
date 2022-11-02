using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] float attackRange = 0.5f;
    [SerializeField] int attackDamage = 5;
    Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("MeleeAttack");
        }    
    }

    public void MeleeAttack()
    {
        //Find nearby enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage, transform.localScale.x);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
