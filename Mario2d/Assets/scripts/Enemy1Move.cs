using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour {

	private SpriteRenderer render;

	private float current=0.5f;
	void Awake(){
		render = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - current * Time.deltaTime, transform.position.y, transform.position.z);
	}
	void OnTriggerEnter2D(Collider2D other){

        if (other.name == "Player")
        {
            render.flipX = !render.flipX;
            current *= -1;
        }
		/*if (other.name == "shoot") {
			current = 0;
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y-1.5f, transform.localScale.z);
			Destroy (gameObject);
		}*/
		if (other.tag == "right") {
			render.flipX = true;
			current = -0.5f;
		} 
		if (other.tag == "left"){
			render.flipX = false;
			current = 0.5f;
		}
	}
}
