using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int tileCount; //Size of world
    public static int totalHealth; // health for both players

    public GameObject lastTile;

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

        //code to place final tile at farthest distance from start
        float longestDistance = 0; //var for comparing farthest distance
        Vector3 farthestPosition = new Vector3(0, 0, 0);//location of farhtest position

        foreach (GameObject floor in floors) //checking every floor to see which is farthest
        {
            if(Mathf.Abs(Vector3.Distance(floor.transform.position, Camera.main.transform.position)) > longestDistance)
            {
                longestDistance = Mathf.Abs(Vector3.Distance(floor.transform.position, Camera.main.transform.position));
                farthestPosition = floor.transform.position; //sets the farthest floor its found to farthest position
            }
        }
        //spawns final floor above farthest tile it has found
        GameObject finalFloor = Instantiate(lastTile) as GameObject; 
        finalFloor.transform.position = farthestPosition + new Vector3(0, 10f, 0);
    }

    void worldRender(GameObject[] world) //renders objects in array based on camera distance
    {
        foreach (GameObject piece in world)
        {
            if (piece != null)
            {
                if (Vector2.Distance(piece.transform.position, Camera.main.transform.position) > 25)
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
}

