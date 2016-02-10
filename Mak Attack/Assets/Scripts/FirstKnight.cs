using UnityEngine;
using System.Collections;

public class FirstKnight : MonoBehaviour {

    public Transform target;
    public float speed = 3f;
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

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        //To find and move to the Player
        doDamage = true;
        float myposition = transform.position.x;
        float playerposition = target.position.x;

        range = Vector2.Distance(transform.position, target.position);
        //Death
        if (knightLife <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2); //move on the z.
            anim.SetBool("dead", true);
            speed = 0f;
            knightDead = true;
            rb.isKinematic = true;
            BoxCollider2D b; //Remove the collision box.
            b = GetComponent<BoxCollider2D>();
            b.enabled = false;
        }
    }

}
