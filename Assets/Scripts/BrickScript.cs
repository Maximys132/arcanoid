using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject lrObj;

    private Animator anim;
    private LevelsRule lvlRule;
    private bool isOk;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("Shining", 0, 0, UnityEngine.Random.Range(0, 2f));
        anim.speed = UnityEngine.Random.Range(0.5f, 1.5f);
        lvlRule = lrObj.GetComponent<LevelsRule>();
        isOk = true;
        //lvlRule = 
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
            if (isOk)
            {
                anim.SetInteger("health", 0);
                anim.speed = 2f;
                isOk = false;
            }    
        }
    }

    void brickBreak()
    {
        GetComponent<Collider2D>().enabled = false;
        lvlRule.BrickDown();
    }
}
