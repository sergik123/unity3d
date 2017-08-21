using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTime : MonoBehaviour {

    public Text time;
    public int second=60;
    public int minuts = 2;
    private string zero = "";

    private Move move;
 
	// Use this for initialization
	void Start () {
        move = GameObject.Find("Player").GetComponent<Move>();
        StartCoroutine("currentTime");
	}
    void Update()
    {
        if (minuts == 0 && second == 0)
        {
            StopCoroutine("currentTime");
            time.text = minuts.ToString() + ":" + "00";
            Application.LoadLevel(0);
        }
    }
    IEnumerator currentTime()
    {
        while (minuts >= 0)
        {
            if (minuts == 0 && second < 10)
            {
                time.color = Color.red;
                yield return new WaitForSeconds(0.5f);
                time.color = Color.white;
            }
                yield return new WaitForSeconds(1);
                second--;

                if (second < 10 && second>0)
                {
                    zero = "0";
                }
                else
                {
                    zero = "";
                }
                if (second == 0)
                {
                    if (minuts > 0)
                    {
                        minuts--;
                        second = 59;
                    }

                }
               
                time.text = minuts.ToString() + ":" + zero + second.ToString();

        }
    }
}
