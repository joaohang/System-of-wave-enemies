using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	public float moveSpeed;
	private Vector3 moveInput;
	private Vector3 moveVelocity;
	//Shot
	public GameObject bullet;
	public Transform startBullet;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
 
 	void Update () {
		 MovePlayer();
		 RotationPlayer();
		 Shot();
	}

	void RotationPlayer(){
		var mousePos = Input.mousePosition;
     	mousePos.z = 10.0f;
     	Vector3 lookPos= Camera.main.ScreenToWorldPoint(mousePos);
     	lookPos = lookPos - transform.position;
     	float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
     	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void MovePlayer(){
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0f);
		moveVelocity = moveInput * moveSpeed;
		rb.velocity = moveVelocity;
	}

	void Shot(){
		if(Input.GetMouseButtonDown(0)){
			Instantiate(bullet,startBullet.position,startBullet.rotation);
		}
	}

		void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
	}
}
