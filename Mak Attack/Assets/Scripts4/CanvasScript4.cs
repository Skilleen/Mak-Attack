using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript4 : MonoBehaviour {

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
        RayoScriptLevel4 rayoScript = Rogue.GetComponent<RayoScriptLevel4>();
        GameObject boss = GameObject.Find("thirdBoss");
        ThirdBossDialog bossScript = boss.GetComponent<ThirdBossDialog>();
        if (bossScript.paymentAccept && !bossPaid && bossScript.range < 5)
        {
            rayoScript.rayoScore -= 100;
            bossScript.paymentAccept = false;
            bossPaid = true;
        }
        if (!rayoScript.dead)
        {
            instruction.text = "Health: " + rayoScript.rayoLife.ToString() + "/" + rayoScript.rayoMaxLife.ToString() + "         Score: " + rayoScript.rayoScore.ToString() + "           Potions: " + rayoScript.potionCount.ToString();
        }
        else
        {
            instruction.text = "You are dead! Your Final score is " + rayoScript.rayoScore.ToString("n2");
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
            }
        }
    }
}
