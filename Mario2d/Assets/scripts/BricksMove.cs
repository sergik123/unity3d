using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BricksMove : MonoBehaviour {

    float count =0;
    private bool flag=false;
    private bool flag_big = false;
	// Use this for initialization
	void Start () {
        count = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
    
        if (flag)
        {
            if (transform.position.y > count)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            }
            else
            {
                flag = false;
                transform.position = new Vector3(transform.position.x, count, transform.position.z);
            }
         }
        if (flag_big)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.06f, transform.position.z);
            Destroy(gameObject, 5f);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.transform.position.y+1f < transform.position.y && other.gameObject.transform.localScale.y <= 1.25f)
            {
                transform.position = new Vector3(transform.position.x, count + 0.3f, transform.position.z);
            }
           /* else if (other.gameObject.transform.position.y < transform.position.y && other.gameObject.transform.localScale.y >= 1.25f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
            }*/
           
        }
    
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if ((Mathf.Abs(other.gameObject.transform.position.y) - Mathf.Abs(transform.position.y)<3) && other.gameObject.transform.localScale.y <= 1.25f)
        {
            flag = true;
        }
        else if (other.gameObject.transform.position.y < transform.position.y && other.gameObject.transform.localScale.y >= 1.25f)
        {
            flag_big = true;
        }
    }
   
}
