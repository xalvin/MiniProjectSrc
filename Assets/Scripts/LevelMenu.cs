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
			Application.LoadLevel("Easy"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*3,Screen.width/3,Screen.height/10),"Normal"))
		{
			Application.LoadLevel("Normal"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*5,Screen.width/3,Screen.height/10),"Hard"))
		{
			Application.LoadLevel("Hard"); 
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*7,Screen.width/3,Screen.height/10),"What the ????"))
		{
			Application.LoadLevel("Hell");
		}
		if (GUI.Button(new Rect(Screen.width/3,Screen.height/10*9,Screen.width/3,Screen.height/10),"Back"))
		{
			Application.LoadLevel("Menu");
		}
	}
}
