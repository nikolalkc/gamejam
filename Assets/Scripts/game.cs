using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public static GameObject emptyObject;

	void Awake() {
		emptyObject = new GameObject("emptyObject");
		//novi komentari za isprobavanje komitovanje na probni repozitori
	}
}
