using UnityEngine;
using System.Collections;

public class BackTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToScene(string sceneName) {
		Application.LoadLevel(sceneName);
	}
}
