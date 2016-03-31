using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
	public int rayoScore = 0;
	public bool dead = false;
	public int count = 100;
	public int count2 = 100;
	public Text scoreText; 
	public float timeM = 1.0f;
	// Use this for initialization
	void Start()
	{
		
		rayoScore = PlayerPrefs.GetInt ("score");
		scoreText.text = "Your Final Score is: " + rayoScore.ToString();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		timeM += Time.time;
		if (timeM > 300.0) {
			Application.LoadLevel ("menu");
		}
	}
}