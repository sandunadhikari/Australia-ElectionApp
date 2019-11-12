using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAudioButton : MonoBehaviour {

	public GameObject AudioPanel;
	public GameObject VideoPanel;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void Click_Audio(){
		AudioPanel.SetActive (true);
		VideoPanel.SetActive (false);

	}
}
