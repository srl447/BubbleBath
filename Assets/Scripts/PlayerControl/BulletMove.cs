using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float bulletSpeed;

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed); //moves bullet forward
	}
}
