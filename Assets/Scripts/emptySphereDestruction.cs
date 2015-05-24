using UnityEngine;
using System.Collections;

public class emptySphereDestruction : MonoBehaviour {
    StackController st;

    void Awake()
    {
        st = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
    }


    void OnCollisionEnter(Collision col)
    {
        //geting stuff
        GameObject parentSphere = gameObject.transform.parent.gameObject;
        int collidedObjectIndex = st.snakeStack.IndexOf(col.gameObject);
        int thisObjectIndex = st.snakeStack.IndexOf(parentSphere);
        //print("collidedObjectIndex:" + collidedObjectIndex + " thisObjectIndex:" + thisObjectIndex);
      
        
        //doing stuff
        if (collidedObjectIndex > thisObjectIndex)  // da ne unistava emptySphere na hover sledeceg u nizu
        {
            st.snakeStack.Remove(parentSphere);
            Destroy(parentSphere);
        }
    }
}
