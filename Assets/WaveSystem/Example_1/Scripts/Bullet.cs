using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed, TimeDestruction;
	void Start () {
		Destroy(gameObject,TimeDestruction);
	}
	void Update () {
		MoveBullet();
	}
	void MoveBullet(){
		transform.Translate(Vector2.right * speed * Time.deltaTime);		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
		}
	}
}
