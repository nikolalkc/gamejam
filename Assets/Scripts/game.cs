using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class game : MonoBehaviour {

	public static GameObject emptyObject;
	public static float globalSnakeSpeed = 3;
	public static float globalSpawnSpeed = 0.7f;

	public	int timeScaleSpeedUp = 5;
	public  int timeScaleSpeedDown = 7;
	void Update() {

		if (Input.GetKeyDown (KeyCode.RightShift)) {
			Time.timeScale *= timeScaleSpeedUp;
		}
		if (Input.GetKeyUp (KeyCode.RightShift)) {
			Time.timeScale /= timeScaleSpeedUp;
		}

		if (Input.GetKeyDown (KeyCode.RightAlt)) {
			Time.timeScale /= timeScaleSpeedDown;
		}
		if (Input.GetKeyUp (KeyCode.RightAlt)) {
			Time.timeScale *= timeScaleSpeedDown;
		}

	}

}
