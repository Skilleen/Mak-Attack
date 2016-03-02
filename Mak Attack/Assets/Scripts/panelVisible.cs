﻿using UnityEngine;
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
        private int count = 200;
		void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
		
		void Start ()
		{
			//canvasGroup.alpha=0; //Make the panel invisible
            canvasGroup.alpha = 0; //Make the panel invisible
            Cursor.visible = true;

    }

		void Update (){
            GameObject firstBoss = GameObject.Find("FirstBoss");
            BossDialog boss = firstBoss.GetComponent<BossDialog>();

            if (boss.displayDialog)
            {
                button1.interactable = true;
                button2.interactable = true;
                canvasGroup.alpha = 1;//show the conversation panel.
                Cursor.visible = true;
            }
            else {
                canvasGroup.alpha = 0;
                Cursor.visible = false;
            }
    }
		
	
	}
