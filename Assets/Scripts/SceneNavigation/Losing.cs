using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour
{
    public GameObject boat1, boat2;

    bool animOn;

    public AudioClip death;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameManager.totalHealth <= 0 && !animOn)
        {
            StartCoroutine(DeathAnimation(boat1));
            StartCoroutine(DeathAnimation(boat2));
            animOn = true;
        }
	}

    IEnumerator DeathAnimation(GameObject boat)
    {
        Aiming aim = boat.GetComponentInChildren<Aiming>();
        Shooting shoot = boat.GetComponentInChildren<Shooting>();
        MovePlayer1 move = boat.GetComponent<MovePlayer1>();
        aim.enabled = !aim.enabled;
        move.enabled = !move.enabled;
        GameManager.aud.Stop();
        GameManager.aud.PlayOneShot(death);
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForEndOfFrame();
            boat.transform.eulerAngles = boat.transform.eulerAngles + new Vector3(0f, 0f, 18.1f);
            boat.transform.localScale = boat.transform.localScale - new Vector3(.11f, .11f, 0f); 
        }
        SceneManager.LoadScene(2);
    }
}
