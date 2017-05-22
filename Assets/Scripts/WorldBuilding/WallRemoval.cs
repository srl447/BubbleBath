using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemoval : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
