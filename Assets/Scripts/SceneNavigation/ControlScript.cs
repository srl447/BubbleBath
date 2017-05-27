using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour {

    //needed to change the background to controls 
    public SpriteRenderer back;
    public Sprite control;

    //needed for moving play button to bottom
    public Transform play;
    public Vector3 newLoc;
	
	void Update ()
    {
        back.sprite = control; //changes background to controls
        play.position = newLoc; //moves play to new location
        play.localScale = new Vector3(.8f, .8f, .8f);
        Destroy(gameObject); //destroys control button 
	}
}
