using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

public class BallMove : MonoBehaviour
{
    public float speed = 8;
    private Rigidbody2D rg;
    private float maxAngleInterval = 0.67f;
    
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Vector2 dir = Vector2.up;
        dir.x = UnityEngine.Random.Range(-maxAngleInterval, maxAngleInterval);
        rg.velocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.();
        if (collision.CompareTag("Respawn"))
        {
            UnityEngine.Debug.Log("ladida");
        }
        if (collision.CompareTag("Player"))
        {
            //collision.
            //rg.velocity = rg.velocity * speed;
        }
    }
}
