using UnityEngine;
using System.Collections;


public class RayoScript : MonoBehaviour
{

    Animator anim;
    public float speed = 3.5f;
    public bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

            }
        }
    }
}
