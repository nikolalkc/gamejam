using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StackController : MonoBehaviour {
	public List<GameObject> snakeStack;
	public Text text;

	void Update() {
		text.text = "";

		foreach (GameObject g in snakeStack) {
			text.text += (g.name + " ");

		}

	}


}
