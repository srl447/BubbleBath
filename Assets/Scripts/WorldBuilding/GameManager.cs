using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int tileCount; //Size of world

    int wait;

    GameObject[] enemies, floors, walls;

    void Start()
    {
        StartCoroutine(grabGameObjects());
    }

    void Update()
    {
        if (wait < 2)
        {
            wait++;
        }
        else { 
       /* for (int i = 0; i < transform.childCount; i++)
         {
             if(Vector2.Distance(transform.GetChild(i).transform.position, Camera.main.transform.position) > 25)
             {
                 transform.GetChild(i).GetComponent<Renderer>().enabled = false;
             }
             else
             {
                 transform.GetChild(i).GetComponent<Renderer>().enabled = true;
             }
         }*/
         

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, Camera.main.transform.position) > 25)
            {
                enemy.SetActive(false);
            }
            else
            {
                enemy.SetActive(true);
            }
        }

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
    IEnumerator grabGameObjects()
    {
        yield return new WaitForEndOfFrame();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        floors = GameObject.FindGameObjectsWithTag("Floor");
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
}

