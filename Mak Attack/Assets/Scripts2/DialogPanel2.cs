using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogPanel2 : MonoBehaviour {

    CanvasGroup canvasGroup;
    public Button button1; //Two Dialog buttons.
    public Button button2;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        canvasGroup.alpha = 0; //Make the panel invisible

    }

    void Update()
    {
        GameObject secondBoss = GameObject.Find("secondBoss");
        SecondBossDialog boss = secondBoss.GetComponent<SecondBossDialog>();
        GameObject Rogue = GameObject.Find("Rogue");
        RayoScriptLevel2 rayoScript = Rogue.GetComponent<RayoScriptLevel2>();
        if (boss.range > 5)
        {
            button1.interactable = false;
            button2.interactable = false;
        }
        else if (boss.range <= 5 && PlayerPrefs.GetFloat("score") > 100)
        {
            button1.interactable = true;
            button2.interactable = true;
        }
        else if (boss.range <= 5 && PlayerPrefs.GetFloat("score") < 100)
        {
            button1.interactable = false;
            button2.interactable = true;
        }

        if (boss.displayDialog)
        {
            canvasGroup.alpha = 1;//show the conversation panel.
            Cursor.visible = true;
        }
        else {
            canvasGroup.alpha = 0;
            Cursor.visible = false;
        }
    }


}
