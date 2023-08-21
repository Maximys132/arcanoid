using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void FixedUpdate() 
    { 
        //if (health <= 0 )

    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            anim.SetInteger("health", 0);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
