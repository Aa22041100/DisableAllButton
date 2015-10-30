using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public AnimationCreator[] anims;

	public Color ButtonSkin = new Color (17, 170, 255);

	public Animator TestCustomSlider;
	public Animator SubPanel;

	public static float DumpDepth = 4;
	public static float MaxShadowDepth = 10;
	public static float ShadowDepth = 8;

	public GameObject[] backGroundObjects;
	public GameObject[] textObjects;
	public GameObject[] imageObjects;
	public GameObject[] textboxTextObjects;

	// Init UI States


	// Testing for DYNAMIC UI global setting
	public static string TestingBtnTag = "TestingButton";


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;

		GameObject[] gos = GameObject.FindGameObjectsWithTag("Fake3DUIComponent");

		anims = new AnimationCreator[gos.Length];
		for(int i = 0 ; i < gos.Length ; i++) {
			anims[i] = gos[i].GetComponent<AnimationCreator>();
		}

		foreach(AnimationCreator anim in anims) {
			anim.SetDumpDepth(DumpDepth);
			anim.SetShadowDepth(ShadowDepth);
		}

		backGroundObjects = GameObject.FindGameObjectsWithTag("ContentBackground");
		textObjects = GameObject.FindGameObjectsWithTag("ContentText");
		imageObjects = GameObject.FindGameObjectsWithTag("ContentImage");
		textboxTextObjects = GameObject.FindGameObjectsWithTag("TextboxText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TriggerCustomSlider() {
		bool isOn = TestCustomSlider.GetBool("isOn");
		TestCustomSlider.SetBool ("isOn", !isOn);
	}

	public void ShowSubPanel() {
		bool isShow = SubPanel.GetBool("isShow");
		SubPanel.SetBool("isShow", !isShow);
	}

	public void ReloadScene() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void ShowMessage() {
		Debug.Log("SHHHSHSHS");
	}

	public void GoToScene(string sceneName) {
		Application.LoadLevel(sceneName);
	}

	public void ChangeColor(string hexString) {
		Color targetColor = ConvertHexToColor(hexString);
		foreach(GameObject go in backGroundObjects) {
			go.GetComponent<Image>().color = targetColor;
		}
	}

	public void ChangeContentColor(string hexString) {
		Color targetColor = ConvertHexToColor(hexString);
		foreach(GameObject go in textObjects) {
			go.GetComponent<Text>().color = targetColor;
		}

		foreach(GameObject go in imageObjects) {
			go.GetComponent<Image>().color = targetColor;
		}
	}

	public void ChangeTextboxTextColor(string hexString) {
		Color targetColor = ConvertHexToColor(hexString);
		foreach (GameObject go in textboxTextObjects) {
			go.GetComponent<Text>().color = targetColor;
		}
	}

	private Color ConvertHexToColor(string src) {
		byte r = byte.Parse(src.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(src.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(src.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		byte a = byte.Parse(src.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32 (r, g, b, a);
	}

}
