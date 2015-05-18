using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {
    public Material red;
    public Material green;
    public Material blue;
	public float randomColor;
	// Use this for initialization
	void Start () {
        Renderer mat = gameObject.GetComponent<Renderer>();

        randomColor = Random.Range(1f, 3f);
        randomColor = Mathf.RoundToInt(randomColor);
      //  print(randomColor);
        if (randomColor == 1)
        {
            mat.material = red;
        }
        if (randomColor == 2)
        {
            mat.material = blue;
        }
        if (randomColor == 3)
        {
            mat.material = green;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
