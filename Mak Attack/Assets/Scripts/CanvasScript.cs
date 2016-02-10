using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public Text instruction;
    public int armourLevel;
    // Use this for initialization
    void Start () {
       instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScript rayoScript = Rogue.GetComponent<RayoScript>();
        instruction.text = "Health: " + rayoScript.rayoLife.ToString("n2");
    }
}
