using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JamGame;

public class Logo_Start : MonoBehaviour {

	bool isFadeout = false;
	public GameObject FadeoutMask;
	public GameObject Moto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space)){
			if (!isFadeout) {
				isFadeout = true;
				FadeoutMask.SetActive (true);
				Invoke ("NextStage",1.5f);

                SFXPlayerManager.getInstance.CreateSFX("addspeed");
			}
		}
		//
		if(isFadeout){
			Moto.transform.Translate (Vector3.right * Time.deltaTime * 0.85f);
		}
	}

	public void NextStage(){
        SceneManager.LoadScene("SampleScene");
	}
}
