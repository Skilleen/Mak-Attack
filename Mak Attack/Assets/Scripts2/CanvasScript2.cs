using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript2 : MonoBehaviour {

    public Text instruction;
    public int armourLevel;
    private float timeLeft = 5.0f;
    private bool bossPaid = false;
    // Use this for initialization
    void Start()
    {
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScriptLevel2 rayoScript = Rogue.GetComponent<RayoScriptLevel2>();
        GameObject boss = GameObject.Find("secondBoss");
        SecondBossDialog bossScript = boss.GetComponent<SecondBossDialog>();
        if (bossScript.paymentAccept && !bossPaid && bossScript.range < 5)
        {
            rayoScript.rayoScore -= 100;
            bossScript.paymentAccept = false;
            bossPaid = true;
        }
        if (!rayoScript.dead)
        {
            instruction.text = "Health: " + rayoScript.rayoLife.ToString("n0") + "/" + rayoScript.rayoMaxLife.ToString() + "         Score: " + rayoScript.rayoScore.ToString() + "           Potions: " + rayoScript.potionCount.ToString();
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