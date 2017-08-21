using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPoint : MonoBehaviour {

    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject label;

    private bool flag_point = false;

  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (flag_point)
        {
            try
            {
                point.transform.position = new Vector3(point.transform.position.x, point.transform.position.y + 0.05f, point.transform.position.z);
                Destroy(point, 0.5f);
            }
            catch (System.Exception)
            {
                
                
            }
            
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.transform.position.y < transform.position.y)
            {
                point.GetComponent<AudioSource>().Play();
                flag_point = true;
                label.SetActive(false);
                try
                {
                    if (point.activeSelf)
                        Move.points += 1;
                }
                catch (System.Exception)
                {
                    
                   
                }
              
            }
            

        }

    }
}
