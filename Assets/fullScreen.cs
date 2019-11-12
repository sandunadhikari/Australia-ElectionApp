using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullScreen : MonoBehaviour {
    public static string videoname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playFullScreen()
    {
        Debug.Log(videoname);

        //Handheld.PlayFullScreenMovie("file://"+Application.dataPath+"/Video/FlitAR.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        Handheld.PlayFullScreenMovie(videoname, Color.black, FullScreenMovieControlMode.Full);//------

    }
}
