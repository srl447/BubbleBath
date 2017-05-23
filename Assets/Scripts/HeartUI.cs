using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour {

    public Animator[] hearts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.totalHealth > -1)
        {
            hearts[GameManager.totalHealth].SetTrigger("Hurt");
        }
	}
}
