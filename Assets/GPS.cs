using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO; 

public class GPS : MonoBehaviour {
	public static GPS Instance{ set; get; }
	public float timeInterval;
	public float timeWithoutInternet;
	float actualTime;
	float nowTime;
	public static string deviceModel;
	public float latitude;
	public float longitude;
	public static string productName;
	//public Text point;
	//public Text point2;
	//public Text point3;
	//public Text status;
	public static int nn=0;
	public static int checker = 0;
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
	private void Start () {
		Instance = this;

		timeInterval = 50.0f;
		actualTime = timeInterval;
		timeWithoutInternet = 20.0f;
		nowTime = timeWithoutInternet;
		StartCoroutine (StartLocationService ());
		
	}
	private IEnumerator StartLocationService (){
		//throw new NotImplementedException ();
		if(!Input.location.isEnabledByUser){
			Debug.Log ("User has not enabled GPS");
			yield break;
		}
		Input.location.Start ();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}
		if (maxWait <= 0) {
			Debug.Log ("Time out");
			yield break;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Unable to determin device location");
			yield break;
		}
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
		deviceModel = SystemInfo.deviceModel;
		productName = Application.productName;
		//point.text = "Lat:" + GPS.Instance.latitude.ToString ()+"Lon:" + GPS.Instance.longitude.ToString ()+"Name:"+deviceModel.ToString()+"ProductName:"+productName.ToString();
		StartCoroutine (getRequest());
		yield break;
	}
	// Update is called once per frame
	void Update()
	{
		actualTime -= Time.deltaTime; // subtract the time taken to render last frame
		if(actualTime <= 0) // if time runs out, do your update
		{
			// INSERT YOUR UPDATE CODE HERE
			Instance = this;
			StartCoroutine (StartLocationService ());
			actualTime = timeInterval; // reset the timer
		}
		if(Input.location.isEnabledByUser){
			if (nn == 0) {
				Instance = this;
				StartCoroutine (StartLocationService ());
				nn = 1;
			}
		}
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			nowTime -= Time.deltaTime;
			if(nowTime<=0){
				Save();
				nowTime = timeWithoutInternet;
				checker = 0;
			}

			//point3.text = "Network Not Available";

		} else {
			//point3.text = "Network Available";
			if (checker == 0) {
				Load ();
				checker = 1;
			}
		}
	}
	public void testCode(){
		StartCoroutine (getRequest());
	}
	IEnumerator getRequest(){
		WWWForm form = new WWWForm();
		form.AddField ("device_model", GPS.deviceModel.ToString());
		form.AddField ("latitude", GPS.Instance.latitude.ToString ());
		form.AddField ("longitude",GPS.Instance.longitude.ToString ());
		form.AddField ("app_name", GPS.productName.ToString());

		UnityWebRequest www = UnityWebRequest.Post ("http://54.160.176.108:8091/api/locations", form);
		yield return www.Send();
		if (www.isError)
		{
			//status.text = "www.error"+www.error.ToString ();
			Debug.Log("www.error");
		}
		else
		{
			Debug.Log (www.downloadHandler.ToString ());
			if (www.responseCode.ToString () == "201") {
				//status.text = "Regitered Successfuly";
				Debug.Log("Regitered Successfuly");

			}else if(www.responseCode.ToString () == "422"){
				//status.text = "Validation Error";
				Debug.Log("Validation Error");
			}else if(www.responseCode.ToString () == "500"){
				//status.text = "Server error";
				Debug.Log("Server error");
			}else{
				//status.text = "Failed to register";
				Debug.Log("Failed to register");
			}
		}
		
	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		data.Dlatitude = GPS.Instance.latitude;
		data.Dlongitude = GPS.Instance.longitude;

		bf.Serialize (file, data);
		file.Close ();


	}
	public void Load(){
		try{
			if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
				PlayerData data = (PlayerData)bf.Deserialize (file);
				file.Close ();

				latitude=data.Dlatitude;
				longitude=data.Dlongitude;

				Instance = this;
				StartCoroutine (StartLocationService ());

			}
		}catch(Exception e){
			//point2.text=e.ToString();
		}
	}
}
[Serializable]
class PlayerData{
	public float Dlatitude;
	public float Dlongitude;

}
