using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	public MyPlayer myPlayer;

	public void OnButton(){
		myPlayer.Stop ();
		SceneManager.LoadScene ("Ads");
	}
}
