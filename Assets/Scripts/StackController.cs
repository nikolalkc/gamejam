using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class StackController : MonoBehaviour {
	public List<GameObject> snakeStack;
	public Text text;

	public static GameObject firstStaticElement;
	public static GameObject lastDynamicElement;
	public static GameObject firstInFirstStaticChain;
	public GameObject firstStaticRing;
	public GameObject firstInFirstStaticChainRing;
	public GameObject lastDynamicRing;
	StackController s;

	void Update() {

		//debuging lista za ispisivanje
		text.text = "";
		for (int i=0; i< snakeStack.Count; i++) {
			if (snakeStack[i].Equals(null)){
				text.text += i.ToString() + " is NULL  ";
			}
			else {
				text.text += snakeStack[i].name + "  ";

			}
		}


		//definisanje elemenata

		//first static
		firstStaticElement = null;
		foreach (GameObject g in snakeStack) {
			if (g.tag == "emptyObject") {
				firstStaticElement = g;
				break;
			}
		}


		if (snakeStack.Count > 0) {
			lastDynamicElement = snakeStack.Last ();
		}

		if (firstStaticElement != null) {
			int indexOfFirstStatic = snakeStack.IndexOf(firstStaticElement);
			lastDynamicElement = snakeStack[indexOfFirstStatic-1];
		}








		//prvi u prvom staticnom lancu
		firstInFirstStaticChain = null;
		foreach (GameObject g in snakeStack) {
			if (snakeStack.IndexOf(g) > snakeStack.IndexOf(firstStaticElement)) { //da krene od prvog staticnog pa nadalje
				if (g.tag != "emptyObject") {
					firstInFirstStaticChain = g;
					break;
				}
			}
		}


		if (lastDynamicElement == null) {
			lastDynamicRing.SetActive (false);
		} else {
			lastDynamicRing.SetActive (true);
			lastDynamicRing.transform.position = lastDynamicElement.transform.position;
		}

		if (firstStaticElement == null) {
			firstStaticRing.SetActive (false);
		} else {
			firstStaticRing.SetActive (true);
			firstStaticRing.transform.position = firstStaticElement.transform.position;
		}

		if (firstInFirstStaticChain == null) {
			firstInFirstStaticChainRing.SetActive (false);
		} else {
			firstInFirstStaticChainRing.SetActive (true);
			firstInFirstStaticChainRing.transform.position = firstInFirstStaticChain.transform.position;
		}












	}


}
