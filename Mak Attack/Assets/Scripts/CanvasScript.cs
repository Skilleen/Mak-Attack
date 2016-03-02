using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour {

    public Text instruction;
    public int armourLevel;
    private float timeLeft = 5.0f;
    // Use this for initialization
    void Start () {
       instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScript rayoScript = Rogue.GetComponent<RayoScript>();
        if (!rayoScript.dead)
        {
            instruction.text = "Health: " + rayoScript.rayoLife.ToString("n2") + "         Score: " + rayoScript.rayoScore.ToString() + "           Potions: 1";
        }
        else
        {
            instruction.text = "You are dead! Your Final score is " + rayoScript.rayoScore.ToString("n2");
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene("menu");
            }
        }
    }
}
