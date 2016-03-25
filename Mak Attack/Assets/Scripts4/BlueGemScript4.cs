using UnityEngine;
using System.Collections;

public class BlueGemScript4 : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScriptLevel4 rayoScript = Rogue.GetComponent<RayoScriptLevel4>();
        //Health in World one.
        if (col.gameObject.name == "Rogue")
        {
            Destroy(gameObject);
            rayoScript.rayoScore = rayoScript.rayoScore + 200; //If health is less than 30.
        }
    }
}
