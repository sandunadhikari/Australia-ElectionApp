using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class selectimage : MonoBehaviour {

    public Sprite[] spriteList;
    public Image imageSource;
	// Use this for initialization
	void Start () {
        if(loadScene.nameWidow== "TonyAbbott")
        {
            imageSource.sprite = spriteList[0];
        }else if(loadScene.nameWidow == "LindaBurney")
        {
            imageSource.sprite = spriteList[1];
        }else
        {
            imageSource.sprite = spriteList[2];
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
