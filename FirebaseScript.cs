using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

using UnityEngine.SceneManagement;

public class FirebaseScript : MonoBehaviour {


	public  InputField email, password;

	public void LoginButtonPressed(){

		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text,password.text).
			ContinueWith((obj) =>
			{
	//			SceneManager.LoadSceneAsync("LoggedInScene");
			});
	}

	public void LoginAnonymousButtonPressed(){


        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().
                    ContinueWith((obj) => {
    //        SceneManager.LoadSceneAsync("LoggedInAnonScene");
        });

		
	}

	public void CreateNewUserButtonPressed(){

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email.text, password.text).
                    ContinueWith((obj) =>
                    {
      //                  SceneManager.LoadSceneAsync("LoggedInScene");

                    });
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
