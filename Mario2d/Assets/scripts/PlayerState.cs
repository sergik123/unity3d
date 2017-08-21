using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

  

    private float currenttime;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       
        if (gameObject.transform.localScale.y > 1.4)
        {
            StartCoroutine("changesize");
        }
	}
    IEnumerator changesize()
    {
        yield return new WaitForSeconds(20);
        gameObject.transform.localScale = new Vector3(1.62f, 1.24f, 1);
        StopCoroutine("changesize");
    }

}
