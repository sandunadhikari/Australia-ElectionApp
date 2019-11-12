using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRect : MonoBehaviour {
	RectTransform rectTransform;
	// Use this for initialization
	void Start () {
		 rectTransform = GetComponent<RectTransform>();
//		RectTransform rectTransform = GetComponent<RectTransform>();
//		rectTransform.Rotate( new Vector3( 0, 0, 0 ) );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void back(){
		Debug.Log ("Testback");
		rectTransform.Rotate( new Vector3( 0, 180, 0 ) );
	}
	public void front(){
		Debug.Log ("Testfront");
		rectTransform.Rotate( new Vector3( 0, 180, 0 ) );
	}
}
