using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
	public int rayoScore = 0;
	public bool dead = false;
	public int count = 1;
	public Text scoreText; 
	// Use this for initialization
	void Start()
	{
		
		rayoScore = PlayerPrefs.GetInt ("score");
			//Application.LoadLevel ("menu");
		scoreText.text = "Your Final Score is: " + rayoScore.ToString();

	}

	// Update is called once per frame
	void FixedUpdate()
	{

	}
}