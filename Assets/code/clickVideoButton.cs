using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickVideoButton : MonoBehaviour {
	public GameObject AudioPanel;
	public GameObject VideoPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click_Video(){
		VideoPanel.SetActive (true);
		AudioPanel.SetActive (false);
	}
}
