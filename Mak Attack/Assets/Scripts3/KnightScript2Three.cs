﻿using UnityEngine;
using System.Collections;

public class KnightScript2Three : MonoBehaviour {

	    public Transform target;
public float speed = 23f;
private float maxDistance = 10f;
private float attackDistance = 8f;
public float startposition;
public float endpositionX;
public float endpositionY;
private float range;
private Animator anim;
private int count = 1;
private bool spotted = false;
private bool reversePath = false;
//I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
public bool knightDead = false;
public bool doDamage = false; //if both below are true.
public bool playerHit = false; //If the goblin hits the player
public bool inRange = false; //If player is in range
public float knightLife = 150f;
public Rigidbody2D rb;
public bool facingRight = true;
public Transform[] points;
private GameObject Rogue;
private RayoScriptLevel3 rogueScript;

    void Start()
    {
        anim = GetComponent<Animator>();
        startposition = transform.position.x;
        endpositionX = 65;
        endpositionY = -3;
        
    }


    void FixedUpdate()
    {
        Rogue = GameObject.Find("Rogue");
        rogueScript = Rogue.GetComponent<RayoScriptLevel3>();
        if (rogueScript.dead)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", false);
        }
        float playerposition = target.position.x;
        range = Mathf.Abs(Vector2.Distance(transform.position, target.position));
        if ((((range > maxDistance) || (target.position.x - transform.position.x > 0 && reversePath) || (transform.position.x - target.position.x > 0 && !reversePath)) && !spotted))
        {
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
            if (transform.position.x == endpositionX)
            {
                Flip();
                if (!reversePath)
                {
                    endpositionX = 25;
                    endpositionY = -3;
                    reversePath = true;
                }
                else
                {
                    endpositionX = 65;
                    endpositionY = -3;
                    reversePath = false;
                }
            }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(endpositionX, endpositionY), speed * Time.deltaTime);
    }

    //To find and move to the Player
    else if (!rogueScript.dead)
    {
        spotted = true;
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
            Debug.LogWarning(range);
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



        if (range < 3f)
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
        if (count == 1)
        {
            rogueScript.rayoScore += 50;
            count++;
        }
    }
}
//Handles Collisions
void OnCollisionEnter2D(Collision2D col)
{
    if (col.gameObject.name == "Rogue" && !knightDead && !rogueScript.dead)
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
