﻿using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
  //--------------------------------
  // 1 - Designer variables
  //--------------------------------

  /// <summary>
  /// Projectile prefab for shooting
  /// </summary>
  public Transform shotPrefab;

  /// <summary>
  /// Cooldown in seconds between two shots
  /// </summary>
  public float shootingRate = 0.25f;

  //--------------------------------
  // 2 - Cooldown
  //--------------------------------

  private float shootCooldown;

  void Start()
  {
    shootCooldown = 0f;
  }

  void Update()
  {
    if (shootCooldown > 0)
    {
      shootCooldown -= Time.deltaTime;
    }
  }

  //--------------------------------
  // 3 - Shooting from another script
  //--------------------------------

  /// <summary>
  /// Create a new projectile if possible
  /// </summary>
  public void Attack(bool isEnemy)
  {
    if (CanAttack)
    {
      shootCooldown = shootingRate;

      // Create a new shot 
      var shotTransform = Instantiate(shotPrefab) as Transform;

      // Assign position
      shotTransform.position = transform.position;

      // The is enemy property
      ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
	  float X = transform.GetComponent<PlayerScript>().inputX;
	  float Y = transform.GetComponent<PlayerScript>().inputY;
      if (move != null)
      {
		if (X <0) {
			if (Y > 0) {
					move.direction = new Vector2(-1,1);	
			} else if (Y < 0) {
					move.direction = new Vector2(-1,-1);
			} else {
					move.direction = new Vector2(-1,0);		
			}
		} else if (X > 0) {
			if (Y > 0) {
					move.direction = new Vector2(1,1);	
			} else if (Y <0) {
					move.direction = new Vector2(1,-1);
			} else {
					move.direction = new Vector2(1,0);		
			}
		} else {
			if (Y > 0) {
					move.direction = new Vector2(0,1);	
			} else if (Y < 0) {
					move.direction = new Vector2(0,-1);
			} else {
				if(this.transform.localScale.x < 0){
		        move.direction = new Vector2(-1,0); // towards in 2D space is the right of the sprite
				}else{
				move.direction = new Vector2(1,0);
				}
			}
		}
		/*
		if(this.transform.localScale.x < 0){
        move.direction = new Vector2(X,Y); // towards in 2D space is the right of the sprite
		}else{
		move.direction = new Vector2(X,Y);
		}
		*/
	  }
    }
  }

  /// <summary>
  /// Is the wepaon ready to create a new projectile?
  /// </summary>
  public bool CanAttack
  {
    get
    {
      return shootCooldown <= 0f;
    }
  }
}