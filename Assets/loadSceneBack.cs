using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneBack : MonoBehaviour {
	public string nextScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void nextSceneload(){
		SceneManager.LoadScene (nextScene);
		bl_UMGManager.isback = true;
	}
}
