using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNext : MonoBehaviour {

    
    public static int index = 0;
    public static GameObject gameobject = null;
    [SerializeField]
    private GameObject[] gameObjects;
	    
    public void SpawnRandom()
    {
        if(gameobject != null) GameObject.Destroy(gameobject);
        index = Random.Range(0, gameObjects.Length);
        gameobject = Instantiate(gameObjects[index], transform.position, Quaternion.identity);
        
    }
    
}
