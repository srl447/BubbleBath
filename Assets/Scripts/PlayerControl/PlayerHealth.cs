using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float knockbackStrength; //how far enemies knock players back

    Vector3 knockback; //angle for knockback

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
        //lerps the player to a farther away position
        if (knockbackStrength > .1)
        {
            transform.position = Vector2.Lerp(transform.position, transform.position + knockback, knockbackStrength/10);
        }
        knockbackStrength = Mathf.Lerp(knockbackStrength, 0f, Time.deltaTime * 5f); // bring it back down to 0
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //player collides with enemy
        {
            GameManager.totalHealth -= 1; //players lose 1 health

            ScreenShake.shakeStrength = 8f;

            knockback = transform.position - collision.gameObject.transform.position; //calcultes angle to knockback players at
            knockbackStrength = 1.3f; //sets knockback
            
        }
        else if (collision.gameObject.tag == "Health" && GameManager.totalHealth < 5) //player collides with health pickup
        {
            GameManager.totalHealth++; //player gains 1 health
            Destroy(collision.gameObject); //destroys pickup
        }
        
    }
}
