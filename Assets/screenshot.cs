using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class screenshot : MonoBehaviour {

	public GameObject test;
	public Image Preview;
	public GameObject Pannel;
	public bool ispressGallery=false;
	public static string loadImagePath;
//	public Text point;
	public void click(){

		StartCoroutine( TakeScreenshotAndSave() );
	}

	public IEnumerator TakeScreenshotAndSave()
	{
		Debug.Log ("*********click***********");
		test.SetActive (false);

//
//		if(ApplicationModel.ACC.watermark_name !=""){
//
//			if(ApplicationModel.ACC.watermark_visibility=="1"){
//
//
//				watermark.SetActive (true);
//
//			}
//
//
//
//
//		}

		yield return new WaitForEndOfFrame();


		Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
		ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
		ss.Apply();

//		string overlaypath = Application.persistentDataPath+"/"+ApplicationModel.watermark;
//
//		if (File.Exists (overlaypath)) {
//
//			Texture2D tex = LoadTexture (overlaypath);
//
//			tex.Resize (100, 100);
//
//			ss=AddWatermark (ss,tex);
//		
//
//
//		}

		// Save the screenshot to Gallery/Photos
		//Debug.Log( "Permission result: " + NativeGallery.SaveImageToGallery( ss, "GalleryTest", "My img {0}.png" ) );
	
		NativeGallery.SaveImageToGallery (ss, "GalleryTest", "My img {0}.png");


		string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );

//		Texture2D MergedImage = AddWatermark (frame, ss);//---------------------->

		File.WriteAllBytes( filePath, ss.EncodeToPNG());//ss

		Texture2D tex = LoadTexture (Application.temporaryCachePath+"/shared img.png");



		Preview.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
		Preview.enabled = true;
		Pannel.SetActive (true);

		// To avoid memory leaks
		Destroy( ss );

		//new NativeShare().AddFile( filePath ).SetSubject( "Subject goes here" ).SetText( "Hello world!" ).Share();

		test.SetActive (true);

	}


	public void  ShareImage(){
		if (ispressGallery) {
			if (loadImagePath != null) {
				new NativeShare ().AddFile (loadImagePath).SetSubject ("Subject goes here").SetText ("Hello world!").Share ();
				ispressGallery = false;
			}
		} else {
			string filePath = Path.Combine (Application.temporaryCachePath, "shared img.png");
			new NativeShare ().AddFile (filePath).SetSubject ("Subject goes here").SetText ("Hello world!").Share ();
		}
		Pannel.SetActive (false);
	}

	public void Close(){
		
		Pannel.SetActive (false);


	
	}



	public Texture2D AddWatermark(Texture2D background, Texture2D watermark)
	{

		int startX = (background.width-10) - watermark.width;
		int startY = 10;

		for (int x = startX; x < background.width-10; x++)
		{

			for (int y = startY; y < watermark.height+10; y++)//texture.height
			{
				Color bgColor = background.GetPixel(x, y);
				Color wmColor = watermark.GetPixel(x - startX, y - startY);

				Color final_color = Color.Lerp(bgColor, wmColor, wmColor.a / 1.0f);

				background.SetPixel(x, y, final_color);

			}
		}

		background.Apply();
		return background;
	}

	public static Texture2D LoadTexture(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

		}
		return tex;
	}
	public void getScreenShorts(){
		PickImage (512);
	}
	private void PickImage( int maxSize )
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
			{
				Debug.Log( "Image path: " + path );
				if( path != null )
				{
					//					// Create Texture from selected image
					//					Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
					//					if( texture == null )
					//					{
					//						Debug.Log( "Couldn't load texture from " + path );
					//						return;
					//					}
					//
					//					// Assign texture to a temporary quad and destroy it after 5 seconds
					//					GameObject quad = GameObject.CreatePrimitive( PrimitiveType.Quad );
					//					quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
					//					quad.transform.forward = Camera.main.transform.forward;
					//					quad.transform.localScale = new Vector3( 1f, texture.height / (float) texture.width, 1f );
					//
					//					Material material = quad.GetComponent<Renderer>().material;
					//					if( !material.shader.isSupported ) // happens when Standard shader is not included in the build
					//						material.shader = Shader.Find( "Legacy Shaders/Diffuse" );
					//
					//					material.mainTexture = texture;

					Texture2D tex = LoadTexture (path);



					Preview.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
					Preview.enabled = true;
					Pannel.SetActive (true);

					loadImagePath=path;
					ispressGallery=true;

					//					Destroy( quad, 10f );

					// If a procedural texture is not destroyed manually, 
					// it will only be freed after a scene change
					//					Destroy( texture, 10f );
				}
			}, "Select a PNG image", "image/png", maxSize );

		Debug.Log( "Permission result: " + permission );
	}

}
