using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))] // enforce that this script goes on an object with a camera

public class ScreenShake : MonoBehaviour
{
    public static float shakeStrength = 0f;

    public Transform player1, player2;

    Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeStrength > .1)
        {
            // this actually does the shaking
            transform.position = Vector3.Lerp(
                transform.position,
                startPosition + Random.insideUnitSphere * shakeStrength,
                Time.deltaTime * 5f
            );

        }
        else
        {
            transform.position = ((player1.position + player2.position) / 2) + new Vector3(0f, 0f, -10f);
        }
        // control shake strength
        if (Input.GetKeyDown(KeyCode.Space))
        { // debug
            shakeStrength = 10f;
        }
        shakeStrength = Mathf.Lerp(shakeStrength, 0f, Time.deltaTime * 5f); // bring it back down to 0
        startPosition = ((player1.position + player2.position) / 2) + new Vector3(0f, 0f, -10f); ;

    }
}
