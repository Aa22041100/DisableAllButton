using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class AnimationCreator : MonoBehaviour {

	public Animation anim;

	public RectTransform ChildBGRectTransform;

	public float DumpEffectDepth = 0.5f;
	public float ShadowDepth = 8.5f;

	public bool clicked = false;

	// Use this for initialization
	void Start () {
		Vector2 startingPos = GetComponent<RectTransform>().anchoredPosition;
		anim = GetComponent<Animation>();
		AnimationClip clip = new AnimationClip();
		clip.name = "Awake";
		clip.legacy = true;
		clip.frameRate = 60;
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x", 
					  new AnimationCurve(
						// Start from Starting Pos X
						new Keyframe(0, startingPos.x, 0, 0),
						new Keyframe(100f, startingPos.x, 0, 0),
						// Dump effect
						new Keyframe(150f, startingPos.x - DumpEffectDepth, 0, 0),
						// Apply Shadow Depth to Starting Pos X
						new Keyframe(200f, startingPos.x + ShadowDepth, 0, 0)));
		     
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
						// Start from Starting Pos Y
						new Keyframe(0, startingPos.y, 0, 0),
						new Keyframe(100f, startingPos.y, 0 , 0),
						// Dump effect
						new Keyframe(150f, startingPos.y - DumpEffectDepth, 0, 0),
						// Apply Shadow Depth to Starting Pos Y
						new Keyframe(200f, startingPos.y + ShadowDepth, 0, 0)));
		anim.AddClip(clip, clip.name);
		anim.Play(clip.name);

		clip = new AnimationClip();
		clip.name = "Idle";
		clip.legacy = true;
		clip.frameRate = 12;
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
						// Stay at current point
						new Keyframe(0, startingPos.x + ShadowDepth, 0, 0)
			));

		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
						// Stay at current point
						new Keyframe(0, startingPos.y + ShadowDepth, 0, 0)
			));

		anim.AddClip(clip, clip.name);

		clip = new AnimationClip();
		clip.name = "ClickedClip";
		clip.legacy = true;
		clip.frameRate = 60;

		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.x",
		              new AnimationCurve(
						// Start from current point
						new Keyframe(0, startingPos.x + ShadowDepth, 0, 0),
						// Dump Effect
//						new Keyframe(0.06f, startingPos.x - DumpEffectDepth),
						// Back to starting pos x
						new Keyframe(10f, startingPos.x, 0, 0)
			));

		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
						// Start from current point
						new Keyframe(0, startingPos.y + ShadowDepth, 0, 0),
						// Dump effect
//						new Keyframe(0.06f, startingPos.y - DumpEffectDepth),
						// Back to starting pos y
						new Keyframe(10f, startingPos.y, 0, 0)
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
						// Dump Effect
//						new Keyframe(0.06f, startingPos.x - DumpEffectDepth),
						// Back to shadowed point
						new Keyframe(10f, startingPos.x + ShadowDepth, 0, 0)
			));
		
		clip.SetCurve("", typeof(RectTransform), "m_AnchoredPosition.y",
		              new AnimationCurve(
						// Start from starting pos y
						new Keyframe(0, startingPos.y, 0, 0),
						// Dump Effect
//						new Keyframe(0.06f, startingPos.y - DumpEffectDepth),
						// Back to shadowed point
						new Keyframe(10f, startingPos.y + ShadowDepth, 0, 0)
			));
		anim.AddClip(clip, clip.name);

		foreach(AnimationState state in anim) {
			state.speed = 200f;
		}
//		anim.Play("Awake");
	}
	
	// Update is called once per frame
	void Update () {
	
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

}
