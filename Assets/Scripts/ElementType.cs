using UnityEngine;
using System.Collections;

public class ElementType : MonoBehaviour {
    int typeCount;
    public int type;
	// Use this for initialization
    void Start()
    {
        //print(gameObject.name);
        Transform[] childrenArray = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform t in childrenArray)
        {
            if (t.gameObject.tag == "icon")
            {
                typeCount++;
            }
        }
        //print(typeCount);
        type = Random.Range(1, 6);
        //print("type:" + type);
        foreach (Transform g in childrenArray)
        {
            string iconName = "icon_0" + type.ToString();
            if (g.gameObject.name == iconName) {
                //print(g.gameObject.name);
                SpriteRenderer r = g.gameObject.GetComponent<SpriteRenderer>();
                r.enabled = true;
            };
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
