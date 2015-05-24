using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static GameObject emptyObject;
	public static float globalSnakeSpeed = 3;
	public static float globalSpawnSpeed = 0.5f;

	void Awake() {
		emptyObject = new GameObject("emptyObject");
		//novi komentari za isprobavanje komitovanje na probni repozitori
	}
}
