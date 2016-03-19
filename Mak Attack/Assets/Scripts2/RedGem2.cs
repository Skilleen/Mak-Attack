using UnityEngine;
using System.Collections;

public class RedGem2 : MonoBehaviour {

    // Use this for initialization
    //When the player picks up the health.
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScriptLevel2 rayoScript = Rogue.GetComponent<RayoScriptLevel2>();
        //Health in World one.
        if (col.gameObject.name == "Rogue")
        {
            Destroy(gameObject);
            rayoScript.rayoScore = rayoScript.rayoScore + 100; //If health is less than 30.
        }
    }
}
