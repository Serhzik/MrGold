using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {
	public Text Score;
	int score;
	public Image PrizePoolPanel, Opa;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score", 0);			
	}

	void Update(){
		Score.text = score.ToString ();
	}

	public void IncreaseScore(){
		score++;
		PlayerPrefs.SetInt ("Score", score);
		Opa.gameObject.SetActive (true);
	}

	public void HideOpa(){
		Opa.gameObject.SetActive (false);
	}

	public void ShowPrizePoolPanel (){
		PrizePoolPanel.gameObject.SetActive (true);
	}

	public void HidePrizePoolPanel (){
		PrizePoolPanel.gameObject.SetActive (false);
	}

	public void Help(){
		SceneManager.LoadScene ("Main");
	}
}
