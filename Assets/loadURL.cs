using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadURL : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clickUrl()
    {
        Application.OpenURL("https://www.liberal.org.au/");
    }
}
