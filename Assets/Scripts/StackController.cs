using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StackController : MonoBehaviour {
	public List<GameObject> snakeStack;
	public Text text;

	void Update() {
		text.text = "";
		for (int i=0; i< snakeStack.Count; i++) {
			if (snakeStack[i].Equals(null)){
				text.text += i.ToString() + " is NULL  ";
			}
			else {
				text.text += snakeStack[i].name + "  ";

			}
		}
//		foreach (GameObject g in snakeStack) {
//			text.text += g.name;
//
//		}

	}


}
