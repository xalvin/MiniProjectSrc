using UnityEngine;
using System.Collections;

public class ScoreMenu : MonoBehaviour {
	TextMesh scoreText;
	TextMesh timerText;
	TextMesh wavecountText;
	int score =0;
	int wave = 0;
	public string level = "easy";
	float levelMulitper = 1;
	public int bossScore = 50;
	public int enemyScore = 1;
	public int timeScore = 1;
	public int DurationMin = 1;
	public int DurationSec = 30;
	int min = 0;
	int sec = 0;
	int msec = 0;
	GameObject[] spawnPoints;
	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh>();
		timerText = GameObject.Find("Timer").GetComponent<TextMesh>();
		wavecountText = GameObject.Find ("WaveCount").GetComponent<TextMesh>();
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		score = int.Parse(scoreText.text);
		wave = int.Parse (wavecountText.text);
		timerText.text = DurationMin.ToString()+":"+DurationSec.ToString()+":00";
		min = DurationMin;
		sec = DurationSec;
	}

	public void addScoreByKillBoss(){
		score+=bossScore;
		scoreText.text = score.ToString ();
	}

	public void addScoreByKillEnemy(){
		score+=enemyScore;
		scoreText.text= score.ToString();	
	}
	public void addScoreByTime(){
		score+=timeScore;
		scoreText.text = score.ToString();
	}

	void updateTiming(){

	}

	void goToNextWave(){
		wave += 1;
		wavecountText.text = wave.ToString ();
		foreach (GameObject sp in spawnPoints) {
			if(sp.activeSelf){
				sp.GetComponent<SpawnPointScript>().increaseSpawnTimeByWaveUp();
			}
		}
	}
	string tempTimeString;
	// Update is called once per frame
	void Update () {
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
