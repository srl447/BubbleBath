using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int tileCount; //Size of world
    public static int totalHealth; // health for both players

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
        else
        {

            worldRender(enemies); //runs world render for enemies
            worldRender(floors); //runs world render for floors
            worldRender(walls); //runs world render for walls
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

    void worldRender(GameObject[] world) //renders objects in array based on camera distance
    {
        foreach (GameObject piece in world)
        {
            if (Vector2.Distance(piece.transform.position, Camera.main.transform.position) > 25)
            {
                piece.SetActive(false);
            }
            //if checking enemies, also checks if health is 0
            else if (world == enemies && piece.GetComponent<EnemyHealth>().enemyHealth == 0)
            {
                piece.SetActive(false);
            }
            else
            {
                piece.SetActive(true);
            }
        }
    }
}

