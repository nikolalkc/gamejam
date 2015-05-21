using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class snakeElementControl : MonoBehaviour
{
	StackController stackControlRef;
	Text text;
	static int elementIndex = 0;
	public int thisElementIndex;
	public List<int> listOfIndexesToDelete;
	public GameObject emptySphere;

	// Use this for initialization
		void Start ()
	{
		text = gameObject.GetComponentInChildren<Text> ();
		text.color = Color.black;
		text.text = elementIndex.ToString ();
		thisElementIndex = elementIndex;
		elementIndex += 1;

		gameObject.name = "Cube_" + thisElementIndex.ToString ();
		stackControlRef = GameObject.FindGameObjectWithTag ("stackControl").GetComponent<StackController> ();
		stackControlRef.snakeStack.Add (gameObject);
		foreach (GameObject g in stackControlRef.snakeStack) {
			//				snakeElementControl s = g.GetComponent<snakeElementControl>();
			//print(s.thisElementIndex);

			//print (stackControlRef.snakeStack.IndexOf(g));
		}

		//print ("======================");
	}

	void OnMouseEnter ()
	{
		gameObject.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
	}

	void OnMouseExit ()
	{
		gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	void OnMouseDown ()	{									//if (stackControlRef.snakeStack [i].tag <> "emptyObject")
		int ind = stackControlRef.snakeStack.IndexOf (gameObject);
		//print (ind);
		float thisGameObjectType = gameObject.GetComponent<RandomColor> ().randomColor;

		//find object on right to destroy
		for (int i = ind; i < stackControlRef.snakeStack.Count; i++) {
			if (!(stackControlRef.snakeStack[i].tag == "emptyObject")) {
				print (stackControlRef.snakeStack[i].name);
				float compareGameObjectType = stackControlRef.snakeStack [i].GetComponent<RandomColor> ().randomColor;
				if (compareGameObjectType == thisGameObjectType) {
					listOfIndexesToDelete.Add (i);
				}
				else {
					break;
				}
			}	
			else {
				break;
			}
		}

		//find object on left to destroy
		for (int i = ind-1; i > 0; i--) {
			if (!(stackControlRef.snakeStack [i].tag == "emptyObject")) {
				print (stackControlRef.snakeStack[i].name);
				float compareGameObjectType = stackControlRef.snakeStack [i].GetComponent<RandomColor> ().randomColor;
				if (compareGameObjectType == thisGameObjectType) {
					listOfIndexesToDelete.Add (i);
				}
				else {
					break;
				}

			}
			else {
				break;
			}
		}

		//destroy objects
		//if (listOfIndexesToDelete.Count > 0) {
		for (int i = 0; i<listOfIndexesToDelete.Count; i++) {
			Transform thisObjectTransform;
			thisObjectTransform = stackControlRef.snakeStack [listOfIndexesToDelete [i]].transform;
			GameObject createdObject;
			createdObject = Instantiate (emptySphere,thisObjectTransform.position,Quaternion.identity) as GameObject;
			FollowMotionPath instantiatedObject;
			instantiatedObject = createdObject.GetComponent<FollowMotionPath>();
			float createdStartPosition;
			createdStartPosition = stackControlRef.snakeStack [listOfIndexesToDelete [i]].GetComponent<FollowMotionPath>().uv;
			instantiatedObject.startPosition = createdStartPosition;
			print (createdStartPosition);
			
			Destroy (stackControlRef.snakeStack [listOfIndexesToDelete [i]]);
			stackControlRef.snakeStack [listOfIndexesToDelete [i]] = instantiatedObject.gameObject;

		}
				//}
				listOfIndexesToDelete.Clear ();


		}

}
