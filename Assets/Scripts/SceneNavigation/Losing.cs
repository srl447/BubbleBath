using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour
{
    public GameObject boat1, boat2; //boats for death anim

    bool animOn; //so coroutine only runs once

    public AudioClip death; //death sound

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameManager.totalHealth <= 0 && !animOn) //starts the death anim when health hits 0
        {
            StartCoroutine(DeathAnimation(boat1));
            StartCoroutine(DeathAnimation(boat2));
            animOn = true;
        }
	}

    IEnumerator DeathAnimation(GameObject boat)
    {
        //turns off scripts for player action
        Aiming aim = boat.GetComponentInChildren<Aiming>();
        Shooting shoot = boat.GetComponentInChildren<Shooting>();
        MovePlayer1 move = boat.GetComponent<MovePlayer1>();
        aim.enabled = !aim.enabled;
        move.enabled = !move.enabled;
        shoot.enabled = !shoot.enabled;

        //stops bgm and starts death sound
        GameManager.aud.Stop();
        GameManager.aud.PlayOneShot(death);

        //plays death animation
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForEndOfFrame();
            boat.transform.eulerAngles = boat.transform.eulerAngles + new Vector3(0f, 0f, 18.1f); //rotates object
            boat.transform.localScale = boat.transform.localScale - new Vector3(.11f, .11f, 0f);  //shrinks object
        }
        SceneManager.LoadScene(2); //loads death scene
    }
}
