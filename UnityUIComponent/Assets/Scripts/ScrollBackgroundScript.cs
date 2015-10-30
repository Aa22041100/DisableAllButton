using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public void ChangeColor(string hexString) {
		this.GetComponent<Image>().color = ConvertHexToColor(hexString);
	}

	private Color ConvertHexToColor(string src) {
		byte r = byte.Parse(src.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(src.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(src.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		byte a = byte.Parse(src.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32 (r, g, b, a);
	}

}
