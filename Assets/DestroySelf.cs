using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
    public float destroyTime;
	// Use this for initialization
	void Start () {
        Invoke("DestoySelfNow", destroyTime);
	}
	
	// Update is called once per frame
    void DestoySelfNow()
    {
        Destroy(gameObject);
    }
}
