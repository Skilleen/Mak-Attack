using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour {
	// Update is called once per frame
	void Update () {
	}


	public void onClick() {
		SceneManager.LoadScene("LevelOne");
	}
}