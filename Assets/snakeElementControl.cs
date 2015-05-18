﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class snakeElementControl : MonoBehaviour
{
		StackController stackControlRef;
		Text text;
		static int elementIndex = 0;
		public int thisElementIndex;
		
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

		void OnMouseDown ()
		{

				int ind = stackControlRef.snakeStack.IndexOf (gameObject);
				print (ind);
				float thisGameObjectType = gameObject.GetComponent<RandomColor> ().randomColor;
				
				//destroy object on right
				for (int i = ind; i < stackControlRef.snakeStack.Count; i++) {

						if (!stackControlRef.snakeStack [i].Equals (game.emptyObject)) {
								float compareGameObjectType = stackControlRef.snakeStack [i].GetComponent<RandomColor> ().randomColor;
								if (compareGameObjectType == thisGameObjectType) {

										Destroy (stackControlRef.snakeStack [i]);
										stackControlRef.snakeStack [i] = game.emptyObject;

								} else {
										break;

								}
						} else {
								break;
						}
				}


		}

}
