using UnityEngine;
using System.Collections;

public class BossFloatOrFollowPlayer : MonoBehaviour {
	GameObject player;
	public string floatOrFollow = "float";
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		floatOrFollow = floatOrFollow.ToLower ();
	}
	
	// Update is called once per frame
	void Update () {
		if (floatOrFollow == "float") {
			Vector3 bossPos = transform.position;
			Vector3 playerPos = player.transform.position;
			transform.position = Vector3.Lerp(bossPos,playerPos,0.01f);
		}else{

		}
	}
}
