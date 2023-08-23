using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveFree : MonoBehaviour
{
    public float speed = 8;
    public Vector2 StartVelocity;
    private Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = StartVelocity * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
