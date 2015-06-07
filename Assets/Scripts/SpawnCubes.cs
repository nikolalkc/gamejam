using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpawnCubes : MonoBehaviour {
    public GameObject cube;
	public Text text;
	float spawnSpeed = game.globalSpawnSpeed;
	public List<int> currentGenerationChain;

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
		int generationCounter = 0;
	#endregion


	void Awake () {
		CreateNewStackChain ();
		Invoke ("GenerateNextVirus", spawnSpeed);
	}

    void SpawnCube(int sendType)
    {
		GameObject nextVirus = Instantiate(cube)as GameObject;
		ElementType e = nextVirus.GetComponent<ElementType> ();
		e.typeOverride = sendType;
		Invoke ("GenerateNextVirus", spawnSpeed);
    }

	void SpawnCube() {
		Instantiate (cube);
		Invoke ("SpawnCube", spawnSpeed);
	}

	#region RandomVirusGeneration

	void CreateNewStackChain () {
		//print ("createNewstackChain");
		int stackChain = Random.Range (1, 100+1);
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
		//def
		int count;
		int sendType;

		//provera duzine liste
		if (currentGenerationChain.Count > 0) {
			count = currentGenerationChain.Count;
		} else {
			count = 0;
		}

		//provera dal treba novi chain da se generise
		if (generationCounter >= count) {
			generationCounter = 0;
			CreateNewStackChain();

		}
		//generisanje elementa
		sendType = currentGenerationChain [generationCounter];	
		SpawnCube (sendType);
		generationCounter++;


	}

	void CreateSmallChain() {

		int chainLength = Random.Range (2, 3+1);
		int icon = Random.Range (1, VirusTypes+1);
		print ("CreateSmallChain:" + " Lenth:" + chainLength + " Icon:" + icon);
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		}
		print ("============================");
	}

	void CreateLongChain() {
		int chainLength = Random.Range (3, 5+1);
		int icon = Random.Range (1, VirusTypes+1);

		print ("createLongChain:"+ " Lenth:" + chainLength + " Icon:" + icon);
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		} 
		print ("============================");
	}

	void CreateTwoSingleVirus() {

		int chainLength = 2;
		currentGenerationChain.Clear ();
		for (int i = 0; i < chainLength; i++) {
			int icon = Random.Range (1, VirusTypes+1);
			print ("createTwoSingleVirus"+ " Lenth:" + chainLength + " Icon:" + icon);
			currentGenerationChain.Add(icon);
		} 
		print ("============================");

	}

	void CreateDoubleVirus() {

		int chainLength = 2;
		int icon = Random.Range (1, VirusTypes+1);	
		currentGenerationChain.Clear ();
		print ("CreateDoubleVirus:"+ " Lenth:" + chainLength + " Icon:" + icon);
		for (int i = 0; i < chainLength; i++) {
			currentGenerationChain.Add(icon);
		} 
		print ("============================");
	}

	#endregion







}
