using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemoval : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 10.5f)
        {
            Destroy(gameObject); //Destorys When too far from camera
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //Destorys on Collision
    }
}
