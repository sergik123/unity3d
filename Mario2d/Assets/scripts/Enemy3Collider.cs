using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Collider : MonoBehaviour {

	private bool flag_start = false;
	public GameObject[] enemy3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (flag_start) {
			StartCoroutine ("StartEnemy");
		}
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.name == "Player") {
			flag_start = true;
		}
	}
	IEnumerator StartEnemy(){
		yield return new WaitForSeconds(1);
		enemy3 [0].gameObject.GetComponent<Enemy3Move> ().enabled = true;
		yield return new WaitForSeconds(5);
		enemy3 [1].gameObject.GetComponent<Enemy3Move> ().enabled = true;
		yield return new WaitForSeconds(5);
		enemy3 [2].gameObject.GetComponent<Enemy3Move> ().enabled = true;

		yield return new WaitForSeconds(5);
		enemy3 [3].gameObject.GetComponent<Enemy3Move> ().enabled = true;
		yield return new WaitForSeconds(5);
		enemy3 [4].gameObject.GetComponent<Enemy3Move> ().enabled = true;
		yield return new WaitForSeconds(5);
		enemy3 [5].gameObject.GetComponent<Enemy3Move> ().enabled = true;
	}
}
