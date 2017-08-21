using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstButtons : MonoBehaviour {

   
    public GameObject continue_game;
    private float x;
    private float y;
    private float z;
	// Use this for initialization
	void Start () {
        x = PlayerPrefs.GetFloat("x");
	}
	
	// Update is called once per frame
	void Update () {
        if (x != 0)
        {
            continue_game.SetActive(true);
        }
	}
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(1);
        
    }
    public void Continue_play()
    {
        Application.LoadLevel(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
