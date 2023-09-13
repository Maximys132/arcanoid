using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class BonuseScr : MonoBehaviour
{
    public LevelsRule lvlRule;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rg;
    private bool cathed;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Vector2 dir = Vector2.up;
        dir.x = UnityEngine.Random.Range(-1.3f, 1.3f);
        rg.velocity = dir * UnityEngine.Random.Range(0.5f, 3.5f);
        rg.angularVelocity = UnityEngine.Random.Range(10, 50f);
        if (UnityEngine.Random.Range(0, 1) > 0) 
            rg.angularVelocity = -rg.angularVelocity;
        cathed = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        int rng = UnityEngine.Random.Range(1, 4);
        if (rng == 1)
            spriteRenderer.sprite = sprite1;
        if (rng == 2)
            spriteRenderer.sprite = sprite2;
        if (rng == 3)
            spriteRenderer.sprite = sprite3;
        Debug.Log("Rand " + rng);
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            DestroyObject(this.gameObject, 0.1f);
            cathed = false;
        }/**/
        if (collision.CompareTag("Player"))
        {
            DestroyObject(this.gameObject, 0.01f);
            if (cathed) 
                lvlRule.CatchBonuce();
            cathed = false;
        }
    }
}
