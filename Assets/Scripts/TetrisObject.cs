using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisObject : MonoBehaviour
{
    public static double minSpeed = 0.75;
    public static double maxSpeed = 0.16;
    float lastFall = 0f;
    int countofsteps = 0;
    bool gameover = false;
    public static double tick = minSpeed;
    void Start()
    {
        
    }
    
    
    void Update()
    {
        if (!gameover && MatrixGrid.IsInsideBorder(MatrixGrid.RoundVector(transform.position)))
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
                if (IsValidGridPosition())
                {
                    
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
            {
                FindObjectOfType<Speed>().SpeedUp();
                Debug.Log("SpeedUp");
            }
            
            else if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
            {
                FindObjectOfType<Speed>().SpeedDown();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
                if (IsValidGridPosition())
                {
                    
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Rotate(new Vector3(0, 0, -90));

                if (IsValidGridPosition())
                {
                    
                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, 90));

                }
            }
           
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Time.time - lastFall >= tick)
            {
                GameObjectDown();
                lastFall = Time.time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && gameover)
        {
            Restart();
        }


    }
    void Restart()
    {
        tick = minSpeed;
        Spawner.countofblocks = 0;
        Score.scoreQuantity = 0;
        Speed.speedValue = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void GameObjectDown()
    {
        transform.position += new Vector3(0, -1, 0);
        if (IsValidGridPosition())
        {
            countofsteps++;
        }
        else
        {
            if (countofsteps > 0)
            {
                transform.position += new Vector3(0, 1, 0);
                UpdateMatrixGrid();
                MatrixGrid.DeleteWholeRows();
                FindObjectOfType<Spawner>().SpawnRandom(SpawnerNext.index);
                enabled = false;

            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                gameover = true;
                FindObjectOfType<GameOver>().ShowGameOver();
                //Debug.Log("game over");



            }
        }
        
    }
    bool IsValidGridPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = MatrixGrid.RoundVector(child.position);
            if (!MatrixGrid.IsInsideBorder(v))
                return false;
            if (MatrixGrid.grid[(int)v.x, (int)v.y] != null && MatrixGrid.grid[(int)v.x, (int)v.y] != transform)
                return false;
                   
            

        }
        return true;
    }
    void UpdateMatrixGrid()
    {
        for(int y = 0; y < MatrixGrid.column; ++y)
        {
            for(int x = 0; x < MatrixGrid.row; ++x)
            {
                if (MatrixGrid.grid[x, y] != null)
                    if (MatrixGrid.grid[x, y] == transform)
                        MatrixGrid.grid[x, y] = null;
            }
        }
        foreach (Transform child in transform)
        {
            Vector2 v = MatrixGrid.RoundVector(child.position);
            MatrixGrid.grid[(int)v.x, (int)v.y] = child;
            

        }
        FindObjectOfType<Score>().IncreaseScore(1);
        /*for (int y = MatrixGrid.column-1; y >= 0 ; --y)
        {
            string s = "";
            for (int x = 0; x < MatrixGrid.row; ++x)
            {
                if (MatrixGrid.grid[x, y] != null)
                    s += " " + 0;
                else s += " 8";

            }
            Debug.Log(s);
        }*/
    }
    
}
