using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RayoScriptLevel5 : MonoBehaviour {

    Animator anim;
    public float speed = 3.5f;
    public bool facingRight = true;
    public float rayoLife;
    public int rayoScore;
    public bool dead = false;
    public int potionCount;
    public float rayoDamage;
    public int rayoMaxLife;
    private bool bossCollide = false;
    public bool rayoHealed = false;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerPrefs.SetInt("gothotdog", 0);
        rayoLife = PlayerPrefs.GetFloat("health");
        rayoMaxLife = PlayerPrefs.GetInt("maxhealth");
        rayoScore = PlayerPrefs.GetInt("score");
        rayoDamage = PlayerPrefs.GetFloat("damage");
        potionCount = PlayerPrefs.GetInt("potions");
        PlayerPrefs.SetInt("level", 5);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("health", rayoLife);
        PlayerPrefs.SetInt("maxhealth", rayoMaxLife);
        PlayerPrefs.SetInt("score", rayoScore);
        PlayerPrefs.SetFloat("damage", rayoDamage);
        PlayerPrefs.SetInt("potions", potionCount);
        GameObject boss = GameObject.Find("finalBoss");
        finalBossScript bossScript = boss.GetComponent<finalBossScript>();
        boss.GetComponent<SpriteRenderer>().color = Color.white;
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
                    if (bossCollide && !bossScript.knightDead && bossScript.doDamage)
                    {
                        boss.GetComponent<SpriteRenderer>().color = Color.red;
                        bossScript.knightLife -= 4;
                    }

                }
            }
            count--;
            if (bossScript.playerHit && bossScript.doDamage && !dead)
            {
                rayoLife = rayoLife - 0.5f;
            }
            if (rayoLife <= 0)
            {
                anim.SetBool("dead", true);
                anim.SetBool("attack", false);
                anim.SetBool("walk", false);
                dead = true;
                rayoLife = 0;
				SceneManager.LoadScene("GameOverScreen");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
     
        if (col.gameObject.name == "levelExit" )
        {
            SceneManager.LoadScene("GameWin");
        }
        if (col.gameObject.name == "finalBoss")
        {
            bossCollide = true;
            GameObject temp = GameObject.Find("enochonalex");
            temp.AddComponent<BoxCollider2D>();
        }
    }
}
