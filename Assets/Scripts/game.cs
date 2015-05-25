using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static GameObject emptyObject;
	public static float globalSnakeSpeed = 2;
	public static float globalSpawnSpeed = 0.75f;

	void Awake() {
		emptyObject = new GameObject("emptyObject");
		//novi komentari za isprobavanje komitovanje na probni repozitori
	}
}
