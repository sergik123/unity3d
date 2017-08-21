using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy2Die : MonoBehaviour {

    [SerializeField]
    private Move move;
     [SerializeField]
    private Enemy2Move enemy2move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player")
        {
            if (other.gameObject.transform.localScale.y > 1.25)
            {
                other.gameObject.transform.localScale = new Vector3(1.62f, 1.24f, 1);
            }
            else
            {
                move.Die();
            }
            

                Destroy(gameObject);

                var arr = GameObject.FindGameObjectsWithTag("enemy2");
                for (int i = 0; i < arr.Length; i++)
                {
                    enemy2move.enemy2[i] = arr[i];
                }
        }
    }
}
