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
	public string level = "easy";
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
	int min = 0;
	int sec = 0;
	int msec = 0;
	GameObject[] spawnPoints;
	float comboMulitpler=0.0f;
	int skillpoint = 0;
	// Use this for initialization
	void Start () {
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

	public void addScoreByKillBoss(){
		score+=bossScore;
		scoreText.text = score.ToString ();
		comboMulitpler += killMultiper*2;
		comboMultiperText.text = "x"+comboMulitpler.ToString();
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
		comboMulitpler += killMultiper;
		comboMultiperText.text = "x"+comboMulitpler.ToString();
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
	int count =0;
	// Update is called once per frame
	void Update () {
		if (count % killMultiperCount == 0 && comboMulitpler>0) {
			comboMulitpler -= killMultiperDecrease;
			if(comboMulitpler<0){
				comboMulitpler=0;
			}
			comboMultiperText.text = "x"+comboMulitpler.ToString();
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
