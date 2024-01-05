
using UnityEngine;
using UnityEngine.UI;

public class Scr_cart_state : MonoBehaviour
{
    [SerializeField] private int cost = 5;
    [SerializeField] private float cd_time = 1f;
    [SerializeField] public Scr_cartsDecka spel;


    private Animator anim;
    private Image stab;
    private bool isCD;
    private float timer = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        isCD = anim.GetBool("cooldown");
        CheckGold(0);
    }
    public void FixedUpdate()
    {
        if (isCD)
        {
            timer = timer + Time.deltaTime;
            if (timer > cd_time)
            {
                timer = 0;
                isCD = false;
                anim.SetBool("cooldown", isCD);
            }
        }
    }

    public void CheckGold(int gold)
    {
        if (cost < gold && !isCD)
        {
            activate();
        } else
        {
            enable();
        }
    }

    public void activateSpel()
    {
        if (!isCD && anim.GetBool("enable"))
        {
            spel.Invoke("activateFireBall", 0f);
            isCD = true;
            anim.SetBool("cooldown", isCD);
            anim.SetBool("enable", false);
            anim.speed = 1 / cd_time;
        }
    }
    void activate()
    {
        Debug.Log("cart activate");
        anim.SetBool("enable", true);
        //stab.CrossFadeAlpha(0f, 100f, true); 
    }

    void enable()
    {
        Debug.Log("cart enable");
        anim.SetBool("enable", false);
        //stab.CrossFadeAlpha(0.7f, 100f, true);
    }

}
