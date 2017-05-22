using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AI : MonoBehaviour
{
    Transform player;

    public GameObject bubble; //gameobject for shooting

    public float range;
    public float timeBetweenShots;

    public string whichPlayer;

    // Update is called once per frame
    void Awake()
    {
        StartCoroutine(Shoot());
        player = GameObject.FindGameObjectWithTag(whichPlayer).transform;
    }

    void Update()
    {
        if(Vector2.Distance(player.position, this.transform.position) < range)
        {
            Vector2 direction = player.position - transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), .2f);

            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
        }
    }


    IEnumerator Shoot() //shoot every timeBetweenShots seconds
    {
        yield return new WaitForSeconds(timeBetweenShots);
        GameObject newEnemyBubble = Instantiate(bubble) as GameObject; //creating bullet
        newEnemyBubble.transform.position = transform.position; // placing it at enemy location
        newEnemyBubble.transform.eulerAngles = transform.eulerAngles;
        StartCoroutine(Shoot()); //starts Coroutine again
    }
}
