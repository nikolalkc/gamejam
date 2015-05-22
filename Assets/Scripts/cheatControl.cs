using UnityEngine;
using System.Collections;

public class cheatControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {

			game.globalSnakeSpeed *= 2;
			game.globalSpawnSpeed /= 2;
			print ("SHIFT");
		}
	
	}


}
