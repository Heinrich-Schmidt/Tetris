using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public static int countofblocks = 0;
    
    [SerializeField]
    private GameObject[] gameObjects;
	void Start () {
        SpawnRandom(Random.Range(0, gameObjects.Length));
        
    }

    
    public void SpawnRandom(int index)
    {
        
        Instantiate(gameObjects[index], transform.position, Quaternion.identity);
        countofblocks++;
        FindObjectOfType<SpawnerNext>().SpawnRandom();
        if (countofblocks % 10 == 0)
        {
            FindObjectOfType<Speed>().SpeedUp();
        }
        Debug.Log(countofblocks + " " + TetrisObject.tick + " " + (TetrisObject.tick - 0.05));
    }

    

   
}
