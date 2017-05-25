using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    public bool buttonPressed;
	void Update ()
    {
        if (buttonPressed)
        {
            SceneManager.LoadScene(1);
        }
	}
}
