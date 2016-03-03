using UnityEngine;
using System.Collections;

public class BossDialog : MonoBehaviour
{

    public float range = 0; //check if the player is in range
    public bool displayDialog = false; //If the conversation box is shown.
    public Transform target;
    public bool paymentAccept = false; //If the user accepted.
    public Rigidbody2D rb;
    public bool attackBoss = false;



    // Update is called once per frame
    void Update()
    {

        //If the player has moved away
        range = Vector2.Distance(transform.position, target.position);
        if (range >= 5)
        {
            displayDialog = false;
            Cursor.visible = false;
        }
        rb = GetComponent<Rigidbody2D>();
        if (rb.mass == 99)
        {
            paymentAccept = true;
            rb.mass = 97;

        }
        if(rb.mass == 98)
        {
            attackBoss = true;
            rb.mass = 97;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Rogue")
        {
            displayDialog = true;

        }
    }
}