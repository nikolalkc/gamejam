using UnityEngine;
using System.Collections;

public class emptySphereControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroySelfOnMergeWithNext () {
		FollowMotionPath f = gameObject.GetComponent<FollowMotionPath>();
		StackController s = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
		int thisIndex = s.snakeStack.IndexOf(gameObject);
		FollowMotionPath compareToF = s.snakeStack[thisIndex-1].GetComponent<FollowMotionPath>();
		if (f.uv >= compareToF.uv)  {
			//s.snakeStack.Remove (gameObject);
			//Destroy (gameObject);
			print("Destroy:" + gameObject.name);
		}

	}
}
