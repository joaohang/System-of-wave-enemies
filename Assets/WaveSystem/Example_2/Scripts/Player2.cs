using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
	Rigidbody2D rb;
	public float moveSpeed;
	private Vector3 moveInput;
	private Vector3 moveVelocity;
	Animator anim;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim =  GetComponent<Animator>();
	}	
	
	void Update () {
		MovePlayer();
		PlayerAnimaton();
	}

	void MovePlayer(){
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0,0);
		moveVelocity = moveInput * moveSpeed;
		rb.velocity = moveVelocity;		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
	}
	void PlayerAnimaton(){
		if(Input.GetAxisRaw("Horizontal")>0){
			anim.SetBool("Walk",true);
			transform.localScale = new Vector3(-1,1,1);
		}else if(Input.GetAxisRaw("Horizontal")<0){
			anim.SetBool("Walk",true);
			transform.localScale = new Vector3(1,1,1);
		}else{
			anim.SetBool("Walk",false);
		}
	}
}
