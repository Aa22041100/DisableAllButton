using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdsCtrl : MonoBehaviour {

	public MediaPlayerCtrl VideoManager;

	public string[] adsYouTubeLink;

	private string phpUrl = "http://www.badeggstudio.com/scripting/youtube.php?videoList=";

	public List<string> PlayList;

	void Awake() {
		PlayList = new List<string>();
		if(adsYouTubeLink.Length != 0) {
			for(int i = 0; i < adsYouTubeLink.Length; i++) {
				if(i == adsYouTubeLink.Length - 1) {
					phpUrl += adsYouTubeLink[i];
				} else {
					phpUrl += adsYouTubeLink[i] + ",";
				}
			}
		}
		WWW request = new WWW(phpUrl);
		StartCoroutine(WaitForRequest(request));
		VideoManager.OnEnd = new MediaPlayerCtrl.VideoEnd(OnVideoEnd);
		VideoManager.OnReady = new MediaPlayerCtrl.VideoReady(OnVideoReady);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnVideoEnd (){
		VideoManager.Load(this.PlayList[RandPlayList()]);
		VideoManager.Play();
	}

	void OnVideoReady() {
		VideoManager.Play();
	}

	void SplitUrl(string videoUrls) {
		string[] videoUrl = videoUrls.Split(","[0]);
//		this.playList = videoUrl;

		// First Play to Setup
		foreach(string tempUrl in videoUrl) {
			WWW redirectedRequest = new WWW(tempUrl);
			StartCoroutine(CheckRedirect(redirectedRequest));
		}

		// Add non redirect url into playlist

		// Load to video manager

		// Play video
	}
	bool Inited = false;
	void AddToPlaylist(string url) {
		this.PlayList.Add(url);
		if(!Inited)
			PlayVideo();
	}

	void PlayVideo() {
		Inited = true;
		VideoManager.Load (this.PlayList[0]);
		VideoManager.Play();
	}

	int RandPlayList() {
		return Random.Range(0, this.PlayList.Count - 1);
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			SplitUrl(www.text);
			if(www.responseHeaders.Count > 0) {
				foreach(KeyValuePair<string, string> entry in www.responseHeaders) {
					Debug.Log(entry.Value + "=" + entry.Key);
				}
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	IEnumerator CheckRedirect(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			// Debug Usage
			/*
			if(www.responseHeaders.Count > 0) {
				foreach(KeyValuePair<string, string> entry in www.responseHeaders) {
					Debug.Log(entry.Value + "=" + entry.Key);
				}
			}
			*/
			if(www.responseHeaders["STATUS"].Contains("200")) { 
				AddToPlaylist(www.url);
			} else {
				yield return StartCoroutine(CheckRedirect(new WWW(www.responseHeaders["LOCATION"])));
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	
}
