using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
		int count = 50000000;
		while (count > 0) {
			count--;
		}
		SceneManager.LoadScene("LevelOne");
			
	}
	*/

	// Update is called once per frame
	void Update () {
	}


	public void onClick() {
		Debug.Log ("got it to click");
		SceneManager.LoadScene("LevelOne");
	}
}