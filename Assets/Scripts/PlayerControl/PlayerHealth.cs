using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float knockbackStrength; //how far enemies knock players back


    //Transform parent;

	// Use this for initialization
	void Start ()
    {
        //parent = GetComponentInParent<Transform>();
        GameManager.totalHealth = 5;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //player collides with enemy
        {
            GameManager.totalHealth -= 1; //players lose 1 health

            ScreenShake.shakeStrength = 8f;

            Vector2 knockback = transform.position - collision.gameObject.transform.position; //calcultes angle to knockback players at
            transform.Translate(knockback * knockbackStrength); //knocks back players
            
        }
        else if (collision.gameObject.tag == "Health" && GameManager.totalHealth < 5) //player collides with health pickup
        {
            GameManager.totalHealth++; //player gains 1 health
            Destroy(collision.gameObject); //destroys pickup
        }
        
    }
}
