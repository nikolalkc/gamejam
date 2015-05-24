using UnityEngine;
using System.Collections;

public class emptySphere : MonoBehaviour {
    StackController st;
	// Use this for initialization
	void Start () {
        st = GameObject.FindGameObjectWithTag("stackControl").GetComponent<StackController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        st.snakeStack.Remove(gameObject);
        Destroy(gameObject);
    }
}

