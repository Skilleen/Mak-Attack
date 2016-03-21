using UnityEngine;
using System.Collections;

public class BlueGemScript3 : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScriptLevel3 rayoScript = Rogue.GetComponent<RayoScriptLevel3>();
        //Health in World one.
        if (col.gameObject.name == "Rogue")
        {
            Destroy(gameObject);
            rayoScript.rayoScore = rayoScript.rayoScore + 200; //If health is less than 30.
        }
    }
}