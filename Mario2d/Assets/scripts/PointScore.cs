using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScore : MonoBehaviour {

    [SerializeField]
    private GameObject point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
                try
                {
                  
                    if (point.activeSelf)
                    {
                        point.GetComponent<AudioSource>().Play();
                        Move.points += 1;
                        point.GetComponent<SpriteRenderer>().enabled = false;
                        Destroy(gameObject,0.4f);
                    }
                        
                }
                catch (System.Exception)
                {


                }

        }

    }
}
