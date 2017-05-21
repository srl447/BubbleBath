using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bubble; //gameobject for shooting

    public float timeBetweenShots;

	// Update is called once per frame
	void Start ()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() //shoot every timeBetweenShots seconds
    {
        GameObject newBubble = Instantiate(bubble) as GameObject; //creating bullet
        newBubble.transform.position = transform.position; // placing it at player location
        newBubble.transform.eulerAngles = transform.eulerAngles;

        yield return new WaitForSeconds(timeBetweenShots);
        StartCoroutine(Shoot()); //starts Coroutine again
    }
}
