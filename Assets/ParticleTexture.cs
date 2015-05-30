using UnityEngine;
using System.Collections;

public class ParticleTexture : MonoBehaviour {
    public Texture icon_01;
    public Texture icon_02;
    public Texture icon_03;
    public Texture icon_04;
    public Texture icon_05;
    public Material particleMaterial;
    public int particleTexture;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeTexture(int index)
    {
        particleTexture = index;
        switch (particleTexture)
        {
            case 0:
                break;
            case 1:
                particleMaterial.SetTexture("_MainTex", icon_01);
                break;
            case 2:
                particleMaterial.SetTexture("_MainTex", icon_02);
                break;
            case 3:
                particleMaterial.SetTexture("_MainTex", icon_03);
                break;
            case 4:
                particleMaterial.SetTexture("_MainTex", icon_04);
                break;
            case 5:
                particleMaterial.SetTexture("_MainTex", icon_05);
                break;
        }
    }
}
