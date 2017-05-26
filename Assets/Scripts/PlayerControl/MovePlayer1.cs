using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    public float speed; //how fast they move

    public GameObject boatSprite; //for rotate graphic

    public bool up, left, right, down; //bools for checking input

    public KeyCode upK, leftK, rightK, downK; //keys to use same script for both players

    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //check input for moving up
        if (Input.GetKey(upK))
        {
            up = true;
        }
        else
        {
            up = false;
        }

        //check input for moving left
        if (Input.GetKey(leftK))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        //check input for moving right
        if (Input.GetKey(rightK))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        //check input for moving down
        if (Input.GetKey(downK))
        {
            down = true;
        }
        else
        {
            down = false;
        }
        if ((up || right || down || left) && !aud.isPlaying)
        {
            aud.Play();
        }
        else if (!up && !right && !down && !left && aud.isPlaying)
        {
            aud.Stop();
        }
    }

    void FixedUpdate()
    {
        //translate up
        if(up)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
            boatSprite.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //translate left
        if (left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            boatSprite.transform.eulerAngles = new Vector3(0, 0, 90);
        }

        //translate right
        if (right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            boatSprite.transform.eulerAngles = new Vector3(0, 0, 270);
        }

        //translate down
        if (down)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
            boatSprite.transform.eulerAngles = new Vector3(0, 0, 180);
        }


    }
}
