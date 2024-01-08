
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Scr_cart_state : MonoBehaviour
{
    [SerializeField] public string spelName;
    [SerializeField] public int cost = 5;
    [SerializeField] public float cd_time = 1f;
    [SerializeField] public Scr_cartsDecka spel;

    private Animator anim;
    private bool isCD;
    private TextMeshProUGUI CostInfo;

    void Start()
    {
        anim = GetComponent<Animator>();
        isCD = anim.GetBool("cooldown");
        CheckGold(0);

        CostInfo = this.gameObject.transform.GetChild(0).GameObject().GetComponent<TextMeshProUGUI>();
        CostInfo.text = cost.ToString();
    }

    private void CooldownEnd()
    {
        isCD = false;
        anim.SetBool("cooldown", isCD);
    }

    public void CheckGold(int gold)
    {
        if (cost < gold)
        {
            activate();
        } else
        {
            enable();
        }
    }

    public void activateSpel()
    {
        //Debug.Log("cooldown " + anim.GetBool("cooldown") + ", enable " + anim.GetBool("enable"));
        if (!isCD && anim.GetBool("enable"))
        {
            spel.spelTimer = cd_time;
            spel.Invoke(spelName, 0f);
            spel.LevelsRule.addGold(-cost);
            isCD = true;
            anim.SetBool("cooldown", isCD);
            anim.speed = 1 / cd_time;
        }
    }
    void activate()
    {
        //Debug.Log("cart activate");
        anim.SetBool("enable", true);
        //stab.CrossFadeAlpha(0f, 100f, true); 
    }

    void enable()
    {
        //Debug.Log("cart enable");
        anim.SetBool("enable", false);
        //stab.CrossFadeAlpha(0.7f, 100f, true);
    }

}
