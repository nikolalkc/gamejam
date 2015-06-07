using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpawnCubes : MonoBehaviour {
    public GameObject cube;
	public Text text;
	float spawnSpeed = game.globalSpawnSpeed;
	List<int> currentGenerationChain;

	#region randomVirusVariables
		int chanceA_Min = 1;
		int chanceA_Max = 5;
		int chanceB_Min = 6;
		int chanceB_Max = 25;
		int chanceC_Min = 26;
		int chanceC_Max = 40;
		int chanceD_Min = 41;
		int chanceD_Max = 100;

		int VirusTypes = 5;
	#endregion


	void Awake () {
		Invoke("SpawnCube", spawnSpeed);
	}

    void SpawnCube()
    {
		GameObject nextVirus = Instantiate(cube)as GameObject;

		ElementType e = nextVirus.GetComponent<ElementType> ();
		e.typeOverride = 4;
		Invoke ("SpawnCube", spawnSpeed);


    }

	#region RandomVirusGeneration

	void CreateNewStackChain () {
		int stackChain = Random.Range (1, 100);
		if (stackChain >= chanceA_Min && stackChain <= chanceA_Max) {
			CreateLongChain();
		}
		if (stackChain >= chanceB_Min && stackChain <= chanceB_Max) {
			CreateSmallChain();	
		}
		if (stackChain >= chanceC_Min && stackChain <= chanceC_Max) {
			CreateDoubleVirus();
		}
		if (stackChain >= chanceD_Min && stackChain <= chanceD_Max) {
			CreateTwoSingleVirus();
		}
	}

	void GenerateNextVirus() {

	}

	void CreateSmallChain() {
		int chainLength = Random.Range (2, 3);
		int icon = Random.Range (1, VirusTypes);

		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		}
	}

	void CreateLongChain() {
		int chainLength = Random.Range (3, 5);
		int icon = Random.Range (1, VirusTypes);
		
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		} 
	}

	void CreateTwoSingleVirus() {
		int chainLength = 2;
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			int icon = Random.Range (1, VirusTypes);
			currentGenerationChain.Add(icon);
		} 


	}

	void CreateDoubleVirus() {
		int chainLength = 2;
		int icon = Random.Range (1, VirusTypes);	
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		} 
	}

	#endregion







}
