using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AI : MonoBehaviour {

    public Transform player1, player2; //to use player positions

    public float speed; //enemy speed
    public float range; //enemy vision radius
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(player1.position, this.transform.position) < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player1.position, speed * Time.deltaTime);
        }


	}
}
