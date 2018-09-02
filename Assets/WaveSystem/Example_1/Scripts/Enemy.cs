using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Rigidbody2D rb;
	GameObject player;
	public float speed;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.Find("Player");	
	}	
	void Update () {
		
		MoveEnemy();
		RotationEnemy();
	}
	void MoveEnemy(){
		rb.velocity = (player.transform.position - transform.position) * speed;
	}
	void RotationEnemy(){
		Vector3 posPlayer = player.transform.position;
		posPlayer.z = 10.0f;	
     	Vector3 lookPos= Camera.main.ScreenToWorldPoint(posPlayer);
     	lookPos = lookPos - transform.position;
     	float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
     	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Bullet"){
		Destroy(gameObject);
		}
	}
}
