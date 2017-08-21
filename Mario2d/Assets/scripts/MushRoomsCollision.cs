using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomsCollision : MonoBehaviour {

    private bool flag_scale=false;
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
  
    }
	
	// Update is called once per frame
	void Update () {
        if (flag_scale && player.transform.localScale.y < 1.8f)
        {
          
            player.transform.localScale = new Vector3(1.9f, 1.8f, transform.localScale.z);
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            flag_scale = true;
        }
    }
}
