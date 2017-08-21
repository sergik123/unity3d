using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Enemy2Move : MonoBehaviour {

    [SerializeField]
    public GameObject[] enemy2;
    private GameObject enemy_new;
    private bool flag_down = false;

    
    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
       
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (flag_down)
            {
                for (int i = 0; i < enemy2.Length; i++)
                {
                    enemy2[i].transform.position = new Vector3(enemy2[i].transform.position.x, enemy2[i].transform.position.y - 0.07f, enemy2[i].transform.position.z);
                    if (enemy2[i].transform.position.y < 0)
                    {
                        enemy2[i].transform.position = new Vector3(enemy2[i].transform.position.x, 15f, enemy2[i].transform.position.z);
                    }
                }
                if (Player.transform.position.y < -5)
                {
                    for (int i = 0; i < enemy2.Length; i++)
                    {
                        enemy2[i].transform.position = new Vector3(enemy2[i].transform.position.x, 15f, enemy2[i].transform.position.z);
                    }
                    // flag_down = false;
                }
            }
        }
        catch (System.Exception)
        {
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player" /*&& other.gameObject.transform.localScale.y > 0*/)
        {
            try
            {
                var arr = GameObject.FindGameObjectsWithTag("enemy2");
                for (int i = 0; i < arr.Length; i++)
                {
                    enemy2[i] = arr[i];
                }
                //if (enemy2[0].transform.position.y == 19.15f)
                    flag_down = true;
            }
            catch (System.Exception)
            {
                
               
            }
          
        }
    }
    
}
