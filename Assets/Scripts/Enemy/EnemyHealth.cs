using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;

	// Use this for initialization
	void Start ()
    {
		
	}

	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - 1;
            Destroy(collision.gameObject);
        }
    }
}
