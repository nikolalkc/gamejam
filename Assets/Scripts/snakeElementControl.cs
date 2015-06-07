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
    public GameObject puff;
    
	void Start ()
	{
		text = gameObject.GetComponentInChildren<Text> ();
		text.color = Color.black;
		text.text = elementIndex.ToString ();
		thisElementIndex = elementIndex;
		elementIndex += 1;

		gameObject.name = "Virus_" + thisElementIndex.ToString ();
		stackControlRef = GameObject.FindGameObjectWithTag ("stackControl").GetComponent<StackController> ();
		stackControlRef.snakeStack.Add (gameObject);

	}

	void OnMouseEnter ()
	{
		gameObject.transform.localScale = 1.2f * transform.localScale;
	}

	void OnMouseExit ()
	{
        gameObject.transform.localScale =0.85f * transform.localScale;
	}

	void OnMouseDown ()	{									//if (stackControlRef.snakeStack [i].tag <> "emptyObject")
        print(gameObject.name + "is Clicked");
        // gameObject.GetComponent<FollowMotionPath>().movement = FollowMotionPath.Movement.Static;
        DestoyChain();
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
                float compareGameObjectType = stackControlRef.snakeStack[i].GetComponent<ElementType>().type;
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
                print(stackControlRef.snakeStack[i].name);
                float compareGameObjectType = stackControlRef.snakeStack[i].GetComponent<ElementType>().type;
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
       // print("destroy Objects");
        for (int i = 0; i < listOfIndexesToDelete.Count; i++)
        {
           // print(listOfIndexesToDelete[i]);
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
            //unisti objekat i izbrisi ga iz liste

            //getuj tip objekta (boju)
            int destroyGameObjectType = stackControlRef.snakeStack[listOfIndexesToDelete[i]].GetComponent<ElementType>().type;
            print("destroy Object type:" + destroyGameObjectType);
            //napravi partikl kao sto je objekat
            GameObject part;
            part = Instantiate(puff, stackControlRef.snakeStack[listOfIndexesToDelete[i]].transform.position, Quaternion.identity) as GameObject;
           
            ParticleTexture p = part.GetComponent<ParticleTexture>();
            p.ChangeTexture(destroyGameObjectType);
            //unistiii
            Destroy(stackControlRef.snakeStack[listOfIndexesToDelete[i]]);
            stackControlRef.snakeStack[listOfIndexesToDelete[i]] = instantiatedObject.gameObject;
            
            
            

            

            


        }
        //}
        listOfIndexesToDelete.Clear();


    }

}
