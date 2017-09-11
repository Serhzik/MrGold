using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyPlayer : MonoBehaviour {
	VideoPlayer VP;
	AudioSource AS;
	public GameObject PlayButton;
	public string VideoURL;
	// Use this for initialization
	void Start () {
		
		VP = GetComponent<VideoPlayer> ();
		VP.targetTexture.Release ();
		AS = GetComponent<AudioSource> ();
		VP.url = YoutubeVideo.Instance.RequestVideo(VideoURL, 720);
		VP.EnableAudioTrack(0,true);
		VP.SetTargetAudioSource(0, AS);
	}

	public void Play(){
		VP.Play ();
		AS.Play ();
	}
	public void Stop(){
		VP.Stop ();
		AS.Stop ();
	}
	// Update is called once per frame
	void Update () {
		if (VP.isPlaying) {
			PlayButton.SetActive (false);
		} else {
			PlayButton.SetActive (true);
		}
	}
}
