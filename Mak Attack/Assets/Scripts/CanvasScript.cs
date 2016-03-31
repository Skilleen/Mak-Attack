using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour {

    public Text instruction;
    public int armourLevel;
    private float timeLeft = 5.0f;
    public bool bossPaid = false;
    // Use this for initialization
    void Start () {
       instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScript rayoScript = Rogue.GetComponent<RayoScript>();
        GameObject boss = GameObject.Find("FirstBoss");
        BossDialog bossScript = boss.GetComponent<BossDialog>();
        if (bossScript.paymentAccept && !bossPaid && bossScript.range < 5)
        {
            rayoScript.rayoScore -= 100;
            bossScript.paymentAccept = false;
            bossPaid = true;
            PlayerPrefs.SetInt("bossAttack", 2);
        }
        else if (bossScript.attackBoss && !bossPaid && bossScript.range < 5)
        {
            PlayerPrefs.SetInt("bossAttack", 1);
        }
        if (!rayoScript.dead)
        {
            instruction.text = "Health: " + rayoScript.rayoLife.ToString("n1") + "/" + rayoScript.rayoMaxLife.ToString() + "         Score: " + rayoScript.rayoScore.ToString() + "           Potions: "+rayoScript.potionCount.ToString();
        }
    }
}
