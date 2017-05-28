using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemoval : MonoBehaviour {

    public AudioClip bubblePop;

    public Sprite urchin; //this is used for a workaround to avoid sound playing when hitting urchins

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
        //plays sound for hitting enemies
        if(collision.gameObject.tag ==  "Enemy" && collision.gameObject.GetComponent<SpriteRenderer>().sprite != urchin)
        {
            GameManager.aud.PlayOneShot(bubblePop);
        }
        Destroy(gameObject); //Destorys on Collision
    }
}
