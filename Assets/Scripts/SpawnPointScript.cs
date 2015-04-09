using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {
	public bool isActive = true;
	public float spawnDurationSec = 1.0f;
	int spawnDuration = 0;
	public float waveMultipler = 0.05f;
	public float minSpawnTimeSec = 0.5f;
	int minSpawnTime = 0;

	Random random;
	public GameObject[] enemyList;
	public GameObject[] bossList;
	public int additionalHP =1;

	// Use this for initialization
	void Start () {
		spawnDuration =(int) (spawnDurationSec * 60);
		minSpawnTime = (int)(minSpawnTimeSec * 60);

	}
	GameObject monster;
	int timecount=0;

	public void increaseSpawnTimeByWaveUp(){
		if (spawnDuration > minSpawnTime) {
			spawnDuration =spawnDuration-Mathf.CeilToInt(waveMultipler * 60);
		}else{
			spawnDuration = Mathf.CeilToInt(minSpawnTimeSec*60);
		}
	}

	public void increaseHP(int morehp){
		additionalHP += morehp;
	}

	void spawnEnemy(){
		if(isActive){
			GameObject newMon = (GameObject)GameObject.Instantiate (enemyList[Random.Range(0,enemyList.Length)]);
			newMon.transform.position = this.transform.position;
			MoveScript move = newMon.GetComponent<MoveScript>();
			int dir = 1;
			if(Random.Range(0,2)==0){
				dir =-1;
			}
			move.direction = new Vector2(dir,0);
			HealthScript health = newMon.GetComponent<HealthScript>();
			health.hp += additionalHP;
		}
	}

	public void spawnBoss(){
		if(isActive){
			GameObject newMon = (GameObject)GameObject.Instantiate (bossList[Random.Range(0,bossList.Length)]);
			newMon.transform.position = this.transform.position;
			HealthScript health = newMon.GetComponent<HealthScript>();
			health.hp += additionalHP;
		}
	}

	// Update is called once per frame
	void Update () {
		if(isActive){
			timecount++;
	//		Debug.Log ("SpawnDuration : "+spawnDuration.ToString());
			if(timecount % spawnDuration == 0){
				spawnEnemy ();

			}
		}
	}

}
