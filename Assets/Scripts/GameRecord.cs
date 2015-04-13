using UnityEngine;
using System.Collections;

public class GameRecord : MonoBehaviour {
	int EasyWave;
	int NormalWave;
	int HardWave;
	int HellWave;
	GUISkin skin;
	// Use this for initialization
	void Start () {
		EasyWave = PlayerPrefs.GetInt ("easyWave",0);
		NormalWave = PlayerPrefs.GetInt ("normalWave",0);
		HardWave = PlayerPrefs.GetInt ("hardWave",0);
		HellWave = PlayerPrefs.GetInt ("hellWave",0);
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUIStyle style = new GUIStyle ();
		style.fontSize = 40;
		style.normal.textColor = Color.white;

		GUI.skin = skin;
		if (GUI.Button (new Rect(Screen.width-Screen.width/4,0,Screen.width/4,Screen.height/6),"Back")) {
			Application.LoadLevel("Menu");		
		}
		GUI.Label (new Rect(0,0,Screen.width/5,Screen.height/6),"Highest Wave Number",style);

		GUI.Label (new Rect(Screen.width/5,Screen.height/6*1,Screen.width/5,Screen.height/6),"Easy",style);
		GUI.Label (new Rect(Screen.width/5,Screen.height/6*2,Screen.width/5,Screen.height/6),""+EasyWave,style);

		GUI.Label (new Rect(Screen.width/5*3,Screen.height/6*1,Screen.width/5,Screen.height/6),"Normal",style);
		GUI.Label (new Rect(Screen.width/5*3,Screen.height/6*2,Screen.width/5,Screen.height/6),""+NormalWave,style);

		GUI.Label (new Rect(Screen.width/5,Screen.height/6*3,Screen.width/5,Screen.height/6),"Hard",style);
		GUI.Label (new Rect(Screen.width/5,Screen.height/6*4,Screen.width/5,Screen.height/6),""+HardWave,style);

		GUI.Label (new Rect(Screen.width/5*3,Screen.height/6*3,Screen.width/5,Screen.height/6),"Hell",style);
		GUI.Label (new Rect(Screen.width/5*3,Screen.height/6*4,Screen.width/5,Screen.height/6),""+HellWave,style);
	}

}
