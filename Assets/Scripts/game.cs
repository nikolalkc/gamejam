using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static GameObject emptyObject;
	public static float globalSnakeSpeed = 1;
	public static float globalSpawnSpeed = 1.5f;

	void Awake() {
		emptyObject = new GameObject("emptyObject");
		//novi komentari za isprobavanje komitovanje na probni repozitori
	}
}
