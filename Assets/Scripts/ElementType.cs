﻿using UnityEngine;
using System.Collections;

public class ElementType : MonoBehaviour {
    int typeCount;
    public int type;
	public int typeOverride;
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
		if (typeOverride == 0) {
			type = Random.Range (1, 5+1);
		} else {
			type = typeOverride;
		}
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
