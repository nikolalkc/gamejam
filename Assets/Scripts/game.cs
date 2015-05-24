using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static GameObject emptyObject;
	public static float globalSnakeSpeed = 6;
	public static float globalSpawnSpeed = 0.25f;

	void Awake() {
		emptyObject = new GameObject("emptyObject");
		//novi komentari za isprobavanje komitovanje na probni repozitori
	}
}
