using UnityEngine;
using System.Collections;

public class enoch : MonoBehaviour {
	// Update is called once per frame

	void Update () {
		GameObject Rogue = GameObject.Find("Rogue");
		RayoScript rayoScript =  Rogue.GetComponent<RayoScript>();
		if (rayoScript.art) {
			transform.position = new Vector3(transform.position.x, transform.position.y, 0); //move on the z.
		}
	}
}
