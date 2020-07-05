using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float damageRadius;
    [SerializeField] private float startAttackRadius;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float minAttackInterval;
    [SerializeField] private float maxAttackInterval;
    private float nextAttackTime;

    [SerializeField] Animator an;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject uiM;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 2f;
        health = 400f;
        damage = 25f;
        nextAttackTime = Time.time + 1f;
        startAttackRadius = 3f;
        damageRadius = 2f;
        minAttackInterval = 1f;
        maxAttackInterval = 3f;
    }

    private void Hit(float damage)
    {
        health -= damage;
        if (health<=0)
        {
            uiM.SendMessage("Victory");
            an.SetTrigger("DeathTrigger");
            
        } else
        {
            // enable trigger gotHit

        }
    }

    private void FixedUpdate()
    {
        an.SetFloat("Y-Velocity", rb.velocity.y);
        //float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").GetComponent<Transform>().position, step);
    }

    private void Update()
    {
        if (nextAttackTime <= Time.time)
        {
            Attack();
        }
    }
    private void StartMoving()
    {
        // if y.velocity is zero
        if (rb.velocity.y != 0) return;
        // move slowly

        // only move if player is not within chaseRadius
    }

    private void Attack()
    {
        // updates nextAttackTime to be a random float between min and max interval
        nextAttackTime = Time.time + Random.Range(minAttackInterval, maxAttackInterval);
        // Guard Break that stops rest of code block if player is not within startAttack radius
        if (Physics2D.OverlapCircleAll(transform.position, startAttackRadius, 1 << 9).Length <= 0) return;

        // play animation when attacking (note: the damaging of nearby players is handled by a behavior script on animation)
        an.SetTrigger("AttackTrigger");

        
    }

    private void Damage()
    {
        // gets playerColliders within damageRadius
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius, 1 << 9);

        //
        foreach (Collider2D c in playerColliders)
        {
            c.gameObject.SendMessage("Hit", damage);
        }
    }
}
