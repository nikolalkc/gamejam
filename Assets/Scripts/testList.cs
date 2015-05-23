using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testList : MonoBehaviour {

	public List<int> myList;

	// Use this for initialization
	void Start () {
		myList.Add (1);
		myList.Add (5);
		myList.Add (99);
		printList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			myList.Add (597);
		}
		if (Input.GetKeyDown(KeyCode.RightShift)) {
			myList.RemoveAt(2);
		}
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			printList();
		}
	}

	void printList() {
		foreach (int i in myList) {
			print(i);
		}
	}
}
