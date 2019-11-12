using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.Video;

public class LoadData : MonoBehaviour {
	
	public VideoPlayer videoPlayer;
	public GameObject videoPanel;
	public static int k = 0;
	public Slider Vidslider;
	public Button VideoButton;
	public Image VideoIm;
	private bool vPlay;
	private bool vAudio;
	public AudioSource videoAudio;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if(k>0){
			if (videoPlayer.frameCount > 0) {
				Vidslider.value=(float)videoPlayer.frame / (float)videoPlayer.frameCount;

			}
		}

	}
	public void ReadData(){
		videoPanel.SetActive(true);
		videoPlayer.Play();
		videoAudio.Play();
		vPlay=true;
		vAudio=true;
		k=1;


	}

	public void videoPlayPause(){
		if (vPlay == true) {
			videoPlayer.Pause ();
			VideoButton.GetComponent<Image> ().enabled = false;
			VideoIm.GetComponent<Image> ().enabled = true;
			vPlay = false;
		} else {
			videoPlayer.Play ();
			VideoIm.GetComponent<Image> ().enabled = false;
			VideoButton.GetComponent<Image> ().enabled = true;
			vPlay = true;
		}
	}
	public void close(){
		videoPanel.SetActive(false);
	}

}
