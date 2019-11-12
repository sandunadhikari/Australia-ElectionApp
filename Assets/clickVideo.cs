using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickVideo : MonoBehaviour {
	public string url;
	public Text point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void clickvideoUrl(){
		Debug.Log ("hhhhhhhhhhhhhhhhhhhhhhh");
//		InAppBrowser.DisplayOptions options=new InAppBrowser.DisplayOptions();
//		InAppBrowser.OpenURL (url, options);
		point.text = "hhhhhhhhhhhhhhhhhhhhhhh";
	}
}
