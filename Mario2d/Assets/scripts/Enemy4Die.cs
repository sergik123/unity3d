using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Die : MonoBehaviour {

    [SerializeField]
    private Move move;

    void Start()
    {
        move = GameObject.Find("Player").GetComponent<Move>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            move.move = -5;
           // move.Die();
        }
    }
}
