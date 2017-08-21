using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Move : MonoBehaviour {

    bool flag_up = true;
    bool flag_down = false;
	private float height_enemy = 0;
    [SerializeField]
    private Move move;
	// Use this for initialization
	void Start () {
		height_enemy = transform.position.y + 0.7f;
		move = GameObject.Find ("Player").GetComponent<Move> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (flag_up)
        {
			if (transform.position.y > height_enemy)
            {
                StartCoroutine(UpDown());
            }
            else
            {
                
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
            }
                
        }
        if (flag_down)
        {
			if (transform.position.y > height_enemy-0.9f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
            }
            else
            {
                flag_up = true;
                flag_down = false;
            }
           
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player")
        {
			try {
				move.move = -5;
			} catch (System.Exception ex) {
				
			}
            
        }
    }
    IEnumerator UpDown()
    {
        yield return new WaitForSeconds(5);
        flag_up = false;
        flag_down = true;
    }
}
