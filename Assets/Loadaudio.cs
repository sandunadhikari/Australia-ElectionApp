using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.Video;

public class Loadaudio : MonoBehaviour {
	
	public GameObject audioPanel;

	public Button AudioButton;
	public Image AudioIm;
	private bool vAudio;
	public AudioSource source;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
//	void Update()
//	{
//		if (vAudio) {
//			if (!source.isPlaying && source.clip.isReadyToPlay)
//				source.Play();
//		}
//
//	}
	public void ReadData(){
		audioPanel.SetActive(true);
		source.Play();
		vAudio=true;
//		StartCoroutine (AAStart());

	}

	public void videoPlayPause(){
		if (vAudio == true) {
			source.Pause ();
			AudioButton.GetComponent<Image> ().enabled = false;
			AudioIm.GetComponent<Image> ().enabled = true;
			vAudio = false;
		} else {
			source.Play ();
			AudioIm.GetComponent<Image> ().enabled = false;
			AudioButton.GetComponent<Image> ().enabled = true;
			vAudio = true;
		}
	}
	public void close(){
		audioPanel.SetActive(false);
	}
//	IEnumerator AAStart()
//	{
//		using (var www = new WWW(url))
//		{
//			yield return www;
//			source.clip = www.GetAudioClip();
//			vAudio=true;
//
//		}
//	}

}
