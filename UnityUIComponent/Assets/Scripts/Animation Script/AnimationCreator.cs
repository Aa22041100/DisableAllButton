using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class AnimationCreator : MonoBehaviour {

	public Animation anim;

	public RectTransform ChildBGRectTransform;

	public float DumpEffectDepth;
	public float ShadowDepth;

	public bool clicked = false;

	public bool isToggle = true;
	public bool isButton = false;
	public bool isPanel = false;
	public bool isTextbox = false;

	// Use this for initialization
	void Start () {

		ShadowDepth = UIManager.ShadowDepth;
		DumpEffectDepth = UIManager.DumpDepth;

		CreateCommonAnimation();

		if(isToggle) CreateToggleAnimation();
		if(isButton) CreateButtonAnimaton();

		foreach(AnimationState state in anim) {
			state.speed = 200f;
		}
//		anim.Play("Awake");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateCommonAnimation() {
		Vector2 startingPos = GetComponent<RectTransform>().anchoredPosition;
		anim = GetComponent<Animation>();
		AnimationClip clip = new AnimationClip();
		clip.name = "Awake";
		clip.legacy = true;
		clip.frameRate = 60;
		/*
		// Scale from 0 -> 1.2(150f) -> 1(150f)
		clip.SetCurve("", typeof(RectTransform), "m_LocalScale.x",
		              new AnimationCurve(
						// Start from scale x 0
						new Keyframe(0, 0, 0, 0),
						// Scale to 1.2
						new Keyframe(100f, 1.2f, 0, 0),
						// back to normal
						new Keyframe(150f, 1f, 0, 0)
			));

		clip.SetCurve("", typeof(RectTransform), "m_LocalScale.y",
		              new AnimationCurve(
						// Start from scale y 0
						new Keyframe(0, 0, 0, 0),
						// Scale to 1.2
						new Keyframe(100f, 1.2f, 0, 0),
						// back to normal
						new Keyframe(150f, 1f, 0, 0)
			));

		clip.SetCurve("", typeof(RectTransform), "m_LocalScale.z",
		              new AnimationCurve(
						// Start from scale y 0
						new Keyframe(0, 0, 0, 0),
						// Scale to 1.2
						new Keyframe(100f, 1.2f, 0, 0),
						// back to normal
						new Keyframe(150f, 1f, 0, 0)
			));
		*/
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x", 
		              new AnimationCurve(
			// Start from Starting Pos X
			new Keyframe(0, startingPos.x, 0, 0),
			new Keyframe(150f, startingPos.x, 0, 0),
			// Dump effect
			new Keyframe(200f, startingPos.x - DumpEffectDepth, 0, 0),
			// Apply Shadow Depth to Starting Pos X
			new Keyframe(250f, startingPos.x + ShadowDepth, 0, 0),
			// Top Dump Effect
			new Keyframe(275f, startingPos.x + ShadowDepth - DumpEffectDepth/2, 0, 0),
			// Back To Shadow Depth + Starting pos x
			new Keyframe(300f, startingPos.x + ShadowDepth, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
			// Start from Starting Pos Y
			new Keyframe(0, startingPos.y, 0, 0),
			new Keyframe(150f, startingPos.y, 0 , 0),
			// Dump effect
			new Keyframe(200f, startingPos.y - DumpEffectDepth, 0, 0),
			// Apply Shadow Depth to Starting Pos Y
			new Keyframe(250f, startingPos.y + ShadowDepth, 0, 0),
			// Top Dump Effect
			new Keyframe(275f, startingPos.y + ShadowDepth - DumpEffectDepth/2, 0, 0),
			// Back to shadow depath + starting pos y
			new Keyframe(300f, startingPos.y + ShadowDepth, 0, 0)
			));
		anim.AddClip(clip, clip.name);
		anim.Play(clip.name);
		
		clip = new AnimationClip();
		clip.name = "Idle";
		clip.legacy = true;
		clip.frameRate = 12;
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
			// Stay at current point
			new Keyframe(0, startingPos.x + ShadowDepth, 0, 0),
			// Dump effect
			new Keyframe(50f, startingPos.x - DumpEffectDepth, 0, 0),
			// Back to idle pos x
			new Keyframe(100f, startingPos.x + ShadowDepth, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
			// Stay at current point
			new Keyframe(0, startingPos.y + ShadowDepth, 0, 0),
			// Dump Effect
			new Keyframe(50f, startingPos.y - DumpEffectDepth, 0, 0),
			// Back to idle pos y
			new Keyframe(100f, startingPos.y + ShadowDepth, 0, 0)
			));
		
		anim.AddClip(clip, clip.name);
	}

	void CreateToggleAnimation() {
		Vector2 startingPos = GetComponent<RectTransform>().anchoredPosition;
		anim = GetComponent<Animation>();
		AnimationClip clip = new AnimationClip();

		clip = new AnimationClip();
		clip.name = "ClickedClip";
		clip.legacy = true;
		clip.frameRate = 60;
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
			// Start from current point
			new Keyframe(0, startingPos.x + ShadowDepth, 0, 0),
			// Dump Effect
			new Keyframe(25f, startingPos.x - DumpEffectDepth, 0, 0),
			// Back to starting pos x
			new Keyframe(60f, startingPos.x, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
			// Start from current point
			new Keyframe(0, startingPos.y + ShadowDepth, 0, 0),
			// Dump effect
			new Keyframe(25f, startingPos.y - DumpEffectDepth, 0, 0),
			// Back to starting pos y
			new Keyframe(60f, startingPos.y, 0, 0)
			));
		anim.AddClip(clip, clip.name);
		
		clip = new AnimationClip();
		clip.name = "UnclickedClip";
		clip.legacy = true;
		clip.frameRate = 60;
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
			// Start from starting pos x
			new Keyframe(0, startingPos.x, 0 , 0),
			// Back to shadowed point
			new Keyframe(25f, startingPos.x - DumpEffectDepth, 0, 0),
			// Dump effect
			//						new Keyframe(50f, startingPos.x + ShadowDepth - DumpEffectDepth/5, 0, 0),
			// Back to shadowed point
			new Keyframe(50f, startingPos.x + ShadowDepth, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
			// Start from starting pos y
			new Keyframe(0, startingPos.y, 0, 0),
			// Back to shadowed point
			new Keyframe(25f, startingPos.y - DumpEffectDepth, 0, 0),
			// Dump effect
			//						new Keyframe(50f, startingPos.y + ShadowDepth - DumpEffectDepth/5, 0, 0),
			// Back to shadowed point
			new Keyframe(50f, startingPos.y + ShadowDepth, 0, 0)
			));
		anim.AddClip(clip, clip.name);
	}

	void CreateButtonAnimaton () {
		Vector2 startingPos = GetComponent<RectTransform>().anchoredPosition;
		anim = GetComponent<Animation>();
		AnimationClip clip = new AnimationClip();
		
		clip = new AnimationClip();
		clip.name = "OnclickClip";
		clip.legacy = true;
		clip.frameRate = 60;
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
			// Start from current point
			new Keyframe(0, startingPos.x + ShadowDepth, 0, 0),
			// Dump Effect
			new Keyframe(25f, startingPos.x - DumpEffectDepth, 0, 0),
			// Back to starting pos x
			new Keyframe(60f, startingPos.x + ShadowDepth, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
			// Start from current point
			new Keyframe(0, startingPos.y + ShadowDepth, 0, 0),
			// Dump effect
			new Keyframe(25f, startingPos.y - DumpEffectDepth, 0, 0),
			// Back to starting pos y
			new Keyframe(60f, startingPos.y + ShadowDepth, 0, 0)
			));
		anim.AddClip(clip, clip.name);
	}
	
	public bool IsClicked() {
		return clicked;
	}
	
	public void SetClicked(bool clicked) {
		this.clicked = clicked;
	}
	
	public Animation GetAnimation() {
		return anim;
	}

	public void SetDumpDepth(float dumpDepth) {
		this.DumpEffectDepth = dumpDepth;
	}

	public void SetShadowDepth(float shadowDepth) {
		this.ShadowDepth = shadowDepth;
	}

	public void InvokeAnimation() {
		if(isToggle) {
			if(!clicked) {
				this.GetAnimation().Blend("ClickedClip", 0.1f, 0.05f);
				clicked = true;
			} else {
				this.GetAnimation().Blend("UnclickedClip", 0.1f, 0.05f);
				clicked = false;
			}
		} else if(isButton) {
			this.GetAnimation().Blend ("OnclickClip", 0.1f, 0.5f);
		} else if(isPanel) {
			// do nothing
		} else if(isTextbox) {
			// do nothing
		}
	}

}
