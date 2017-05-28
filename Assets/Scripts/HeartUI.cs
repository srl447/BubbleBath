using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour {

    public Animator[] hearts; //gets animators for all the hearts

    int oldHealth; //records what health was on the last frame

	void Update ()
    {
        if (GameManager.totalHealth > -1) //makes sure no out of bound errors happens when you lose multiple hearts
        {
            // there's a hidden heart, so this plays the destruction animation for the heart for total health
            // the hidden heart animation plays when at full health
            hearts[GameManager.totalHealth].SetBool("Show", false);
        }
        if (GameManager.totalHealth > oldHealth && GameManager.totalHealth > 0) //checks if health has increased
        {
            hearts[GameManager.totalHealth-1].SetBool("Show", true);
        }
        oldHealth = GameManager.totalHealth; //sets the old health to the current health

    }
}
