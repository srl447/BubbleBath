using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGenMap : MonoBehaviour
{
    public GameObject tile; //gameobject to be placed as floor
    public GameObject seed; //gameobject to spread more game objects
    Vector3 lastMove = new Vector3 (0f, 10f, 0f); //grabs the last movement


    // Use this for initialization
    void Start()
    {
        GameObject startFloor = Instantiate(tile) as GameObject; //first tile placed

        for (int i = 0; i < 15; i++) //places the rest of the tiles
        {
            int randomDirection; //randomly decides which direction to go in
            randomDirection = Random.Range(0, 100/(i+1));
            if (randomDirection == 0)
            {
                transform.position = transform.position + new Vector3(12.5f, 0, 0);
                lastMove = new Vector3(12.5f, 0, 0);
            }
            else if (randomDirection == 1)
            {
                transform.position = transform.position + new Vector3(-12.5f, 0, 0);
                lastMove = new Vector3(-12.5f, 0, 0);
            }
            else if (randomDirection == 2)
            {
                transform.position = transform.position + new Vector3(0, 10f, 0);
                lastMove = new Vector3(0, -10f, 0);
            }
            else if (randomDirection == 3)
            {
                transform.position = transform.position + new Vector3(0, -10f, 0);
                lastMove = new Vector3(0, -10f, 0);
            }
            else 
            {
                transform.position = transform.position + lastMove; //goes in the same direction as last time
            }
            GameObject newFloor = Instantiate(tile) as GameObject; //places new floor tile
            newFloor.transform.position = transform.position;
            GameManager.tileCount++; //increases global world size
            int seedDrop = Random.Range(0, 17 - i);
            if(seedDrop == 0 && GameManager.tileCount < 100) //possibly drops new seed and checks if the world is big enough yet
            {
                GameObject newSeed = Instantiate(seed) as GameObject;
                newSeed.transform.position = transform.position;
            }
        }
        Destroy(gameObject);
    }
}