using UnityEngine;
using System.Collections;

public class ResizeUI : MonoBehaviour {

	public float ButtonWidth;
	public float ButtonHeight;

	void Awake() {

		ButtonWidth = this.transform.Find("Base").gameObject.GetComponent<RectTransform>().rect.width;
		ButtonHeight = this.transform.Find("Base").gameObject.GetComponent<RectTransform>().rect.height;
		
		// Change Mask size
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth + UIManager.ShadowDepth, ButtonHeight + UIManager.ShadowDepth);
		
		// Chage Button size
		this.transform.Find ("Button").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth + UIManager.ShadowDepth, ButtonHeight + UIManager.ShadowDepth);
		
		// Change Button/Shadow size
		this.transform.Find("Button/Shadow").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth + UIManager.MaxShadowDepth, ButtonHeight + UIManager.MaxShadowDepth);
		
		// Change Button/BG
		this.transform.Find ("Button/BG").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ButtonWidth, ButtonHeight);
		
		// Move Button which hide the shadow image
		this.transform.Find ("Button").gameObject.GetComponent<RectTransform>().anchoredPosition  = new Vector2(0, 0);

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
