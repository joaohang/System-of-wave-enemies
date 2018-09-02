using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour {

	public float speed;
	float y;
	void Start () {		
	}	
	void Update () {
		MoveBomb();	
	}

	void MoveBomb(){
		y = transform.position.y;
		y -= speed * Time.deltaTime;		
		transform.position = new Vector3 (transform.position.x,y, transform.position.z);
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Player")
            Destroy(gameObject);
	}        
}
