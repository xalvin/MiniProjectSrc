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
	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score").GetComponent<TextMesh>();
		timerText = GameObject.Find("Timer").GetComponent<TextMesh>();
		wavecountText = GameObject.Find ("WaveCount").GetComponent<TextMesh>();
		score = int.Parse(scoreText.text);
		wave = int.Parse (wavecountText.text);
	}

	public void addScoreByKill(GameObject enemyObj){
		string enemyName = enemyObj.name.Substring(0,enemyObj.name.Length-7);
		if(enemyName == "Boss"){
//		if(enemyObj=="Boss"){
			score+=bossScore;
			scoreText.text = score.ToString();
		}else{
			score+=enemyScore;
			scoreText.text= score.ToString();
		}
	}

	public void addScoreByTime(){
		score+=timeScore;
		scoreText.text = score.ToString();
	}

	public void updateTiming(){

	}



	// Update is called once per frame
	void Update () {

	}
}
