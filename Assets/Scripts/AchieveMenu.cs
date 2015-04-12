using UnityEngine;
using System.Collections;

public class AchieveMenu : MonoBehaviour {

	private int score;
	private float runSpeed;
	private float damage;
	private float shotSpeed;
	private int runLevel;
	private int damageLevel;
	private int shotLevel;


	private int menuState; //0 for weapon, 1 for skill, 2 for ability 
	private int weapon; // 0 for default weapon
	private int skill; // 0 for no skill
	//private int ability;
	private GUISkin skin;
	// Use this for initialization
	void Start () {
		//Load score from prefs;
		score = PlayerPrefs.GetInt ("Score",0);
		runSpeed = PlayerPrefs.GetFloat ("runSpeed",1.0f);
		damage = PlayerPrefs.GetFloat ("damage",1.0f);
		shotSpeed = PlayerPrefs.GetFloat ("shotSpeed",1.0f);
		runLevel = PlayerPrefs.GetInt ("runLevel", 0);
		damageLevel = PlayerPrefs.GetInt ("damageLevel", 0);
		shotLevel = PlayerPrefs.GetInt ("shotLevel",0);
		weapon = PlayerPrefs.GetInt ("weapon", 0);
		skill = PlayerPrefs.GetInt ("skill",0);
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DrawWeapon() {
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (weapon==0)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*1,Screen.height/5*2,Screen.width/7,Screen.height/5),"HandGun")) {
			if (skill != 0 && score >= 0) {
				score -= 0;
				weapon = 0;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("weapon",weapon);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*3,Screen.width/7,Screen.height/5),"0");
		
		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (weapon==1)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*3,Screen.height/5*2,Screen.width/7,Screen.height/5),"MP5")) {
			if (weapon != 1 && score >= 100000) {
				score -= 100000;
				weapon = 1;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("weapon",weapon);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*3,Screen.width/7,Screen.height/5),"100000");
		
		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (weapon==2)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*5,Screen.height/5*2,Screen.width/7,Screen.height/5),"AK74")) {
			if (weapon != 2 && score >= 250000) {
				score -= 500000;
				weapon = 2;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("weapon",weapon);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*3,Screen.width/7,Screen.height/5),"250000");
	}


	private void DrawSkill() {
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (skill==1)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*1,Screen.height/5*2,Screen.width/7,Screen.height/5),"Big\nBullet")) {
			if (skill != 1 && score >= 10000) {
				score -= 10000;
				skill = 1;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("skill",skill);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*3,Screen.width/7,Screen.height/5),"10000");

		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (skill==2)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*3,Screen.height/5*2,Screen.width/7,Screen.height/5),"Bullet\nRain")) {
			if (skill != 2 && score >= 250000) {
				score -= 250000;
				skill = 2;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("skill",skill);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*3,Screen.width/7,Screen.height/5),"250000");

		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*2-50,Screen.width/7,Screen.height/8), (skill==3)?"EQUIP":"");
		if (GUI.Button (new Rect(Screen.width/7*5,Screen.height/5*2,Screen.width/7,Screen.height/5),"Fire\nDragon")) {
			if (skill != 3 && score >= 500000) {
				score -= 500000;
				skill = 3;
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt ("skill",skill);
				PlayerPrefs.Save ();
			}
		}
		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*3,Screen.width/7,Screen.height/5),"500000");
	}


	private void DrawAbility() {
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*2-50,Screen.width/7,Screen.height/8),"LV "+runLevel);
		if (GUI.Button (new Rect(Screen.width/7*1,Screen.height/5*2,Screen.width/7,Screen.height/5),"Run\nSpeed")) {
			if (runLevel <5 && score >= (20000*(runLevel+1))) {
				score -= 20000*(runLevel+1);
				runLevel += 1;
				runSpeed *= 1.08f;
				PlayerPrefs.SetInt ("Score",score);
				PlayerPrefs.SetInt("runLevel",runLevel);
				PlayerPrefs.SetFloat ("runSpeed",runSpeed);
				PlayerPrefs.Save();
			}
		}
		GUI.Label (new Rect(Screen.width/7*1,Screen.height/5*3,Screen.width/7,Screen.height/5),(runLevel>=5)?"MAX LV":""+(20000*(runLevel+1)));

		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*2-50,Screen.width/7,Screen.height/8),"LV "+shotLevel);
		if (GUI.Button (new Rect(Screen.width/7*3,Screen.height/5*2,Screen.width/7,Screen.height/5),"Attack\nSpeed")) {
			if (shotLevel <5 && score >= (20000*(shotLevel+1))) {
				score -= 20000*(shotLevel+1);
				shotLevel += 1;
				shotSpeed *= 1.08f;
				PlayerPrefs.SetInt ("Score",score);
				PlayerPrefs.SetInt("shotLevel",shotLevel);
				PlayerPrefs.SetFloat ("shotSpeed",shotSpeed);
				PlayerPrefs.Save();
			}
		}
		GUI.Label (new Rect(Screen.width/7*3,Screen.height/5*3,Screen.width/7,Screen.height/5),(shotLevel>=5)?"MAX LV":""+(20000*(shotLevel+1)));

		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*2-50,Screen.width/7,Screen.height/8),"LV "+damageLevel);
		if (GUI.Button (new Rect(Screen.width/7*5,Screen.height/5*2,Screen.width/7,Screen.height/5),"Damage")) {
			if (damageLevel <5 && score >= (20000*(damageLevel+1))) {
				score -= 20000*(damageLevel+1);
				damageLevel += 1;
				damage *= 1.08f;
				PlayerPrefs.SetInt ("Score",score);
				PlayerPrefs.SetInt("damageLevel",damageLevel);
				PlayerPrefs.SetFloat ("damage",damage);
				PlayerPrefs.Save();
			}
		}
		GUI.Label (new Rect(Screen.width/7*5,Screen.height/5*3,Screen.width/7,Screen.height/5),(damageLevel>=5)?"MAX LV":""+(20000*(damageLevel+1)));
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
