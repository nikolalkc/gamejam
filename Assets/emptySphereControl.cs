using UnityEngine;
using System.Collections;

public class emptySphereControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "cube") {
			StackController s = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
			int index =s.snakeStack.IndexOf(gameObject);
			s.snakeStack.RemoveAt(index);

			//Destroy(gameObject);
		
		}

	}
}
