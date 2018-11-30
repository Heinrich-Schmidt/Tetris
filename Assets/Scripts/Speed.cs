using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour {

    public static int speedValue = 1;
    public Text speed;
    
    public void SpeedUp()
    {
        if (TetrisObject.tick > 0.16 && TetrisObject.tick <= 0.75)
        {
            TetrisObject.tick = TetrisObject.tick - 0.01;
            speedValue++;
            speed.text = "" + speedValue;
        }
        //Debug.Log(countofblocks % 10);
    }
    public void SpeedDown()
    {
        if (TetrisObject.tick > TetrisObject.maxSpeed && TetrisObject.tick < TetrisObject.minSpeed)
        {
            TetrisObject.tick = TetrisObject.tick + 0.01;
            speedValue--;
            speed.text = "" + speedValue;
        }
        //Debug.Log(countofblocks % 10);
    }
}
