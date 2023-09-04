using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject lrObj;
    public GameObject Bonus;
    [Range(0f, 1f)]
    public float bonuce_Spawn_Chance;
    [Range(1, 5)]
    public int bonuce_Count_Chance;

    private Animator anim;
    private LevelsRule lvlRule;
    private bool isOk;
    private Collider2D collader;
    void Start()
    {
        //spawnBonuce = Range 
        collader = GetComponent<Collider2D>();
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
        collader.enabled = false;
        lvlRule.BrickDown();
        if (UnityEngine.Random.Range(0.0f, 1.0f) > bonuce_Spawn_Chance)
        {
            for (int i = 0; i < UnityEngine.Random.Range(0, bonuce_Count_Chance); i++)
            {
                Instantiate(Bonus, GetComponent<Transform>().localPosition, Quaternion.identity);
                Bonus.GetComponent<BonuseScr>().lvlRule = lvlRule;
            }
        }
        //Bonus.
    }
}
