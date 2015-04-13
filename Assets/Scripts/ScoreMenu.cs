using UnityEngine;
using System.Collections;

public class ScoreMenu : MonoBehaviour {
	TextMesh scoreText;
	TextMesh timerText;
	TextMesh wavecountText;
	TextMesh skillpointText;
	TextMesh comboMultiperText;
	int score =0;
	int wave = 0;
	bool gameActive = true;
	public string level = "Easy";
	float levelMulitper = 1;
	public int bossScore = 50;
	public int enemyScore = 1;
	public int timeScore = 1;
	public int DurationMin = 1;
	public int DurationSec = 30;
	public float killMultiper = 0.5f;
	public float killMultiperDecrease = 0.2f;
	public float decreaseAfterSec = 1;
	int killMultiperCount =0;
	public int hpOfEnemyToBeAdd = 1;
	public int numOfWaveToAddEnemyHP = 5;
	public int numOfWaveToSpawnBoss = 10;
	public int numOfWaveToActiveSpawnPoint =5; 
	public int numOfWaveToAddSpawnTime = 2;
	int min = 0;
	int sec = 0;
	int msec = 0;
	GameObject[] spawnPoints;
	float comboMulitpler=0.0f;
	int skillpoint = 0;

	float runSpeed;
	float damage;
	float shotSpeed;
	int weapon;
	int skill;
	public GameObject[] weaponList;
	public GameObject[] skillList;
	GameObject player;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("Stage",level);
		PlayerPrefs.Save ();
		player = GameObject.FindGameObjectWithTag ("Player");
		runSpeed = PlayerPrefs.GetFloat ("runSpeed",1.0f);
		damage = PlayerPrefs.GetFloat ("damage",1.0f);
		shotSpeed = PlayerPrefs.GetFloat ("shotSpeed",1.0f);
		weapon = PlayerPrefs.GetInt ("weapon", 0);
		skill = PlayerPrefs.GetInt ("skill",0);
		setWeaponAndAdditionalDamage (weaponList[weapon],damage,shotSpeed);
		player.GetComponent<PlayerScript> ().speed *= runSpeed;
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh>();
		timerText = GameObject.Find("Timer").GetComponent<TextMesh>();
		wavecountText = GameObject.Find ("WaveCount").GetComponent<TextMesh>();
		skillpointText = GameObject.Find ("SkillPoint").GetComponent<TextMesh>();
		comboMultiperText = GameObject.Find ("ComboMulitpler").GetComponent<TextMesh>();
		killMultiperCount = Mathf.CeilToInt(decreaseAfterSec*60);
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		score = int.Parse(scoreText.text);
		wave = int.Parse (wavecountText.text);
		timerText.text = DurationMin.ToString()+":"+DurationSec.ToString()+":00";
		min = DurationMin;
		sec = DurationSec;
	}



	void setWeaponAndAdditionalDamage(GameObject weaponGO,float dm,float sp){
		
		weaponGO.GetComponent<ShotScript> ().damage = Mathf.CeilToInt(weaponGO.GetComponent<ShotScript> ().damage * dm);
		player.GetComponent<WeaponScript>().shotPrefab = weaponGO.transform;
		player.GetComponent<WeaponScript> ().shootingRate /= sp;
	}


	public void addScoreByKillBoss(){
		score+=bossScore;
		scoreText.text = score.ToString ();
		increaseComboMultiper (killMultiper*10);
	}

	public void addScoreByKillEnemy(){

		if (comboMulitpler != 0) {
			skillpoint+=1;
			skillpointText.text = skillpoint.ToString();
			score+=Mathf.CeilToInt(enemyScore*comboMulitpler);
		}else{
			score+=enemyScore;
		}
		scoreText.text= score.ToString();
		increaseComboMultiper (killMultiper);
	}
	public void addScoreByTime(){
		score+=timeScore;
		scoreText.text = score.ToString();
	}

	void increaseComboMultiper(float km){
		comboMulitpler += km;
		comboMultiperText.text = "x"+comboMulitpler.ToString();
	}

	void decreaseComboMultiper(float kmd){
		comboMulitpler -= kmd;
		if(comboMulitpler<0){
			comboMulitpler=0;
		}
		comboMulitpler = ((int)(comboMulitpler * 10) / 10);
		comboMultiperText.text = "x"+comboMulitpler.ToString();
	}

	void goToNextWave(){
		wave += 1;
		wavecountText.text = wave.ToString ();
		SpawnPointScript spScript;
		foreach (GameObject sp in spawnPoints) {
			spScript = sp.GetComponent<SpawnPointScript>();
			if(spScript.isActive){
				if(wave%numOfWaveToAddSpawnTime==0){
					spScript.increaseSpawnTimeByWaveUp();
				}
				if(wave%numOfWaveToAddEnemyHP ==0){
					spScript.increaseHP(hpOfEnemyToBeAdd);
				}
				if(wave%numOfWaveToSpawnBoss ==0){
					spScript.spawnBoss();
				}
			}
		}
		if(wave % numOfWaveToActiveSpawnPoint ==0){
			foreach (GameObject sp in spawnPoints) {
				spScript = sp.GetComponent<SpawnPointScript>();
				if(spScript.isActive==false){
					spScript.isActive=true;
					break;
				}
			}
		}
	}

	public void SetGameOver(){
		gameActive = false;

	}
	public int GetSkillPoint(){
		return skillpoint;
	}

	public void decreaseSkillPoint(int d){
		skillpoint -= d;
		skillpointText.text = skillpoint.ToString();
	}

	public int getScore(){
		return score;
	}

	string tempTimeString;
	int count =0;
	// Update is called once per frame
	void Update () {
		if(gameActive){
			int killcount = Mathf.CeilToInt (killMultiperCount - comboMulitpler / 2 + 5);
			if (killcount <= 0) {
				killcount = 1;
			}
			if (count % killcount == 0 && comboMulitpler>0) {
				decreaseComboMultiper(killMultiperDecrease);
			}
			count++;
			tempTimeString="";
			msec -= 1;
			if(min<=0&&sec<=0&&msec<=0){
				goToNextWave();
				min = DurationMin;
				sec = DurationSec;
				msec=0;
			}
			if (msec<=0) {
				msec = 60;
				sec-=1;
				addScoreByTime();
			}
			if (sec < 0) {
				sec = 59;
				min-=1;
			}
			if (min < 0) {
				min=0;
			}
			if(min<10){
				tempTimeString+="0";
			}
			tempTimeString +=( min.ToString ()+":");
			if(sec<10){
				tempTimeString+="0";
			}
			tempTimeString +=( sec.ToString ()+":");
			if(msec<10){
				tempTimeString+="0";
			}
			tempTimeString += msec.ToString ();
			timerText.text = tempTimeString;
		}
	}
}
