using UnityEngine;
using System.Collections;

public class FaceDirection : MonoBehaviour {

	/// <summary>
	/// Inti Face direction: 1 is right, -1 is left
	/// </summary>
	public float faceDir =1;

	float dir =1;
	MoveScript moveScript;
	float myscale =0;
	Vector2 direction;
	void Start(){
		myscale = transform.localScale.x;
		moveScript = gameObject.GetComponent<MoveScript>();
		direction = moveScript.direction;
	}
	// Update is called once per frame
	void Update () {
	
		//player face direction
		if (direction.x < 0) {
			//face left
			dir = -1;
		}else{
			//face right
			dir = 1;
		}
		transform.localScale = new Vector3(myscale*dir*faceDir,transform.localScale.y);

	}
}
