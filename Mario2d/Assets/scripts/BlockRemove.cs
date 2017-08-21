using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRemove : MonoBehaviour {

    bool flag_remove = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (flag_remove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player")
        {
            StartCoroutine(Example());
            
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        flag_remove = true;
    }
}
