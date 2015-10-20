using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {


	// Init UI Components here
	public AnimationCreator[] anims;

	public Color ButtonSkin = new Color (17, 170, 255);

	public AnimationCreator TestButton;
	public AnimationCreator TestButton3;

	public AnimationCreator OptionButton;
	public AnimationCreator SoundButton;
	public AnimationCreator LeaderBoardButton;

	public Animator TestCustomSlider;
	public Animator SubPanel;

	public float DumpDepth = 4;
	public float ShadowDepth = 6;

	// Init UI States


	// Testing for DYNAMIC UI global setting
	public static string TestingBtnTag = "TestingButton";


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		foreach(AnimationCreator anim in anims) {
			anim.SetDumpDepth(DumpDepth);
			anim.SetShadowDepth(ShadowDepth);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TestButtonIsClicked() {
		if(!TestButton.IsClicked()) {
			TestButton.GetAnimation().Blend("ClickedClip", 0.1f, 0.05f);
			TestButton.SetClicked(true);
		} else {
			TestButton.GetAnimation().Blend ("UnclickedClip", 0.1f, 0.05f);
			TestButton.SetClicked(false);
		}
	}
	
	public void TestButton3IsClicked()  {
		// TestButton3.Play("ClickedClip");
		if(!TestButton3.IsClicked()) {
			TestButton3.GetAnimation().Blend("ClickedClip", 0.1f, 0.05f);
//			TestButton3.GetAnimation ().PlayQueued("ClickedClip", QueueMode.PlayNow);
			TestButton3.SetClicked(true);
		} else {
			TestButton3.GetAnimation().Blend ("UnclickedClip", 0.1f, 0.05f);
//			TestButton3.GetAnimation().PlayQueued("UnclickedClip", QueueMode.PlayNow);
			TestButton3.SetClicked(false);
		}
//		Debug.Log (TestButton3 .IsClicked() + ", ");
	}

	public void OptionButtonIsClicked() {
		if(!OptionButton.IsClicked()) {
			OptionButton.GetAnimation().Blend ("ClickedClip", 0.1f, 0.05f);
			OptionButton.SetClicked(true);
		} else {
			OptionButton.GetAnimation().Blend ("UnclickedClip", 0.1f, 0.05f);
			OptionButton.SetClicked(false);
		}
	}

	public void SoundButtonIsClicked() {
		if(!SoundButton.IsClicked()) {
			SoundButton.GetAnimation ().Blend("ClickedClip", 0.1f, 0.05f);
			SoundButton.SetClicked(true);
		} else {
			SoundButton.GetAnimation().Blend ("UnclickedClip", 0.1f, 0.05f);
			SoundButton.SetClicked(false);
		}
	}

	public void LeaderBoardIsClicked() {
		if(!LeaderBoardButton.IsClicked()) {
			LeaderBoardButton.GetAnimation().Blend("ClickedClip", 0.1f, 0.05f);
			LeaderBoardButton.SetClicked(true);
		} else {
			LeaderBoardButton.GetAnimation().Blend ("UnclickedClip", 0.1f, 0.05f);
			LeaderBoardButton.SetClicked(false);
		}
	}

	public void TestButtonIsHighlighted(bool isHighlighted) {
//		bool isHighlighted = TestButton.GetBool("isHighlight");
//		TestButton.SetBool("isHighlight", isHighlighted);
	}

	public void TestButton3IsHighlighted(bool isHighlighted) {
		if(isHighlighted) {
			// TestButton3.Play("HighlightedClip");
		} else {
			// TestButton3.Play("Idle");
		}
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

}
