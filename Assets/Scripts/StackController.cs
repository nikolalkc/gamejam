using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class StackController : MonoBehaviour {
	public List<GameObject> snakeStack;
	public Text text;

	public GameObject firstEmptyRing;
	public GameObject lastDynamicRing;
	public GameObject firstStaticRing;


	public static GameObject firstEmpty;
	public static GameObject lastDynamic;
	public static GameObject lastEmpty;
	public static GameObject firstStatic;
	public static GameObject lastInStaticChain;
	public static GameObject firstNextEmpty;

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

		//first empty
		firstEmpty = null;
		if (snakeStack.Count > 0) {
			int lastElementIndex = snakeStack.IndexOf (snakeStack.Last ());

			for (int i = lastElementIndex; i > 0; i--) {
				if (snakeStack[i].tag == "emptyObject") {
					firstEmpty = snakeStack[i];
					break;
				}
			}
		}

		//last dynamic
		if (snakeStack.Count > 0) {
			lastDynamic = snakeStack.Last ();
			if (firstEmpty != null) {
				int indexOfFirstEmpty = snakeStack.IndexOf (firstEmpty);
				lastDynamic = snakeStack [indexOfFirstEmpty + 1];
			}
		}


		//firstStatic
		firstStatic = null;
		if (firstEmpty != null) {
			int indexOfFirstEmpty = snakeStack.IndexOf(firstEmpty);
			//print (indexOfFirstEmpty +" indekas");
			for (int i = indexOfFirstEmpty; i>0; i--) {
				if (snakeStack[i].tag != "emptyObject") {
					firstStatic = snakeStack[i];
					break;
				}
			}
		}
		//print ("**************************");



		//debug rings positioning

		if (firstEmpty == null) {
			firstEmptyRing.SetActive (false);
		} else {
			firstEmptyRing.SetActive (true);
			firstEmptyRing.transform.position = firstEmpty.transform.position;
		}

		if (lastDynamic == null) {
			lastDynamicRing.SetActive (false);
		} else {
			lastDynamicRing.SetActive (true);
			lastDynamicRing.transform.position = lastDynamic.transform.position;
		}


		if (firstStatic == null) {
			firstStaticRing.SetActive(false);

		} else {
			firstStaticRing.SetActive (true);
			firstStaticRing.transform.position = firstStatic.transform.position;
		}
		/*
		if (firstInFirstStaticChain == null) {
			firstInFirstStaticChainRing.SetActive (false);
		} else {
			firstInFirstStaticChainRing.SetActive (true);
			firstInFirstStaticChainRing.transform.position = firstInFirstStaticChain.transform.position;
		}*/












	}


}
