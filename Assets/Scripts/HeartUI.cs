using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour {

    public Animator[] hearts;

    int oldHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.totalHealth > -1)
        {
            hearts[GameManager.totalHealth].SetBool("Show", false);
        }
        if (GameManager.totalHealth > oldHealth)
        {
            hearts[GameManager.totalHealth-1].SetBool("Show", true);
        }
        oldHealth = GameManager.totalHealth;

    }
}
