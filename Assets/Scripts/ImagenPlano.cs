using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using waqashaxhmi.AndroidNativePlugin;
using System.IO;
using System;

public class ImagenPlano : MonoBehaviour
{


	//public RawImage image;
	// public 
	// Use this for initialization
	void Start()
	{

		AndroidNativeController.OnFileSelectSuccessEvent = OnSuccess;
		AndroidNativeController.OnFileSelectFailureEvent = OnFailure;
		AndroidNativeController.OnPositiveButtonPressEvent = (message) => {
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor)
			{
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#endif
			}
			else
			{
				Application.Quit();
			}
		};
		AndroidNativeController.OnNegativeButtonPressEvent = (message) => {
			// Code whatever you want on click "NO" Button.
		};

	}


	public void OnProgressBarButtonClick()
	{
		AndroidNativePluginLibrary.Instance.ShowProgressBar("Loading Data", "Loading . . .", true);
	}
	public void OnOpenGallaryButtonClick()
	{
		// after selecting file success OnSelectFile event fire
		AndroidNativePluginLibrary.Instance.OpenGallary();
	}

	private void OnSuccess(string path)
	{
		AndroidNativePluginLibrary.Instance.ShowToast("File Selected:" + path);
		StartCoroutine(ReadImage(path));

	}
	private void OnFailure(string err)
	{
		AndroidNativePluginLibrary.Instance.ShowToast(err);
	}
	IEnumerator ReadImage(string path)
	{
		WWW www = new WWW("file://" + path);
		yield return www;
		//image.texture = www.texture;

		GameObject plano = GameObject.Find("Plane");
		MeshRenderer mr = plano.GetComponent<MeshRenderer>();
		Material material = mr.material;

		material.SetTexture("_MainTex", www.texture);
	}

	IEnumerator DismissProgressBar()
	{
		yield return new WaitForSeconds(5f);
		AndroidNativePluginLibrary.Instance.DismissProgressBar();
	}
}
