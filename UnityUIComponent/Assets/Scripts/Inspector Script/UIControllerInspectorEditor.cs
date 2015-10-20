//using UnityEngine;
//using System.Collections;
//using UnityEditor;
//
//[CustomEditor(typeof(ButtonStateController))]
//public class UIControllerInspectorEditor : Editor {
//
//	ButtonStateController UIControllerScript;
//
//	public override void OnInspectorGUI ()
//	{
//		UIControllerScript = (ButtonStateController) target;
//
//		if (UIControllerScript.tag == "StartPanelUI") {
//			UIControllerScript.SelectPanel = (GameObject) EditorGUILayout.ObjectField("Select Panel", UIControllerScript.SelectPanel, typeof(GameObject), true);
//			UIControllerScript.isClicked = EditorGUILayout.Toggle("Is Clicked", UIControllerScript.isClicked);
//			UIControllerScript.isDisable = EditorGUILayout.Toggle ("Is Disable", UIControllerScript.isDisable);
//		}
//
//		if(UIControllerScript.tag == "SelectPanelUI") {
//
//		}
//		base.OnInspectorGUI ();
//	}
//
//}
