using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_BigPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject mashroom;
    [SerializeField]
    private GameObject label;

    private float height_gameobject = 1.55f;

    private bool flag_height = false;

    private bool flag_position = false;
    private Rigidbody2D mashroom_rigidbody;
    void Awake()
    {
        try
        {
            mashroom_rigidbody = mashroom.GetComponent<Rigidbody2D>();
        }
        catch (System.Exception)
        {
            
            
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (flag_position)
            {
                mashroom_rigidbody.simulated = true;
                mashroom.transform.position = new Vector3(mashroom.transform.position.x + 0.01f, mashroom.transform.position.y, mashroom.transform.position.z);

                if (mashroom.transform.localPosition.y < -100)
                {
                    Destroy(mashroom);
                    flag_position = false;
                }

            }
            if (flag_height && mashroom.transform.localPosition.y < 1.45f)
            {
                mashroom.transform.position = new Vector3(mashroom.transform.position.x, mashroom.transform.position.y + 0.02f, mashroom.transform.position.z);
            }

            else if (flag_height)
            {
                flag_height = false;
                flag_position = true;
            }
        }
        catch (System.Exception)
        {
            
            
        }
      
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.transform.position.y < transform.position.y && other.gameObject.transform.localScale.y <= 1.25f)
            {
                flag_height = true;
                label.SetActive(false);
            }
            else if (other.gameObject.transform.position.y < transform.position.y && other.gameObject.transform.localScale.y >= 1.25f)
            {
                flag_height = false;
            }
        }

    }
}
