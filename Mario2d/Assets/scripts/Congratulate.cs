using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulate : MonoBehaviour {

    public GameObject congratulate;
  
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player")
        {
            congratulate.SetActive(true);
        }
    }
    public void MainMenu()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(0);
    }
    public void NextLevel()
    {

    }
}
