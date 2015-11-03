using UnityEngine;
using System.Collections;

public class RTSPBackTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackTo(string targetScene) {
		Application.LoadLevel(targetScene);
	}
}
