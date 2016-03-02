using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class menuButtonScript : MonoBehaviour {
	// Update is called once per frame
	void Update () {
	}


	public void onClick() {
		SceneManager.LoadScene("LevelOne");
	}
}