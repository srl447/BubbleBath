using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemoval : MonoBehaviour {

    public AudioClip bubblePop;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag ==  "Enemy")
        {
            GameManager.aud.PlayOneShot(bubblePop);
        }
        Destroy(gameObject); //Destorys on Collision
    }
}
