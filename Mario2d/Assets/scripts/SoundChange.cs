using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChange : MonoBehaviour {

    public GameObject soundon;
    public GameObject soundoff;
    public Camera camera;
    GameObject[] sound;
    public string[] tags;
	// Use this for initialization
	void Start () {
        
        int soundchange = PlayerPrefs.GetInt("sound");
        
        if (soundchange == 1)
        {
            soundon.SetActive(true);
            soundoff.SetActive(false);
           // camera.GetComponent<AudioListener>().enabled = true;
            camera.GetComponent<AudioSource>().volume = 0.55f;
            for (int k = 0; k < tags.Length; k++)
            {
                sound = GameObject.FindGameObjectsWithTag(tags[k]);
                for (int i = 0; i < sound.Length; i++)
                {
                    sound[i].GetComponent<AudioSource>().volume = 1f;
                }
            }
        }
        if (soundchange == 2)
        {
            soundoff.SetActive(true);
            soundon.SetActive(false);
         //  camera.GetComponent<AudioListener>().enabled = false;
            camera.GetComponent<AudioSource>().volume = 0.0f;
            for (int k = 0; k < tags.Length; k++)
            {
                sound = GameObject.FindGameObjectsWithTag(tags[k]);
                for (int i = 0; i < sound.Length; i++)
                {
                    sound[i].GetComponent<AudioSource>().volume = 0.0f;
                }
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SoundOn()
    {
        if (soundon.activeSelf == false)
        {
            soundon.SetActive(true);
            soundoff.SetActive(false);
            PlayerPrefs.SetInt("sound", 1);
           // camera.GetComponent<AudioListener>().enabled = true;
            camera.GetComponent<AudioSource>().volume = 0.55f;

            for (int k = 0; k < tags.Length; k++)
            {
                sound = GameObject.FindGameObjectsWithTag(tags[k]);
                for (int i = 0; i < sound.Length; i++)
                {
                    sound[i].GetComponent<AudioSource>().volume = 1f;
                }
            }

           
        }
    }
    public void SoundOff()
    {
        if (soundoff.activeSelf == false)
        {
            soundoff.SetActive(true);
            soundon.SetActive(false);
            PlayerPrefs.SetInt("sound", 2);
            camera.GetComponent<AudioSource>().volume = 0.0f;

            for (int k = 0; k < tags.Length; k++)
            {
                sound = GameObject.FindGameObjectsWithTag(tags[k]);
                for (int i = 0; i < sound.Length; i++)
                {
                    sound[i].GetComponent<AudioSource>().volume = 0.0f;
                }
            }
            
        }
    }
}
