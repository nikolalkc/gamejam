using UnityEngine;
using System.Collections;

public class emptySphereDestruction : MonoBehaviour {
    StackController st;

    void Awake()
    {
        st = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
    }


   /* void OnCollisionEnter2D(Collision2D col)
    {
        //geting stuff
        GameObject parentSphere = gameObject.transform.parent.gameObject;
        int collidedObjectIndex = st.snakeStack.IndexOf(col.gameObject);
        int thisObjectIndex = st.snakeStack.IndexOf(parentSphere);
        print("collidedObjectIndex:" + collidedObjectIndex + " thisObjectIndex:" + thisObjectIndex);
      
        
        //doing stuff
        if (collidedObjectIndex > thisObjectIndex)  // da ne unistava emptySphere na hover sledeceg u nizu
        {
          st.snakeStack.Remove(parentSphere);
          Destroy(parentSphere);
        }
    }*/
	void Update() {
		RemoveSelf (); //if needed
	}


	void RemoveSelf() {
		//getting stuff
		if (StackController.firstStatic && StackController.lastDynamic) {
			int selfIndex = st.snakeStack.IndexOf (gameObject);
			int firstStaticIndex = st.snakeStack.IndexOf (StackController.firstStatic);
			int lastDynamicIndex = st.snakeStack.IndexOf (StackController.lastDynamic);
			float distanceFromStaticToDynamic;
			float uvFStatic = StackController.firstStatic.GetComponent<FollowMotionPath> ().uv;
			float uvLDynamic = StackController.lastDynamic.GetComponent<FollowMotionPath> ().uv;
			distanceFromStaticToDynamic = uvFStatic - uvLDynamic;

			//doing stuff
			if (selfIndex < lastDynamicIndex && selfIndex > firstStaticIndex && distanceFromStaticToDynamic <= snakeElementControl.deltaVirusDistance) {
				st.snakeStack.Remove (gameObject);
				Destroy (gameObject);	
			}
		}


	}
}
