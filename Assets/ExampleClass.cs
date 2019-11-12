using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
	public string url;
	public AudioSource source;
	public bool isclick=false;
	public void clickAudio(){
		Debug.Log (isclick);
		StartCoroutine (AAStart());


	}
	IEnumerator AAStart()
	{
		source = GetComponent<AudioSource>();
		using (var www = new WWW(url))
		{
			yield return www;
			source.clip = www.GetAudioClip();
			isclick = true;
			Debug.Log (isclick);
		}
	}

	void Update()
	{
		if (isclick) {
			if (!source.isPlaying && source.clip.isReadyToPlay)
				source.Play();
		}

	}
}
