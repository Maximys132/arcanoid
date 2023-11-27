using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Scr_Brick : MonoBehaviour
{

    public GameObject lrObj;
    public GameObject Bonus;
    [Range(0f, 1f)]
    public float bonuce_Spawn_Chance;
    [Range(1, 5)]
    public int bonuce_Count_Chance;
    [SerializeField] private AudioClip[] clips;

    private Animator anim;
    private Scr_LevelsRule lvlRule;
    private bool isOk;
    private Collider2D collader;
    private int health;
    private AudioSource audioSrc;

    void Start()
    {
        //spawnBonuce = Range 
        audioSrc = GetComponent<AudioSource>();
        collader = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        health = anim.GetInteger("health");
        anim.CrossFade("Brick_"+ health + "_Stay", 0, 0, UnityEngine.Random.Range(0, 2f));
        anim.speed = UnityEngine.Random.Range(0.5f, 1.5f);
        lvlRule = lrObj.GetComponent<Scr_LevelsRule>();
        isOk = true;
        audioSrc.clip = clips[health - 1];
        //lvlRule = 
        //anim.SetInteger("health", health);
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
            damaged();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        { 
            damaged();
        }

    }

    private void damaged()
    {
            if (isOk)
            {
                audioSrc.PlayOneShot(audioSrc.clip);
                health--;
                anim.SetInteger("health", health);
                anim.speed = 2f;
                isOk = false;
            }
    }

    [System.Obsolete]
    void brickBreak()
    {
        if (health == 0)
        {
            collader.enabled = false;
            lvlRule.BrickDown();
            DestroyObject(this.gameObject, 0.1f);
        }
        else
        {
            audioSrc.clip = clips[health-1];
            isOk = true;
            anim.speed = UnityEngine.Random.Range(0.5f, 1.5f);
        }

        if (UnityEngine.Random.Range(0.0f, 1.0f) > bonuce_Spawn_Chance)
        {
            for (int i = 0; i < UnityEngine.Random.Range(0, bonuce_Count_Chance); i++)
            {
                Instantiate(Bonus, GetComponent<Transform>().localPosition, Quaternion.identity);
                Bonus.GetComponent<Scr_BonuseScr>().lvlRule = lvlRule;
            }
        }
        //Bonus.
    }
}
