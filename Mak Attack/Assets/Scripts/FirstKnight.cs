using UnityEngine;
using System.Collections;

public class FirstKnight : MonoBehaviour {

    public float speed = 3f;
    private Animator anim;
    public bool knightDead = false;
    public float knightLife = 50f;
    public Rigidbody2D rb;
    private int count = 1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        GameObject Rogue = GameObject.Find("Rogue");
        RayoScript rogueScript = Rogue.GetComponent<RayoScript>();
        //Death
        if (knightLife == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2); //move on the z.
            anim.SetBool("dead", true);
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

}
