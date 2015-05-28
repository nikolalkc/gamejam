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
       // gameObject.GetComponent<FollowMotionPath>().movement = FollowMotionPath.Movement.Static;
        DestoyChain();
	}

    void OnDestroy()
    {
       // print(gameObject.name + " is Destroyed!");
    }


    void DestoyChain()
    {
        int ind = stackControlRef.snakeStack.IndexOf(gameObject);
        //print (ind);
        float thisGameObjectType = gameObject.GetComponent<ElementType>().type;

        //find object on right to destroy
        for (int i = ind; i < stackControlRef.snakeStack.Count; i++)
        {
            if (!(stackControlRef.snakeStack[i].tag == "emptyObject"))
            {
                //print (stackControlRef.snakeStack[i].name);
                float compareGameObjectType = stackControlRef.snakeStack[i].GetComponent<RandomColor>().randomColor;
                if (compareGameObjectType == thisGameObjectType)
                {
                    listOfIndexesToDelete.Add(i);
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        //find object on left to destroy
        for (int i = ind - 1; i > 0; i--)
        {
            if (!(stackControlRef.snakeStack[i].tag == "emptyObject"))
            {
              //  print(stackControlRef.snakeStack[i].name);
                float compareGameObjectType = stackControlRef.snakeStack[i].GetComponent<RandomColor>().randomColor;
                if (compareGameObjectType == thisGameObjectType)
                {
                    listOfIndexesToDelete.Add(i);
                }
                else
                {
                    break;
                }

            }
            else
            {
                break;
            }
        }

        //destroy objects
        //if (listOfIndexesToDelete.Count > 0) {
        for (int i = 0; i < listOfIndexesToDelete.Count; i++)
        {
            Transform thisObjectTransform;
            thisObjectTransform = stackControlRef.snakeStack[listOfIndexesToDelete[i]].transform;
            GameObject createdObject;
            createdObject = Instantiate(emptySphere, thisObjectTransform.position, Quaternion.identity) as GameObject;
            FollowMotionPath instantiatedObject;
            instantiatedObject = createdObject.GetComponent<FollowMotionPath>();
            float createdStartPosition;
            createdStartPosition = stackControlRef.snakeStack[listOfIndexesToDelete[i]].GetComponent<FollowMotionPath>().uv;
            instantiatedObject.startPosition = createdStartPosition;
           // print(createdStartPosition);
            //print(gameObject.name + " destroyed on click.");
            Destroy(stackControlRef.snakeStack[listOfIndexesToDelete[i]]);
            stackControlRef.snakeStack[listOfIndexesToDelete[i]] = instantiatedObject.gameObject;

        }
        //}
        listOfIndexesToDelete.Clear();


    }

}
