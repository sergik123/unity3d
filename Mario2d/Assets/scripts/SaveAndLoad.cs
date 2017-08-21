using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour {

    private float x;
    private float y;
    private float z;

    private GameObject player;
    private GameObject startpos;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        startpos = GameObject.FindGameObjectWithTag("start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            x = other.gameObject.transform.position.x;
            y = other.gameObject.transform.position.y;
            z = other.gameObject.transform.position.z;

            Save(x,y,z);
        } 
    }
    void Save(float x, float y, float z)
    {
        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
    }
    public void Load()
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        if (x == 0)
        {
            player.transform.position = startpos.transform.position;
        }
        else
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }
}
