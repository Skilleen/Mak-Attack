using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
	public int rayoScore = 0;
	public bool dead = false;
	public Text scoreText; 
	public float timeM;
	public float restartDelay = 5f;
	// Use this for initialization
	void Start()
	{
		
		rayoScore = PlayerPrefs.GetInt ("score");
		scoreText.text = "Your Final Score is: " + rayoScore.ToString();
		//timeM = 5.0f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		timeM += Time.deltaTime;
		if (timeM >= restartDelay) {
			Application.LoadLevel ("menu");
		}
	}
}