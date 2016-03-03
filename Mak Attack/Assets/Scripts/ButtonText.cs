using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 15th, 2015
 * Dealing with the buttons.
 * 
 * */
public class ButtonText : MonoBehaviour {
	public int dialogCount = 0;
	public Button button1;
	public Button button2;
	// Use this for initialization
	void Start () {

	}

    void Update ()
    {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScript rayoScript = Rogue.GetComponent<RayoScript>();
        if(rayoScript.rayoScore < 100)
        {
            button1.interactable = false;
        }
        else
        {
            button1.interactable = true;
        }
    }

}
