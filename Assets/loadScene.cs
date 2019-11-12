using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {
	public string nextScene;
    public bl_UMGManager xx;
    public static string nameWidow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void nextSceneload(){
        
        nameWidow=xx.m_CurrentWindow.name;
        SceneManager.LoadScene (nextScene);
	}
}
