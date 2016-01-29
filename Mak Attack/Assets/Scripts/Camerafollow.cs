using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Camerafollow : MonoBehaviour {
	private Transform player;
	
	void Start () {
		player = GameObject.Find("Rogue").transform;
	}
	//Have the camera follow the rogue.
	void Update () {
		Vector3 playerpos = player.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
		//Quit Game
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
}
