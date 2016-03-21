using UnityEngine;
using System.Collections;

public class HotdogScript3 : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Rogue = GameObject.Find("Rogue");
        GameObject PineApple = GameObject.Find("PineApple3");
        RayoScriptLevel2 rayoScript = Rogue.GetComponent<RayoScriptLevel2>();
        //Health in World one.
        if (col.gameObject.name == "Rogue")
        {
            Destroy(gameObject);
            Destroy(PineApple);

        }
    }
}