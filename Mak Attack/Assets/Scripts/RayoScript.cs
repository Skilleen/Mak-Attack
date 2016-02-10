using UnityEngine;
using System.Collections;


public class RayoScript : MonoBehaviour
{

    Animator anim;
    public float speed = 3.5f;
    public bool facingRight = true;
    public float rayoLife = 100f;
    public bool dead = false;
    private bool firstknightCollide = false;
    private bool patrolknightCollide = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject Knight = GameObject.Find("FirstKnight");
        FirstKnight knightScript = Knight.GetComponent<FirstKnight>();
        GameObject PatrolKnight = GameObject.Find("KnightPatrol");
        KnightScript patrolknightScript = PatrolKnight.GetComponent<KnightScript>();

        anim.SetBool("attack", false);
        anim.SetBool("walk", false); //reset animations on every update
        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingRight = false;
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingRight = true;
            }
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            anim.SetBool("walk", true);
            anim.SetBool("attack", false);
        }

        if (Input.GetMouseButton(0))
        {

            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("RogueAttack"))
            {
                // Avoid any reload.
            }
            else {
                anim.SetBool("attack", true);
                if (firstknightCollide && !knightScript.knightDead && knightScript.doDamage)
                {
                    Knight.GetComponent<SpriteRenderer>().color = Color.red;
                    knightScript.knightLife = 0;
                }
                if (patrolknightCollide && !patrolknightScript.knightDead && patrolknightScript.doDamage && facingRight != patrolknightScript.facingRight)
                {
                    PatrolKnight.GetComponent<SpriteRenderer>().color = Color.red;
                    patrolknightScript.knightLife -= 2;
                }
                if (patrolknightCollide && !patrolknightScript.knightDead && !patrolknightScript.doDamage)
                {
                    PatrolKnight.GetComponent<SpriteRenderer>().color = Color.red;
                    patrolknightScript.knightLife = 0;
                }
            }
        }
        if (patrolknightScript.playerHit && patrolknightScript.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.3f;
        }
        if(rayoLife <= 0)
        {
            anim.SetBool("dead", true);
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            dead = true;
            rayoLife = 0;         
        }
        Debug.Log(rayoLife);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "FirstKnight")
        {
            firstknightCollide = true;
        }
        if(col.gameObject.name == "KnightPatrol")
        {
            patrolknightCollide = true;
        }
    }
}
