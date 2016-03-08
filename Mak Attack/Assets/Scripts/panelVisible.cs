using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* Scott Killeen, March 15th, 2015
 * Methods for Dealing with the panel for dialog.
 * 
 * */
public class panelVisible : MonoBehaviour {
	
		CanvasGroup canvasGroup;
		public Button button1; //Two Dialog buttons.
		public Button button2;
		void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		
		void Start ()
		{
            canvasGroup.alpha = 0; //Make the panel invisible

    }

		void Update (){
            GameObject firstBoss = GameObject.Find("FirstBoss");
            BossDialog boss = firstBoss.GetComponent<BossDialog>();
            GameObject Rogue = GameObject.Find("Rogue");
            RayoScript rayoScript = Rogue.GetComponent<RayoScript>();
        if (boss.range > 5)
        {
            button1.interactable = false;
            button2.interactable = false;
        }
        else if (boss.range <= 5 && rayoScript.rayoScore > 100)
        {
            button1.interactable = true;
            button2.interactable = true;
        }
        else if (boss.range <= 5 && rayoScript.rayoScore < 100)
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
