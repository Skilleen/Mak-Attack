using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int count = 50000000;
		while (count > 0) {
			count--;
		}
		SceneManager.LoadScene("LevelOne");
			
	}

	// Update is called once per frame
	void Update () {
	}

	public void onClick() {
		SceneManager.LoadScene("LevelOne");
	}
}