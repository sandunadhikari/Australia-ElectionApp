using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrowserOpenerAudio : MonoBehaviour {

	public string pageToOpen;
//	public GameObject g;
	void Start () {
//		StartCoroutine (LoadImage ());
	}

	// Update is called once per frame
	void Update () {

	}
//	IEnumerator LoadImage(){
//		Debug.Log ("sssssssssaaaaaaaaaaaaaa---------");
//		var items = pageToOpen.Split(new char[] { '='} );
//		WWW www = new WWW ("https://img.youtube.com/vi/"+items[1]+"/mqdefault.jpg");
//		yield return www;
//		g.GetComponentInChildren<RawImage>().texture=www.texture;
//	}
	// check readme file to find out how to change title, colors etc.
	public void OnButtonClicked() {
		InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
		options.displayURLAsPageTitle = false;
		//options.pageTitle = "InAppBrowser example";

		InAppBrowser.OpenURL(pageToOpen, options);
	}

	public void OnClearCacheClicked() {
		InAppBrowser.ClearCache();
	}
}
