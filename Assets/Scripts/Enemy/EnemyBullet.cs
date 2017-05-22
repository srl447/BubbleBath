using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    Transform player;
    public float bulletSpeed;
    Vector3 dir;
    public string whichPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(whichPlayer).transform;
        if (player.position.x > transform.position.x)
        {
            dir = Vector3.right;
        }
        else
        {
            dir = Vector3.left;
        }
    }
    void FixedUpdate()
    {
        
        transform.Translate(dir * Time.deltaTime * bulletSpeed); //moves bullet forward
    }
    // Update is called once per frame
    void Update ()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 20f)
        {
            Destroy(gameObject); //Destorys When too far from camera
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
