using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] Animator an;
    [SerializeField] float moveForce;
    private float nextPunchTime;
    private float punchPause;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        punchPause = 0.1f;
        moveForce = 5f;
        nextPunchTime = Time.time + punchPause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && nextPunchTime < Time.time)
        {
            Debug.Log("pUNCH!");
            Punch();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Dodge!");
        }
    }
    void FixedUpdate()
    {
        Move();
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

        // TODO: add physics overlap to check if enemies are within punch radius

        // TODO: call "HIT()" method on objects within radius
    }
}
