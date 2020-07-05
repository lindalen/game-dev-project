using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] Animator an;
    [SerializeField] CoroutineHelper coHelp;
    [SerializeField] UIManager uiM;
    [SerializeField] float moveForce;
    [SerializeField] private float radius;
    [SerializeField] private float damage;
    [SerializeField] private float health;

    private float nextPunchTime;
    private float punchPause;
    private bool isDodging;
    private bool isDead;
    private float dodgeTime;
    
    //private PlayerCombat pCom;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        coHelp = GetComponent<CoroutineHelper>();
        uiM = GetComponent<UIManager>();
        //pCom = GetComponent<PlayerCombat>();
        punchPause = 0.1f;
        moveForce = 5f;
        radius = 1.2f;
        damage = 15f;
        health = 100f;
        isDodging = false;
        isDead = false;
        dodgeTime = 0.2f;
        nextPunchTime = Time.time + punchPause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextPunchTime < Time.time)
        {
            Punch();
        }
        /*if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Dodge!");
        }*/ // Scrapped due to time limitations
    }
    void FixedUpdate()
    {
        if (!isDead) Move();
    }

    private void Move()
    {
        // Reads whether the horizontal controls are pressed, -1 being left and +1 right. 
        float direction = Input.GetAxisRaw("Horizontal");
        an.SetFloat("Speed", Mathf.Abs(direction));
        // Flips character towards the left if the direction is towards the left.
        if (direction!=0) sp.flipX = direction > 0;
        // Multiplies the horizontal input value by a multiplier; movement is slow without it.
        float newVelocity = direction * moveForce;
        // Updates the velocity along the x-axis to the newly calculated value. 
        rb.velocity = new Vector2(newVelocity, rb.velocity.y);
    }

    private void Punch()
    {
        int punchType = Random.Range(1, 3); // 4 when uppercut is fixed
        //CheckForEnemiesInAttackRadius();
        switch (punchType)
        {
            case 1:
                an.SetTrigger("throwingStraight");
                break;
            case 2:
                an.SetTrigger("throwingJab");
                break;
            /*case 3:
                an.SetTrigger("throwingUppercut");
                break;*/
        }
        nextPunchTime = Time.time + punchPause;
    }
    private void Hit(float damage)
    {
        if (!isDead)
        {
            health = health - damage;
            if (health <= 0)
            {
                an.SetTrigger("playerDeath");
                an.SetBool("gameOver", true);
                isDead = true;
                uiM.RestartGame();
            }
            else
            {
                an.SetTrigger("playerHit");
                
            }
        }
        
    }
    public void Damage()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, 1<<8);

        if (hitColliders.Length>0)
        {
            DamageEnemies(hitColliders);
        }
    }

    private void DamageEnemies(Collider2D[] enemyColliders)
    {
        foreach (Collider2D c in enemyColliders)
        {
            if (c.name == "Enemy") c.gameObject.SendMessage("Hit", damage);
        }
    }
}
