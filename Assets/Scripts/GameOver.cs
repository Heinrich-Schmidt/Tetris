using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField]
    public Text gameOver;
    public Text restart;
    
    void Start () {
        
    }
	
	
	void Update () {
        
    }
    public void ShowGameOver()
    {
        gameOver.text = "GAME OVER";
        restart.text = "Press 'R' to restart";



    }

}
