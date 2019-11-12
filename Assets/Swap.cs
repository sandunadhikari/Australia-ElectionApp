using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap : MonoBehaviour {
	private bool toggle = false;
	public GameObject ImageObj;
	// Use this for initialization
//	RS_Manager resMan;

	void Update(){
		
	}
	public void front(){
//		resMan = RS_Manager.Instance;
//
//		resMan.camswap = true;

		toggle = !toggle;

		if (toggle) {
//			resMan.ImageObj.transform.GetComponentInChildren<rotateRect> ().front ();
			ImageObj.transform.GetComponentInChildren<rotateRect>().front();
//			if(resMan.ImageObj!=null){
//				
//				Vector3 rmt = new Vector3 (0,180f,0);
//				resMan.camswap = true;
//
//
//
//			}
			RestartCamera (Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT, true);

		} else {
			ImageObj.transform.GetComponentInChildren<rotateRect> ().back ();

//			if(resMan.ImageObj!=null){
//				Vector3 rtm = new Vector3 (0,0,0);
//				resMan.camswap = false;
//
//
//
//			}
			RestartCamera (Vuforia.CameraDevice.CameraDirection.CAMERA_BACK, true);

		}
//
//		Vuforia.CameraDevice.CameraDirection currentDir = Vuforia.CameraDevice.Instance.GetCameraDirection();
//		if (currentDir == Vuforia.CameraDevice.CameraDirection.CAMERA_BACK || currentDir == Vuforia.CameraDevice.CameraDirection.CAMERA_DEFAULT)
//			RestartCamera (Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT, true);
//		else {
//			RestartCamera (Vuforia.CameraDevice.CameraDirection.CAMERA_BACK, false);
//		}
	}
	private void RestartCamera(Vuforia.CameraDevice.CameraDirection newDir, bool mirror){
		Vuforia.CameraDevice.Instance.Stop();
		Vuforia.CameraDevice.Instance.Deinit();

		Vuforia.CameraDevice.Instance.Init(newDir);
		Vuforia.CameraDevice.Instance.Start();

	}
}
