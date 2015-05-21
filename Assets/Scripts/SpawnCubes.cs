using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpawnCubes : MonoBehaviour {
    public GameObject cube;
	public Text text;
	float spawnSpeed = game.globalSpawnSpeed;
	// Use this for initialization
	void Awake () {
		Invoke("SpawnCube", spawnSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnCube()
    {
        Instantiate(cube);
		Invoke("SpawnCube", spawnSpeed);
//		text.text = "";
//		GameObject[] cubes = GameObject.FindGameObjectsWithTag("cube");
//		foreach ( GameObject g in cubes) {
//			text.text += g.name + "  ";
//		}
	

    }
}
