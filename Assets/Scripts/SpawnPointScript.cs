using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {
	GameObject monsterPrefab;
	GameObject bossPrefab;
	Random random;
	// Use this for initialization
	void Start () {
		monsterPrefab = (GameObject)Resources.Load ("Prefabs/Poulpi");
		bossPrefab = (GameObject)Resources.Load ("Prefabs/Boss");
	}
	GameObject monster;
	int timecount=0;
	// Update is called once per frame
	void Update () {
		timecount++;
		if(timecount % 60 == 0){
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
