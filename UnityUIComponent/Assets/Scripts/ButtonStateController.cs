using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonStateController : MonoBehaviour {

	public GameObject TargetButton;
	private Animator animator;

	public GameObject SelectPanel;
	private Animator selectPanelAnimator;

	public bool isClicked = false;
	public bool isDisable = false;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		if(this.tag == "StartPanelUI") {
			selectPanelAnimator = SelectPanel.GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if(this.tag == "StartPanelUI") {
//			transform.Rotate (new Vector3 (0, 0, transform.rotation.z + Time.deltaTime * 100));
//		}
	}

	public void TriggerSelectPanel () {
		if(!isDisable) {
			if (!isClicked) {
				isClicked = true;
				animator.SetBool ("isSelected", isClicked);
				selectPanelAnimator.SetBool("IsShow", true);
			} else {
				isClicked = false;
				animator.SetBool ("isSelected", isClicked);
				selectPanelAnimator.SetBool("IsShow", false);
			}
		}
//		Debug.Log ("Clicked");
	}

	public void TriggerMusicButton() {
		if(!isDisable) {
			if (!isClicked) {
				isClicked = true;
				animator.SetBool ("isSelected", isClicked);
			} else {
				isClicked = false;
				animator.SetBool ("isSelected", isClicked);
			}
		}
	}

	public void TriggerDisable() {
		if(!isDisable) {
			isDisable = true;
			animator.SetBool ("isDisable", isDisable);
		} else {
			isDisable = false;
			animator.SetBool ("isDisable", isDisable);
		}
	}

	public void SetIsHighlight(bool target) {
		animator.SetBool ("isHighlight", target);
	}
}
