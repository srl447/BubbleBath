using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    public bool up, left, right, down; //bools for checking input

    public KeyCode upK, leftK, rightK, downK; //keys to use same script for both players

    // Update is called once per frame
    void Update()
    {
        //check input for aiming up
        if (Input.GetKey(upK))
        {
            up = true;
        }
        else
        {
            up = false;
        }

        //check input for aiming left
        if (Input.GetKey(leftK))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        //check input for aiming right
        if (Input.GetKey(rightK))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        //check input for aiming down
        if (Input.GetKey(downK))
        {
            down = true;
        }
        else
        {
            down = false;
        }
    }

    void FixedUpdate()
    {
        //rotates up
        if (up)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //rotates left
        if (left)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        //rotates right
        if (right)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }

        //rotates down
        if (down)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }


    }
}
