using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text score;
    public static int scoreQuantity = 0;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}
    public void IncreaseScore(int value)
    {
        scoreQuantity += value;
        score.text = "" + scoreQuantity;
    }


}
