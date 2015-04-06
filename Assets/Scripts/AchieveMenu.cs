using UnityEngine;
using System.Collections;

public class AchieveMenu : MonoBehaviour {

	private int score = 10000000;
	private int menuState; //0 for weapon, 1 for skill, 2 for ability 
	private int weapon;
	private int skill;
	private int ability;
	private GUISkin skin;
	// Use this for initialization
	void Start () {
		//Load score from DB;
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DrawWeapon() {
		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*1,Screen.width/9,Screen.height/6),"1")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*2,Screen.width/9,Screen.height/6),"0");

		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*1,Screen.width/9,Screen.height/6),"2")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*2,Screen.width/9,Screen.height/6),"1000");

		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*1,Screen.width/9,Screen.height/6),"3")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*2,Screen.width/9,Screen.height/6),"2500");

		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*1,Screen.width/9,Screen.height/6),"4")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*2,Screen.width/9,Screen.height/6),"10000");

		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*4,Screen.width/9,Screen.height/6),"5")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*5,Screen.width/9,Screen.height/6),"25000");

		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*4,Screen.width/9,Screen.height/6),"6")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*5,Screen.width/9,Screen.height/6),"70000");

		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*4,Screen.width/9,Screen.height/6),"7")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*5,Screen.width/9,Screen.height/6),"100000");

		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*4,Screen.width/9,Screen.height/6),"8")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*5,Screen.width/9,Screen.height/6),"250000");
	}


	private void DrawSkill() {
		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*1,Screen.width/9,Screen.height/6),"a")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*2,Screen.width/9,Screen.height/6),"0");
		
		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*1,Screen.width/9,Screen.height/6),"b")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*2,Screen.width/9,Screen.height/6),"1000");
		
		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*1,Screen.width/9,Screen.height/6),"c")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*2,Screen.width/9,Screen.height/6),"2500");
		
		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*1,Screen.width/9,Screen.height/6),"d")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*2,Screen.width/9,Screen.height/6),"10000");
		
		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*4,Screen.width/9,Screen.height/6),"e")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*5,Screen.width/9,Screen.height/6),"25000");
		
		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*4,Screen.width/9,Screen.height/6),"f")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*5,Screen.width/9,Screen.height/6),"70000");
		
		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*4,Screen.width/9,Screen.height/6),"g")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*5,Screen.width/9,Screen.height/6),"100000");
		
		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*4,Screen.width/9,Screen.height/6),"h")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*5,Screen.width/9,Screen.height/6),"250000");
	}


	private void DrawAbility() {
		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*1,Screen.width/9,Screen.height/6),"A")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*2,Screen.width/9,Screen.height/6),"0");
		
		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*1,Screen.width/9,Screen.height/6),"B")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*2,Screen.width/9,Screen.height/6),"1000");
		
		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*1,Screen.width/9,Screen.height/6),"C")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*2,Screen.width/9,Screen.height/6),"2500");
		
		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*1,Screen.width/9,Screen.height/6),"D")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*2,Screen.width/9,Screen.height/6),"10000");
		
		if (GUI.Button (new Rect(Screen.width/9*1,Screen.height/6*4,Screen.width/9,Screen.height/6),"E")) {
		}
		GUI.Label (new Rect(Screen.width/9*1,Screen.height/6*5,Screen.width/9,Screen.height/6),"25000");
		
		if (GUI.Button (new Rect(Screen.width/9*3,Screen.height/6*4,Screen.width/9,Screen.height/6),"F")) {
		}
		GUI.Label (new Rect(Screen.width/9*3,Screen.height/6*5,Screen.width/9,Screen.height/6),"70000");
		
		if (GUI.Button (new Rect(Screen.width/9*5,Screen.height/6*4,Screen.width/9,Screen.height/6),"G")) {
		}
		GUI.Label (new Rect(Screen.width/9*5,Screen.height/6*5,Screen.width/9,Screen.height/6),"100000");
		
		if (GUI.Button (new Rect(Screen.width/9*7,Screen.height/6*4,Screen.width/9,Screen.height/6),"H")) {
		}
		GUI.Label (new Rect(Screen.width/9*7,Screen.height/6*5,Screen.width/9,Screen.height/6),"250000");
	}

	void OnGUI() {
		GUI.skin = skin;
		GUI.Label (new Rect(0,0,Screen.width/6,Screen.height/10),"Score:"+score);
		if (GUI.Button (new Rect(Screen.width-Screen.width/7,0,Screen.width/7,Screen.height/10),"Back")) {
			Application.LoadLevel("Menu");
		}


		if (GUI.Button (new Rect(Screen.width/5*1-10,0,Screen.width/5,Screen.height/10),"weapon")) {
			menuState = 0;
		}
		
		if (GUI.Button (new Rect(Screen.width/5*2,0,Screen.width/5,Screen.height/10),"skill")) {
			menuState = 1;
		}
		
		if (GUI.Button (new Rect(Screen.width/5*3+10,0,Screen.width/5,Screen.height/10),"ability")) {
			menuState = 2;
		}


		if (menuState == 0) {
			DrawWeapon ();
		}
		if (menuState == 1) {
			DrawSkill();
		}
		if (menuState == 2) {
			DrawAbility();
		}
	}
}
