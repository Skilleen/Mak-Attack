using UnityEngine;
using System.Collections;
/* Created by Scott Killeen, March 23rd, 2015.
 * Methods for dealing with the health gem.
 * */
public class NextLevel: MonoBehaviour {
	//When the player picks up the health.

	void OnCollisionEnter2D(Collision2D col){
		GameObject Rogue = GameObject.Find("Rogue");
		RayoScript rayoScript =  Rogue.GetComponent<RayoScript>();
		//Health in World one.
		if(col.gameObject.name=="Rogue"){
			Destroy(gameObject);
			rayoScript.rayoScore=rayoScript.rayoScore+200; //If health is less than 30.
		}
	}
}
