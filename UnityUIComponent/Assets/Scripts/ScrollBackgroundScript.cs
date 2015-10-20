﻿using UnityEngine;
using System.Collections;

public class ScrollBackgroundScript : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
//		startPosition = transform.position;
		startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
//		transform.position = startPosition + Vector3.up * newPosition;
		transform.localPosition = startPosition + Vector3.up * newPosition;
	}
}
