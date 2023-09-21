using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Electricity : MonoBehaviour
{
    [SerializeField] private int _speed = 8;
    //[SerializeField] private Transform _position;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startpos = new Vector3(0, -5.77f, 0);
        GetComponent<Transform>().position = startpos;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * _speed;
    }
    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Brick"))
        {
            DestroyObject(gameObject, 0f);
        }
    }
}
