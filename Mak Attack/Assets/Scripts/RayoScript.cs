using UnityEngine;
using System.Collections;


public class RayoScript : MonoBehaviour
{

    Animator anim;
    public float speed = 3.5f;
    public bool facingRight = true;
    public float rayoLife = 100f;
    public int rayoScore = 0;
    public bool dead = false;
    private bool firstknightCollide = false;
    private bool patrolknightCollide = false;
    private bool patrolknightCollide2 = false;

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
        GameObject PatrolKnight2 = GameObject.Find("KnightPatrol2");
        KnightScript2 patrolknightScript2 = PatrolKnight2.GetComponent<KnightScript2>();
        Knight.GetComponent<SpriteRenderer>().color = Color.white;
        PatrolKnight.GetComponent<SpriteRenderer>().color = Color.white;
        //PatrolKnight2.GetComponent<SpriteRenderer>().color = Color.white;

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
                if (firstknightCollide && !knightScript.knightDead)
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
                if (patrolknightCollide2 && !patrolknightScript2.knightDead && !patrolknightScript2.isBackstab())
                {
                    PatrolKnight2.GetComponent<SpriteRenderer>().color = Color.red;
                    patrolknightScript2.knightLife -= 8;
                }
                if (patrolknightCollide2 && !patrolknightScript2.knightDead && patrolknightScript2.isBackstab())
                {
                    PatrolKnight2.GetComponent<SpriteRenderer>().color = Color.red;
                    patrolknightScript2.knightLife = 0;
                }
            }
        }
        if (patrolknightScript.playerHit && patrolknightScript.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.2f;
        }
        if (patrolknightScript2.playerHit && patrolknightScript2.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.2f;
        }
        if (rayoLife <= 0)
        {
            anim.SetBool("dead", true);
            anim.SetBool("attack", false);
            anim.SetBool("walk", false);
            dead = true;
            rayoLife = 0;         
        }
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
        if (col.gameObject.name == "KnightPatrol2")
        {
            patrolknightCollide2 = true;
        }
    }
}
