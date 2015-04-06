using UnityEngine;
using System.Collections;

public class LevelMenu : MonoBehaviour {
	private GUISkin skin;
	// Use this for initialization
	void Start () {
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		GUI.skin = skin;
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*1,Screen.width/3,Screen.height/10),"Easy"))
		{
			Application.LoadLevel("EasyStage"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*3,Screen.width/3,Screen.height/10),"Normal"))
		{
			Application.LoadLevel("NormalStage"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*5,Screen.width/3,Screen.height/10),"Hard"))
		{
			Application.LoadLevel("HardStage"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*7,Screen.width/3,Screen.height/10),"What the ????"))
		{
			Application.LoadLevel("HellStage");
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*9,Screen.width/3,Screen.height/10),"Back"))
		{
			Application.LoadLevel("Menu");
		}
	}
}
