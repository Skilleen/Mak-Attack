using UnityEngine;
using System.Collections;

public class KnightScript : MonoBehaviour
{

    public Transform target;
    public float speed = 3f;
    private float maxDistance = 30f;
    private float attackDistance = 5f;
    private float range;
    private Animator anim;
    //I usually avoid the use of global variables, but unity encourages it for working with the unity interface.
    public bool knightDead = false;
    public bool doDamage = false; //if both below are true.
    public bool playerHit = false; //If the goblin hits the player
    public bool inRange = false; //If player is in range
    public float knightLife = 50f;
    public Rigidbody2D rb;
    public bool facingRight = true;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        doDamage = false;
        playerHit = false;
        //To find and move to the Player
        float myposition = transform.position.x;
        float playerposition = target.position.x;
        if (playerposition > myposition && !facingRight)
        {
            Flip();
        }
        else if (myposition > playerposition && facingRight)
        {
            Flip();
        }
        range = Vector2.Distance(transform.position, target.position);
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
        if (range < 3f)
        {
            if (anim.GetBool("attack") == true)
            {
                playerHit = true;
                doDamage = true;
            }
        }
        //Death
        if (knightLife <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2); //move on the z.
            anim.SetBool("dead", true);
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            anim.SetBool("hit", false);
            speed = 0f;
            knightDead = true;
            rb.isKinematic = true;
            BoxCollider2D b; //Remove the collision box.
            b = GetComponent<BoxCollider2D>();
            b.enabled = false;
        }
    }
    //Handles Collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Dwarf" && !knightDead)
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