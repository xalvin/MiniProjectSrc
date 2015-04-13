using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour {
	bool isStart = false;
	int count = 0;
	WeaponScript wp;
	// Use this for initialization
	void Start () {
		wp = gameObject.GetComponent<WeaponScript> ();
	}
	public void startSkill(){
		isStart = true;
	}
	int time =0;
	// Update is called once per frame
	void Update () {
		if(isStart&& ((time++)%20 == 0)){
			if(count < 10){
				wp.skillAttack();
				count++;
			}else{
				count = 0;
				isStart = false;
			}
		}
	}
}
