using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {
	public float spawnDurationSec = 1.0f;
	int spawnDuration = 0;
	public float waveMultipler = 0.05f;
	public float minSpawnTimeSec = 0.5f;
	int minSpawnTime = 0;
	GameObject monsterPrefab;
	GameObject bossPrefab;
	Random random;
	public GameObject[] enemyList;


	// Use this for initialization
	void Start () {
		spawnDuration =(int) (spawnDurationSec * 60);
		minSpawnTime = (int)(minSpawnTimeSec * 60);
		monsterPrefab = (GameObject)Resources.Load ("Prefabs/Poulpi");
		bossPrefab = (GameObject)Resources.Load ("Prefabs/Boss");
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


	// Update is called once per frame
	void Update () {
		timecount++;
//		Debug.Log ("SpawnDuration : "+spawnDuration.ToString());
		if(timecount % spawnDuration == 0){
			GameObject newMon = (GameObject)GameObject.Instantiate (monsterPrefab);
			newMon.transform.position = this.transform.position;
			MoveScript move = newMon.GetComponent<MoveScript>();
			int dir = 1;
			if(Random.Range(0,2)==0){
				dir =-1;
			}
			move.direction = new Vector2(dir,0);

		}
	}

}
