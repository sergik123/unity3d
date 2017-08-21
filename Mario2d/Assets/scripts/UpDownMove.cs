using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour {

    private bool flag_down = false;
    private bool flag_up = true;
    private  float count=0;
    private GameObject player;

    private string status="";
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(flag_up)
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.04f, transform.position.z);
        if (flag_down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
            if(status!="")
            player.transform.position =new Vector3(player.transform.position.x, transform.position.y,player.transform.position.z);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        status = other.collider.name;
        //print(other.collider.name);
    }
    void OnCollisionExit2D(Collision2D other)
    {
        status = "";
        //print(other.collider.name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "downCollider")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.04f, transform.position.z);
            flag_up = false;
            flag_down = true;
        }
        if (other.gameObject.name == "upCollider")
        {
            
            flag_up = true;
            flag_down = false;
        }
    }
}
