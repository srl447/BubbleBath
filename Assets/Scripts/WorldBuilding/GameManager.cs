using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int tileCount; //Size of world

    int wait; //wait frames

    GameObject[] enemies, floors, walls; //arrays for environmental objects

    void Start()
    {
        StartCoroutine(grabGameObjects()); //waits a frame so everything will be loaded
    }

    void Update()
    {
        if (wait < 2) //stops update while arrays are undefined
        {
            wait++;
        }
        else { 
         
        //sets enemies active based on distance from camera
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, Camera.main.transform.position) > 25)
            {
                enemy.SetActive(false);
            }
            else if(enemy.GetComponent<EnemyHealth>().enemyHealth == 0)
                    {
                    enemy.SetActive(false);
                }
            else
            {
                enemy.SetActive(true);
            }
        }

        //sets walls active based on distance from camera
        foreach (GameObject wall in walls)
        {
            if (Vector2.Distance(wall.transform.position, Camera.main.transform.position) > 25)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }
        }

            //sets floors active based on distance from camera
            foreach (GameObject floor in floors)
            {
                if (Vector2.Distance(floor.transform.position, Camera.main.transform.position) > 25)
                {
                    floor.SetActive(false);
                }
                else
                {
                    floor.SetActive(true);
                }
            }
        }
    }

    //waits for game to load and then assigns all the objects in the scenes into arrays based off tag
    IEnumerator grabGameObjects()
    {
        yield return new WaitForEndOfFrame();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        floors = GameObject.FindGameObjectsWithTag("Floor");
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
}

