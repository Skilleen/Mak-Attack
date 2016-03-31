﻿using UnityEngine;
using System.Collections;

public class boss4Script : MonoBehaviour {

    public Transform target;
    public float speed = 23f;
    private float maxDistance = 10f;
    private float attackDistance = 8f;
    public float startposition;
    public float endpositionX;
    public float endpositionY;
    private float range;
    private int count = 1;
    private Animator anim;
    //I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
    public bool knightDead = false;
    public bool doDamage = false; //if both below are true.
    public bool playerHit = false; //If the goblin hits the player
    public bool inRange = false; //If player is in range
    public float knightLife = 10000;
    public Rigidbody2D rb;
    public bool facingRight = true;
    private GameObject Rogue;
    private RayoScriptLevel4 rogueScript;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        Rogue = GameObject.Find("Rogue");
        rogueScript = Rogue.GetComponent<RayoScriptLevel4>();
        if (rogueScript.dead)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
        }
        float playerposition = target.position.x;
        range = Vector2.Distance(transform.position, target.position);


        //To find and move to the Player
        if (!rogueScript.dead && PlayerPrefs.GetInt("bossAttack") == 1)
        {
            maxDistance = 50;
            doDamage = false;
            playerHit = false;
            if (playerposition > transform.position.x && !facingRight)
            {
                Flip();
            }
            else if (transform.position.x > playerposition && facingRight)
            {
                Flip();
            }


            //If Player is in range, start moving towards.

            if (range < maxDistance)
            {
                anim.SetBool("walk", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else {
                anim.SetBool("walk", false);
            }
            if (range > attackDistance)
            {
                anim.SetBool("attack", false);
            }



            if (range < 5f && PlayerPrefs.GetInt("bossAttack") == 1)
            {
                if (anim.GetBool("attack") == true)
                {
                    playerHit = true;
                    doDamage = true;
                }
            }
        }
        //Death
        if (knightLife <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2); //move on the z.
            anim.SetBool("dead", true);
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            speed = 0f;
            knightDead = true;
            rb.isKinematic = true;
            BoxCollider2D b; //Remove the collision box.
            b = GetComponent<BoxCollider2D>();
            b.enabled = false;
            PlayerPrefs.SetInt("bossAttack", 2);
            if (count == 1)
            {
                rogueScript.rayoScore += 300;
                count++;
            }
        }
    }
    //Handles Collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Rogue" && !knightDead && !rogueScript.dead && PlayerPrefs.GetInt("bossAttack") == 1)
        {
            anim.SetBool("attack", true);
            if (range < attackDistance)
            {
                playerHit = true;
            }

        }

    }

    //To face left and right
    void Flip()
    {
        if (!knightDead)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
