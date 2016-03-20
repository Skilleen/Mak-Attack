using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RayoScriptLevel3 : MonoBehaviour {
    Animator anim;
    public float speed = 3.5f;
    public bool facingRight = true;
    public float rayoLife;
    public int rayoScore;
    public bool dead = false;
    public int potionCount;
    public float rayoDamage;
    public int rayoMaxLife;
    public bool rayoHealed = false;
    private bool knight1Collide = false;
    private bool knight2Collide = false;
    private bool knight3Collide = false;
    private bool knight4Collide = false;
    public bool art = false;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rayoLife = PlayerPrefs.GetFloat("health");
        rayoMaxLife = PlayerPrefs.GetInt("maxhealth");
        rayoScore = PlayerPrefs.GetInt("score");
        rayoDamage = PlayerPrefs.GetFloat("damage");
        potionCount = PlayerPrefs.GetInt("potions");
        PlayerPrefs.SetInt("level", 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("health", rayoLife);
        PlayerPrefs.SetFloat("maxhealth", rayoMaxLife);
        PlayerPrefs.SetInt("score", rayoScore);
        PlayerPrefs.SetFloat("damage", rayoDamage);
        PlayerPrefs.SetInt("potions", potionCount);
        GameObject Knight1 = GameObject.Find("Knight");
        Knight1Script Knight1Script = Knight1.GetComponent<Knight1Script>();
        GameObject Knight2 = GameObject.Find("Knight2");
        Knight2Script Knight2Script = Knight2.GetComponent<Knight2Script>();
        GameObject Knight3 = GameObject.Find("Knight3");
        Knight3Script Knight3Script = Knight3.GetComponent<Knight3Script>();
        GameObject Knight4 = GameObject.Find("Knight4");
        Knight4Script Knight4Script = Knight4.GetComponent<Knight4Script>();
        Knight1.GetComponent<SpriteRenderer>().color = Color.white;
        Knight2.GetComponent<SpriteRenderer>().color = Color.white;
        Knight3.GetComponent<SpriteRenderer>().color = Color.white;
        Knight4.GetComponent<SpriteRenderer>().color = Color.white;
        anim.SetBool("attack", false);
        anim.SetBool("walk", false); //reset animations on every update
        if (!dead) //Make sure player is not dead
        {

            if (Input.GetKey(KeyCode.Q) && count <= 0)
            {
                if (potionCount > 0)
                {
                    potionCount--;
                    rayoLife = rayoMaxLife;
                    count = 100;
                }
            }

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

                if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("shanking"))
                {
                    // Avoid any reload.
                }
                else {
                    anim.SetBool("attack", true);
                    if (knight1Collide && !Knight1Script.knightDead && Knight1Script.doDamage && facingRight != Knight1Script.facingRight)
                    {
                        Knight1.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight1Script.knightLife -= 4;
                    }
                    if (knight1Collide && !Knight1Script.knightDead && !Knight1Script.doDamage)
                    {
                        Knight1.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight1Script.knightLife = 0;
                    }

                    if (knight2Collide && !Knight2Script.knightDead && Knight2Script.doDamage && facingRight != Knight2Script.facingRight)
                    {
                        Knight2.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight2Script.knightLife -= 4;
                    }
                    if (knight2Collide && !Knight2Script.knightDead && !Knight2Script.doDamage)
                    {
                        Knight2.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight2Script.knightLife = 0;
                    }

                    if (knight3Collide && !Knight3Script.knightDead && Knight3Script.doDamage && facingRight != Knight3Script.facingRight)
                    {
                        Knight3.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight3Script.knightLife -= 4;
                    }
                    if (knight3Collide && !Knight3Script.knightDead && !Knight3Script.doDamage)
                    {
                        Knight3.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight3Script.knightLife = 0;
                    }

                    if (knight4Collide && !Knight4Script.knightDead && !Knight4Script.isBackstab())
                    {
                        Knight4.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight4Script.knightLife -= 10;
                    }
                    if (knight4Collide && !Knight4Script.knightDead && Knight4Script.isBackstab())
                    {
                        Knight4.GetComponent<SpriteRenderer>().color = Color.red;
                        Knight4Script.knightLife = 0;
                    }
                }
            }
        }
        count--;
        if (Knight1Script.playerHit && Knight1Script.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.2f;
        }
        if (Knight2Script.playerHit && Knight2Script.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.2f;
        }
        if (Knight3Script.playerHit && Knight3Script.doDamage && !dead)
        {
            rayoLife = rayoLife - 0.2f;
        }
        if (Knight4Script.playerHit && Knight4Script.doDamage && !dead)
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
        if (col.gameObject.name == "Knight")
        {
            knight1Collide = true;
        }
        if (col.gameObject.name == "Knight2")
        {
            knight2Collide = true;
        }
        if (col.gameObject.name == "Knight3")
        {
            knight3Collide = true;
        }
        if (col.gameObject.name == "Knight4")
        {
            knight4Collide = true;
        }
        if (col.gameObject.name == "BumpForEnoch")
        {
            art = true;
        }
        if (col.gameObject.name == "levelExit")
        {
            SceneManager.LoadScene("Shop");
        }
    }
}