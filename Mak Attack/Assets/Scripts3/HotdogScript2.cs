using UnityEngine;
using System.Collections;

public class HotdogScript2 : MonoBehaviour {

    // Use this for initialization

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject Rogue = GameObject.Find("Rogue");
        GameObject PineApple = GameObject.Find("PineApple");
        GameObject PineApple2 = GameObject.Find("PineApple2");
        RayoScriptLevel2 rayoScript = Rogue.GetComponent<RayoScriptLevel2>();
        //Health in World one.
        if (col.gameObject.name == "Rogue")
        {
            Destroy(gameObject);
            if (PlayerPrefs.GetInt("gothotdog") == 1)
            {
                Destroy(PineApple);
                Destroy(PineApple2);
            }
            else
            {
                PlayerPrefs.SetInt("gothotdog", 1);
            }

        }
    }
}
