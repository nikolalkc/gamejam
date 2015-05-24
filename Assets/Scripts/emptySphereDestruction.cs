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
        GameObject parentSphere = gameObject.transform.parent.gameObject;
        print(parentSphere.name);
        st.snakeStack.Remove(parentSphere);
        Destroy(parentSphere);
    }
}
