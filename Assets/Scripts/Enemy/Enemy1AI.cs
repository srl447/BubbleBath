using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : MonoBehaviour {

    Transform player; //to use player positions
    public string whichPlayer;


    public float speed; //enemy speed
    public float range; //enemy vision radius

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(whichPlayer).transform;
    }

	// Update is called once per frame
	void Update ()
    {
		if(Vector2.Distance(player.position, this.transform.position) < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
	}
}
